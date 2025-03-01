﻿using Bewoning.Data.Mock.Entities;
using Bewoning.Data.Mock.Generated;
using Bewoning.Data.Mock.Repositories;
using Brp.Shared.Infrastructure.Utils;
using System.Text.RegularExpressions;

namespace Bewoning.Data.Mock.Controllers;

public static class AdreshoudingToBewoningLogic
{
    private static readonly Regex OnbekendDatumRegex = new("^0{8}|[1-9][0-9]{3}0{4}|[1-9][0-9]{5}0{2}$", RegexOptions.None, TimeSpan.FromMilliseconds(100));

    private static (long datumVan, long datumTot) BepaalZekerheidsperiode(string datumAanvang, string? datumEinde)
    {
        (bool datumAanvangGeheelOnvolledig, bool datumAanvangDeelsOnvolledig) = datumAanvang.IsOnvolledigDatum();
        (bool datumEindeGeheelOnvolledig, bool datumEindeDeelsOnvolledig) = datumEinde != null
            ? datumEinde.IsOnvolledigDatum()
            : (false, false);

        if (!datumAanvangDeelsOnvolledig && !datumAanvangGeheelOnvolledig && !datumEindeDeelsOnvolledig && !datumEindeGeheelOnvolledig)
        {
            return (datumAanvang.ToNumber(),
                !string.IsNullOrWhiteSpace(datumEinde)
                    ? datumEinde.ToNumber()
                    : long.MaxValue);
        }
        if (datumAanvangGeheelOnvolledig && datumEindeGeheelOnvolledig)
        {
            return (0, 0);
        }

        return (datumAanvang.ToCeilingNumber(), datumEinde.ToFloorNumber());
    }

    public static bool IsBewoner(this Verblijfplaats verblijfplaats, Periode periode)
    {
        (long datumAanvang, long datumEinde) = BepaalZekerheidsperiode(verblijfplaats.DatumAanvangAdreshouding!,
                                                                       verblijfplaats.DatumEindeAdreshouding);

        return periode.DatumVan!.Value.ToNumber() >= datumAanvang &&
                periode.DatumTot!.Value.ToNumber() <= datumEinde;
    }

    public static bool IsMogelijkeBewoner(this Verblijfplaats verblijfplaats, Periode periode)
    {
        if (!OnbekendDatumRegex.IsMatch(verblijfplaats.DatumAanvangAdreshouding!) &&
            (string.IsNullOrWhiteSpace(verblijfplaats.DatumEindeAdreshouding) ||
            !OnbekendDatumRegex.IsMatch(verblijfplaats.DatumEindeAdreshouding!))) return false;

        var datumVanAanvang = verblijfplaats.DatumAanvangAdreshouding.ToFloorNumber();
        var datumTotAanvang = verblijfplaats.DatumAanvangAdreshouding.ToCeilingNumber();
        var datumVanEinde = verblijfplaats.DatumEindeAdreshouding.ToFloorNumber();
        var datumTotEinde = verblijfplaats.DatumEindeAdreshouding.ToCeilingNumber();

        var datumVanPeriode = periode.DatumVan!.Value.ToNumber();
        var datumTotPeriode = periode.DatumTot!.Value.ToNumber();

        if (datumVanAanvang == datumTotAanvang && datumVanEinde == datumTotEinde) return false;
        if (datumVanPeriode >= datumTotEinde) return false;
        if (datumTotPeriode <= datumVanAanvang) return false;
        if (datumVanPeriode >= datumTotAanvang && datumTotPeriode <= datumVanEinde) return false;

        return true;
    }

    public static List<GbaBewoning> ToBewoningenMetPeriode(this IEnumerable<long> datums, string adresseerbaarObjectIdentificatie)
    {
        var retval = new List<GbaBewoning>();

        var tmpDatums = datums.Distinct().OrderBy(x => x).ToList();

        for (var index = 0; index < tmpDatums.Count - 1; index++)
        {
            var bewoning = new GbaBewoning
            {
                AdresseerbaarObjectIdentificatie = adresseerbaarObjectIdentificatie,
                Periode = new Periode
                {
                    DatumVan = tmpDatums[index].ToDateTimeOffset(),
                    DatumTot = tmpDatums[index + 1].ToDateTimeOffset(),
                },
                Bewoners = new List<GbaBewoner>(),
                MogelijkeBewoners = new List<GbaBewoner>(),
            };

            retval.Add(bewoning);
        }

        return retval;
    }

    public static bool Between(this long gbaDatum, long van, long tot)
    {
        return van < gbaDatum && tot > gbaDatum;
    }

    public static IEnumerable<long> AdreshoudingDatumsBetween(this Verblijfplaats verblijfplaats, long van, long tot)
    {
        var retval = new List<long>();

        var datumAanvangAdreshouding = verblijfplaats?.DatumAanvangAdreshouding;
        if (datumAanvangAdreshouding != null)
        {
            retval.AddRange(from datum in datumAanvangAdreshouding.ToGbaDatum()
                            where datum.Between(van, tot)
                            select datum);
        }

        var datumEindeAdreshouding = verblijfplaats?.DatumEindeAdreshouding;
        if (datumEindeAdreshouding != null)
        {
            retval.AddRange(from datum in datumEindeAdreshouding.ToGbaDatum()
                            where datum.Between(van, tot)
                            select datum);
        }

        return retval;
    }

    public static List<GbaBewoning> ToGbaBewoningen(this ICollection<Persoon>? personen, string adresseerbaarObjectIdentificatie, string van, string tot)
    {
        var retval = new List<GbaBewoning>();

        if (personen != null && personen.Any())
        {
            var datumVan = van.ToDateTimeOffset().ToNumber();
            var datumTot = tot.ToDateTimeOffset().ToNumber();
            List<long> datums = new() { datumVan, datumTot };

            foreach (var persoon in personen)
            {
                var verblijfplaats = persoon?.Verblijfplaats;
                if (verblijfplaats != null)
                {
                    datums.AddRange(verblijfplaats.AdreshoudingDatumsBetween(datumVan, datumTot));
                }
            }

            retval.AddRange(datums.ToBewoningenMetPeriode(adresseerbaarObjectIdentificatie));

            foreach (var persoon in personen)
            {
                var bewoner = persoon.Map();

                var bewoningen = from bewoning in retval
                                 where persoon.Verblijfplaats!.IsBewoner(bewoning.Periode)
                                 select bewoning;

                foreach (var bewoning in bewoningen)
                {
                    bewoning.Bewoners.Add(bewoner);
                }

                bewoningen = from bewoning in retval
                             where persoon.Verblijfplaats!.IsMogelijkeBewoner(bewoning.Periode)
                             select bewoning;

                foreach (var bewoning in bewoningen)
                {
                    bewoning.MogelijkeBewoners.Add(bewoner);
                }
            }
        }

        return retval;
    }

    private static GbaBewoner Map(this Persoon persoon)
    {
        return new GbaBewoner
        {
            Burgerservicenummer = persoon.BurgerserviceNummer,
            GeheimhoudingPersoonsgegevens = persoon.MapGeheimhouding(),
            Naam = persoon.Naam.Map(),
            Geboorte = persoon.Geboorte.Map()
        };
    }

    private static NaamBasis? Map(this Naam? naam)
    {
        return naam != null
            ? new NaamBasis
                {
                    Voornamen = naam.Voornamen,
                    Voorvoegsel = naam.Voorvoegsel,
                    Geslachtsnaam = naam.Geslachtsnaam,
                    AdellijkeTitelPredicaat = naam.AdellijkeTitelPredicaat
                }
            : null;
    }

    private static GeboorteBasis? Map(this Geboorte? geboorte)
    {
        return geboorte != null
            ? new GeboorteBasis
                {
                    Datum = geboorte.Datum
                }
            : null;
    }

    private static int? MapGeheimhouding(this Persoon persoon)
    {
        return persoon.GeheimhoudingPersoonsgegevens.GetValueOrDefault(0) > 0
            ? persoon.GeheimhoudingPersoonsgegevens.GetValueOrDefault(0)
            : null;
    }
}

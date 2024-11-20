using Brp.Shared.DtoMappers.BrpApiDtos;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Brp.Shared.DtoMappers.Mappers;

public static class DatumMapper
{
    private static readonly Regex GbaDatumRegex = new("^(?<jaar>[0-9]{4})(?<maand>[0-9]{2})(?<dag>[0-9]{2})$", RegexOptions.None, TimeSpan.FromMilliseconds(100));

    public static AbstractDatum Map(this string datum)
    {
        if (GbaDatumRegex.IsMatch(datum))
        {
            var match = GbaDatumRegex.Match(datum);
            var jaar = int.Parse(match.Groups["jaar"].Value, CultureInfo.InvariantCulture);
            var maand = int.Parse(match.Groups["maand"].Value, CultureInfo.InvariantCulture);
            var dag = int.Parse(match.Groups["dag"].Value, CultureInfo.InvariantCulture);

            AbstractDatum retval = new DatumOnbekend();
            if (jaar != 0 && maand != 0 && dag != 0)
            {
                retval = new VolledigeDatum() { Datum = new DateTime(jaar, maand, dag) };
            }
            if (jaar != 0 && maand != 0 && dag == 0)
            {
                retval = new JaarMaandDatum() { Jaar = jaar, Maand = maand };
            }
            if (jaar != 0 && maand == 0 && dag == 0)
            {
                retval = new JaarDatum { Jaar = jaar };
            }

            retval.LangFormaat = retval.LangFormaat();
            return retval;

        }
        return new DatumOnbekend
        {
            LangFormaat = "onbekend"
        };
    }

    public static string? LangFormaat(this AbstractDatum datum)
    {
        var maand = new Dictionary<int, string>
        {
            {1, "januari" },
            {2, "februari" },
            {3, "maart" },
            {4, "april" },
            {5, "mei" },
            {6, "juni" },
            {7, "juli" },
            {8, "augustus" },
            {9, "september" },
            {10, "oktober" },
            {11, "november" },
            {12, "december" }
        };

        return datum switch
        {
            VolledigeDatum d => $"{d.Datum!.Value.Day} {maand[d.Datum!.Value.Month]} {d.Datum!.Value.Year}",
            JaarMaandDatum d => $"{maand[d.Maand!.Value]} {d.Jaar}",
            JaarDatum d => $"{d.Jaar}",
            DatumOnbekend => "onbekend",
            _ => null
        };
    }
}

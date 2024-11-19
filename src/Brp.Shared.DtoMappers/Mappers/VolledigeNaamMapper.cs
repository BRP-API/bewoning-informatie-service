using Brp.Shared.DtoMappers.Interfaces;

namespace Brp.Shared.DtoMappers.Mappers;

public static class VolledigeNaamMapper
{
    public static string? VolledigeNaam(this INaamBasis naam, IWaardetabel? geslacht)
    {
        var adellijkeTitel = naam.AdellijkeTitelPredicaat.MapNaarAdellijkeTitel(geslacht);
        var predikaat = naam.AdellijkeTitelPredicaat.MapNaarPredicaat(geslacht);

        var retval = $"{predikaat} {naam.Voornamen} {adellijkeTitel} {naam.Voorvoegsel} {naam.Geslachtsnaam}".RemoveRedundantSpaces();

        return !string.IsNullOrWhiteSpace(retval)
            ? retval
            : null;
    }
}

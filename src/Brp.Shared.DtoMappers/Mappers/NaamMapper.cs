using Brp.Shared.DtoMappers.Interfaces;

namespace Brp.Shared.DtoMappers.Mappers;

public static class NaamMapper
{
    public static string Achternaam(this INaamBasis? naam)
    {
        return naam != null &&
               !string.IsNullOrWhiteSpace(naam.Geslachtsnaam) &&
               naam.Geslachtsnaam != "."
            ? $"{naam.Voorvoegsel} {naam.Geslachtsnaam}".RemoveRedundantSpaces()
            : string.Empty;
    }
}

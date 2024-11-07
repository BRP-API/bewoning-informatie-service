using Bewoning.Informatie.Service.Generated.Gba;
using Bewoning.Informatie.Service.Helpers;
using System.Text.RegularExpressions;

namespace Bewoning.Informatie.Service.Mappers
{
    public static class VolledigeNaamMapper
    {
        public static string? VolledigeNaam(this GbaNaamPersoon naam, Waardetabel? geslacht)
        {
            if (naam is null) return null;
            var adellijkeTitel = naam.AdellijkeTitelPredicaat?.MapNaarAdellijkeTitel(geslacht);
            var predikaat = naam.AdellijkeTitelPredicaat?.MapNaarPredicaat(geslacht);

            var retval = $"{predikaat} {naam.Voornamen} {adellijkeTitel} {naam.Voorvoegsel} {naam.Geslachtsnaam}".RemoveRedundantSpaces();

            return !string.IsNullOrWhiteSpace(retval)
                ? retval
                : null;
        }

        public static string RemoveRedundantSpaces(this string input)
        {
            var retval = Regex.Replace(input, @"\s+", " ", RegexOptions.None, TimeSpan.FromMilliseconds(100));
            retval = Regex.Replace(retval, @"\-\s+", "-", RegexOptions.None, TimeSpan.FromMilliseconds(100));

            return retval.Trim();
        }
    }
}

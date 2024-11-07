using Bewoning.Informatie.Service.Generated.Gba;

namespace Bewoning.Informatie.Service.Helpers
{
    public static class GeslachtHelper
    {
        public static bool IsVrouw(this Waardetabel? geslacht) => geslacht?.Code.ToUpperInvariant() == "V";

        public static bool IsMan(this Waardetabel? geslacht) => geslacht?.Code.ToUpperInvariant() == "M";
    }
}

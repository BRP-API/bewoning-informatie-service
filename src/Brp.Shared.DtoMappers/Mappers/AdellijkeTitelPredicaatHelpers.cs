using Brp.Shared.DtoMappers.Interfaces;

namespace Brp.Shared.DtoMappers.Mappers;

public static class AdellijkeTitelPredicaatHelpers
{
    private const string BARONES = "barones";
    private const string BARON = "baron";
    private const string GRAVIN = "gravin";
    private const string GRAAF = "graaf";
    private const string HERTOGIN = "hertogin";
    private const string HERTOG = "hertog";
    private const string MARKIEZIN = "markiezin";
    private const string MARKIES = "markies";
    private const string PRINSES = "prinses";
    private const string PRINS = "prins";
    private const string RIDDER = "ridder";

    private const string JONKVROUW = "jonkvrouw";
    private const string JONKHEER = "jonkheer";

    private static readonly Dictionary<string, string> AdellijkeTitels = new()
    {
        { "B", BARON },
        { "BS", BARONES },
        { "G", GRAAF },
        { "GI", GRAVIN },
        { "H", HERTOG },
        { "HI", HERTOGIN },
        { "M", MARKIES },
        { "MI", MARKIEZIN },
        { "P", PRINS },
        { "PS", PRINSES },
        { "R", RIDDER }
    };

    public static string MapNaarAdellijkeTitel(this IAdellijkeTitelPredicaatType adellijkeTitel, IWaardetabel? geslacht)
    {
        if (adellijkeTitel == null) return string.Empty;

        return adellijkeTitel.Code switch
        {
            "B" => AdellijkeTitels[geslacht.IsVrouw() ? "BS" : "B"],
            "BS" => AdellijkeTitels[geslacht.IsMan() ? "B" : "BS"],
            "G" => AdellijkeTitels[geslacht.IsVrouw() ? "GI" : "G"],
            "GI" => AdellijkeTitels[geslacht.IsMan() ? "G" : "GI"],
            "H" => AdellijkeTitels[geslacht.IsVrouw() ? "HI" : "H"],
            "HI" => AdellijkeTitels[geslacht.IsMan() ? "H" : "HI"],
            "M" => AdellijkeTitels[geslacht.IsVrouw() ? "MI" : "M"],
            "MI" => AdellijkeTitels[geslacht.IsMan() ? "M" : "MI"],
            "P" => AdellijkeTitels[geslacht.IsVrouw() ? "PS" : "P"],
            "PS" => AdellijkeTitels[geslacht.IsMan() ? "P" : "PS"],
            "R" => AdellijkeTitels["R"],
            _ => string.Empty,
        };
    }

    public static string MapNaarPredicaat(this IAdellijkeTitelPredicaatType predicaat, IWaardetabel? geslacht)
    {
        if (predicaat == null) return string.Empty;

        return predicaat.Code switch
        {
            "JH" => geslacht.IsVrouw() ? JONKVROUW : JONKHEER,
            "JV" => geslacht.IsMan() ? JONKHEER : JONKVROUW,
            _ => string.Empty,
        };
    }
}

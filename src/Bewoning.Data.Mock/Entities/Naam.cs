using Bewoning.Data.Mock.Generated;

namespace Bewoning.Data.Mock.Entities;

public class Naam
{
    public string? Voornamen { get; set; }
    public string? Voorvoegsel { get; set; }
    public string? Geslachtsnaam { get; set; }
    public AdellijkeTitelPredicaatType? AdellijkeTitelPredicaat { get; set; }
}

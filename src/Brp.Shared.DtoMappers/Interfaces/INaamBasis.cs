namespace Brp.Shared.DtoMappers.Interfaces;

public interface INaamBasis
{
    IAdellijkeTitelPredicaatType AdellijkeTitelPredicaat { get; }
    string Voornamen { get; }
    string Voorvoegsel { get; }
    string Geslachtsnaam { get; }
}

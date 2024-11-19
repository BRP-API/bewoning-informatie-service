namespace Brp.Shared.DtoMappers.Interfaces;

public interface INaamBasis
{
    BrpDtos.AdellijkeTitelPredicaatType AdellijkeTitelPredicaat { get; }
    string Voornamen { get; }
    string Voorvoegsel { get; }
    string Geslachtsnaam { get; }
}

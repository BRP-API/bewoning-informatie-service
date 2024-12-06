using Brp.Shared.DtoMappers.BrpDtos;

namespace Brp.Shared.DtoMappers.Interfaces;

public interface IAdellijkeTitelPredicaatType : IWaardetabel
{
    AdellijkeTitelPredicaatSoort? Soort { get; }
}

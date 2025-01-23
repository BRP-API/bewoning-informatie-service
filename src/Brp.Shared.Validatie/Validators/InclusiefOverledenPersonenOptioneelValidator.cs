using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class InclusiefOverledenPersonenOptioneelValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "inclusiefOverledenPersonen";

    public InclusiefOverledenPersonenOptioneelValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Must(y => bool.TryParse(y, out var _)).WithMessage("boolean||Waarde is geen boolean.")
            .OverridePropertyName(ParameterNaam)
            .When(x => x.Properties().Any(p => p.Name == ParameterNaam));
    }
}

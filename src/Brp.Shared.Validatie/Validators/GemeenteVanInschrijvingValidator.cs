using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class GemeenteVanInschrijvingValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "gemeenteVanInschrijving";

    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string GemeenteVanInschrijvingPattern = @"^[0-9]{4}$";
    const string GemeenteVanInschrijvingPatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {GemeenteVanInschrijvingPattern}.";

    public GemeenteVanInschrijvingValidator(bool isVerplichtVeld = false)
    {
        if (isVerplichtVeld)
        {
            RuleFor(x => x.Value<string>(ParameterNaam))
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .Matches(GemeenteVanInschrijvingPattern).WithMessage(GemeenteVanInschrijvingPatternErrorMessage)
                .OverridePropertyName(ParameterNaam);
        }
        else
        {
            RuleFor(x => x.Value<string>(ParameterNaam))
                .Cascade(CascadeMode.Stop)
                .Matches(GemeenteVanInschrijvingPattern).WithMessage(GemeenteVanInschrijvingPatternErrorMessage)
                .OverridePropertyName(ParameterNaam);
        }
    }
}

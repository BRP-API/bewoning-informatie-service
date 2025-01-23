using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class VoornamenValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "voornamen";

    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string VoornamenPattern = @"^[a-zA-Z0-9À-ž \.\-\']{1,199}\*{0,1}$";
    const string VoornamenPatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {VoornamenPattern}.";
    const string VoornamenVerplichtPattern = @"^[a-zA-Z0-9À-ž \.\-\']{1,200}$|^[a-zA-Z0-9À-ž \.\-\']{3,199}\*{1}$";
    const string VoornamenVerplichtPatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {VoornamenVerplichtPattern}.";

    public VoornamenValidator(bool isVerplichtVeld = false)
    {
        if (isVerplichtVeld)
        {
            RuleFor(x => x.Value<string>(ParameterNaam))
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RequiredErrorMessage)
                .Matches(VoornamenVerplichtPattern).WithMessage(VoornamenVerplichtPatternErrorMessage)
                .OverridePropertyName(ParameterNaam);

        }
        else
        {
            RuleFor(x => x.Value<string>(ParameterNaam))
                .Cascade(CascadeMode.Stop)
                .Matches(VoornamenPattern).WithMessage(VoornamenPatternErrorMessage)
                .OverridePropertyName(ParameterNaam);
        }
    }
}

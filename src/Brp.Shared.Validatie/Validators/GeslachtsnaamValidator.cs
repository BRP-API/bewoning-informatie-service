using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class GeslachtsnaamValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "geslachtsnaam";

    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string GeslachtsnaamPattern = @"^[a-zA-Z0-9À-ž \.\-\']{1,200}$|^[a-zA-Z0-9À-ž \.\-\']{3,199}\*{1}$";
    const string GeslachtsnaamPatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {GeslachtsnaamPattern}.";

    public GeslachtsnaamValidator(bool isVerplichtVeld = false)
    {
        var rule = RuleFor(x => x.Value<string>(ParameterNaam))
                    .Cascade(CascadeMode.Stop);

        if (isVerplichtVeld)
        {
            rule.NotEmpty().WithMessage(RequiredErrorMessage);
        }
            
        rule.Matches(GeslachtsnaamPattern).WithMessage(GeslachtsnaamPatternErrorMessage)
            .OverridePropertyName(ParameterNaam);
    }
}

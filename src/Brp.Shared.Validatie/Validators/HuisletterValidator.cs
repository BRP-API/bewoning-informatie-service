using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class HuisletterValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "huisletter";

    const string HuisletterPattern = @"^[a-zA-Z]{1}$";
    const string HuisletterErrorMessage = $"pattern||Waarde voldoet niet aan patroon {HuisletterPattern}.";

    public HuisletterValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Cascade(CascadeMode.Stop)
            .Matches(HuisletterPattern).WithMessage(HuisletterErrorMessage)
            .When(x => !string.IsNullOrWhiteSpace(x.Value<string>(ParameterNaam)))
            .OverridePropertyName(ParameterNaam);
    }
}

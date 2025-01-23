using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class HuisnummertoevoegingValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "huisnummertoevoeging";

    const string HuisnummertoevoegingPattern = @"^[a-zA-Z0-9 \-]{1,4}$";
    const string HuisnummertoevoegingErrorMessage = $"pattern||Waarde voldoet niet aan patroon {HuisnummertoevoegingPattern}.";

    public HuisnummertoevoegingValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Cascade(CascadeMode.Stop)
            .Matches(HuisnummertoevoegingPattern).WithMessage(HuisnummertoevoegingErrorMessage)
            .When(x => !string.IsNullOrWhiteSpace(x.Value<string>(ParameterNaam)))
            .OverridePropertyName(ParameterNaam);
    }
}

using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class VoorvoegselOptioneelValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "voorvoegsel";

    const string VoorvoegselPattern = @"^[a-zA-Z \']{1,10}$";
    const string VoorvoegselPatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {VoorvoegselPattern}.";

    public VoorvoegselOptioneelValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Cascade(CascadeMode.Stop)
            .Matches(VoorvoegselPattern).WithMessage(VoorvoegselPatternErrorMessage)
            .OverridePropertyName(ParameterNaam);
    }
}

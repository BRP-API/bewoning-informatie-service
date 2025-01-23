using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class GeboortedatumOptioneelValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "geboortedatum";

    const string DatePattern = @"\d{4}-\d{2}-\d{2}";
    const string DateErrorMessage = "date||Waarde is geen geldige datum.";

    public GeboortedatumOptioneelValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Cascade(CascadeMode.Stop)
            .Matches(DatePattern).WithMessage(DateErrorMessage)
            .OverridePropertyName(ParameterNaam);
    }
}

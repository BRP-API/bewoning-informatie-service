using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class GeboortedatumVerplichtValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "geboortedatum";

    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string DatePattern = @"\d{4}-\d{2}-\d{2}";
    const string DateErrorMessage = "date||Waarde is geen geldige datum.";

    public GeboortedatumVerplichtValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .Matches(DatePattern).WithMessage(DateErrorMessage)
            .OverridePropertyName(ParameterNaam);
    }
}

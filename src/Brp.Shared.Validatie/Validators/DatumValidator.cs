using Brp.Shared.Infrastructure.Utils;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class DatumValidator : AbstractValidator<JObject>
{
    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string DatePattern = @"\d{4}-\d{2}-\d{2}";
    const string DateErrorMessage = "date||Waarde is geen geldige datum.";

    public DatumValidator(string parameterNaam, bool isVerplichtVeld = false)
    {
        var rule = RuleFor(x => x.Value<string>(parameterNaam))
                    .Cascade(CascadeMode.Stop);

        if (isVerplichtVeld)
        {
            rule.NotEmpty().WithMessage(RequiredErrorMessage);
        }

        rule.Matches(DatePattern).WithMessage(DateErrorMessage)
            .OverridePropertyName(parameterNaam)
            .Custom((datum, context) =>
            {
                if (!string.IsNullOrEmpty(datum) &&
                    !datum.IsDateTime())
                {
                    context.AddFailure(DateErrorMessage);
                }
            })
            ;
    }
}

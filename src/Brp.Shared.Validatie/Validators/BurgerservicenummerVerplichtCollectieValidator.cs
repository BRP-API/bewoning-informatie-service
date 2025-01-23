using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class BurgerservicenummerVerplichtCollectieValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "burgerservicenummer";

    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string NotArrayErrorMessage = "array||Parameter is geen array.";
    const string MinItemsErrorMessage = "minItems||Array bevat minder dan {0} items.";
    const string MaxItemsErrorMessage = "maxItems||Array bevat meer dan {0} items.";
    const string BsnPattern = @"^[0-9]{9}$";
    const string BsnPatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {BsnPattern}.";

    public BurgerservicenummerVerplichtCollectieValidator()
    {
        RuleFor(x => x.GetValue(ParameterNaam))
            .Cascade(CascadeMode.Stop)
            .NotNull().OverridePropertyName(ParameterNaam).WithMessage(RequiredErrorMessage)
            .When(x => x != null)
                .Must(x => x!.Type == JTokenType.Array).OverridePropertyName(ParameterNaam).WithMessage(NotArrayErrorMessage)
            ;

        When(x => x.GetValue(ParameterNaam) != null &&
                  x.GetValue(ParameterNaam)!.Type == JTokenType.Array, () =>
                  {
                      RuleFor(x => x.Value<JArray>(ParameterNaam))
                          .Cascade(CascadeMode.Stop)
                          .Must(x => x!.Count > 0).OverridePropertyName(ParameterNaam).WithMessage(string.Format(MinItemsErrorMessage, 1))
                          .Must(x => x!.Count <= 20).OverridePropertyName(ParameterNaam).WithMessage(string.Format(MaxItemsErrorMessage, 20));

                      RuleForEach(x => x.Value<JArray>(ParameterNaam)!.Select(y => (string?)y))
                          .Matches(BsnPattern).OverridePropertyName(ParameterNaam).WithMessage(BsnPatternErrorMessage);
                  });
    }
}

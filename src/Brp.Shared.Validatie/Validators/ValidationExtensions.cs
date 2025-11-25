using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public static class ValidationExtensions
{
    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    private const string NotArrayErrorMessage = "array||Parameter is geen array.";
    
    public static IRuleBuilderOptions<JObject, JToken?> MustBeArray(this IRuleBuilder<JObject, JToken?> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotNull().OverridePropertyName(propertyName).WithMessage(RequiredErrorMessage)
            .When(x => x != null)
                .Must(x => x!.Type == JTokenType.Array).OverridePropertyName(propertyName).WithMessage(NotArrayErrorMessage);
    }
}
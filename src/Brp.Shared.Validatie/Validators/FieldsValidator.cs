using Brp.Shared.Infrastructure.Text;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class FieldsValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "fields";

    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string NotArrayErrorMessage = "array||Parameter is geen array.";
    const string MinItemsErrorMessage = "minItems||Array bevat minder dan {0} items.";
    const string MaxItemsErrorMessage = "maxItems||Array bevat meer dan {0} items.";
    const string FieldPattern = @"^[a-zA-Z0-9\._]{1,200}$";
    const string FieldPatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {FieldPattern}.";
    const string FieldExistErrorMessage = "fields||Parameter bevat een niet bestaande veldnaam.";
    const string FieldAllowedErrorMessage = "fields||Parameter bevat een niet toegestane veldnaam.";
    const string Wildcard = "*";

    public FieldsValidator(IEnumerable<string> fieldNames, IEnumerable<string> notAllowedFieldNames, int maxNumberFields)
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
                .Must(x => x!.Count <= maxNumberFields).OverridePropertyName(ParameterNaam).WithMessage(string.Format(MaxItemsErrorMessage, maxNumberFields));

            RuleForEach(x => x.Value<JArray>(ParameterNaam)!.Select(y => (string?)y))
                .SetValidator(new FieldValidator(fieldNames, notAllowedFieldNames))
                .When(x => x.Value<JArray>(ParameterNaam)!.Count > 0 && x.Value<JArray>(ParameterNaam)!.Count <= maxNumberFields)
                .OverridePropertyName(ParameterNaam);
        });
    }

    public class FieldValidator : AbstractValidator<string?>
    {
        public FieldValidator(IEnumerable<string> fieldNames, IEnumerable<string> notAllowedFieldNames)
        {
            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(x => x != null).WithMessage(RequiredErrorMessage)
                .Matches(FieldPattern).WithMessage(FieldPatternErrorMessage)
                .Must(x => !x.ContainsAny(notAllowedFieldNames)).WithMessage(FieldAllowedErrorMessage)
                .Must(x => IsExistingField(x, fieldNames)).WithMessage(FieldExistErrorMessage);
        }

        private static bool IsExistingField(string? field, IEnumerable<string> fieldNames) => MatchesExactOrWildcard(field, fieldNames);
        
        private static bool MatchesExactOrWildcard(string? x, IEnumerable<string> p) => x != null && p.Any(f => f.Equals(x) || f.EndsWith(Wildcard) && x.StartsWith(f[..^1]));
    }
}

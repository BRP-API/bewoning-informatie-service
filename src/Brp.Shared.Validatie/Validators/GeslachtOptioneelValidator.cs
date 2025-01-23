using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class GeslachtOptioneelValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "geslacht";

    const string GeslachtPattern = @"^([Mm]|[Vv]|[Oo])$";
    const string GeslachtPatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {GeslachtPattern}.";

    public GeslachtOptioneelValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Matches(GeslachtPattern).WithMessage(GeslachtPatternErrorMessage)
            .OverridePropertyName(ParameterNaam);
    }
}

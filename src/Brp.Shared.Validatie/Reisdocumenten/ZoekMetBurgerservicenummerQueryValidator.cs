using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Reisdocumenten;

public class ZoekMetBurgerservicenummerQueryValidator : AbstractValidator<JObject>
{

    public ZoekMetBurgerservicenummerQueryValidator()
    {
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new BurgerservicenummerValidator(true));
        Include(new FieldsValidator(Constanten.ReisdocumentFields, Constanten.NotAllowedReisdocumentFields, 25));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "burgerservicenummer",
        "fields"
    };
}

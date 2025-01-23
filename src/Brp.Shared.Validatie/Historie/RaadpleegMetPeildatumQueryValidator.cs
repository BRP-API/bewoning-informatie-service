using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Historie;

public class RaadpleegMetPeildatumQueryValidator : AbstractValidator<JObject>
{
    public RaadpleegMetPeildatumQueryValidator()
    {
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new BurgerservicenummerValidator(true));
        Include(new DatumValidator("peildatum", true));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "burgerservicenummer",
        "peildatum"
    };
}

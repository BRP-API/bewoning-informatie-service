using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Personen;

public class RaadpleegMetBurgerservicenummerQueryValidator : AbstractValidator<JObject>
{

    public RaadpleegMetBurgerservicenummerQueryValidator()
    {
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new BurgerservicenummerVerplichtCollectieValidator());
        Include(new GemeenteVanInschrijvingValidator());
        Include(new FieldsValidator(Constanten.PersoonFields, Constanten.NotAllowedPersoonFields, 130));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "burgerservicenummer",
        "fields",
        "gemeenteVanInschrijving"
    };
}

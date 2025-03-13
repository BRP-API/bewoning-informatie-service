using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Personen;

public class ZoekMetGeslachtsnaamEnGeboortedatumQueryValidator : AbstractValidator<JObject>
{
    public ZoekMetGeslachtsnaamEnGeboortedatumQueryValidator()
    {
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new DatumValidator(parameterNaam: "geboortedatum", isVerplichtVeld: true));
        Include(new GeslachtsnaamValidator(isVerplichtVeld: true));
        Include(new VoornamenValidator(isVerplichtVeld: false));
        Include(new VoorvoegselOptioneelValidator());
        Include(new GeslachtOptioneelValidator());
        Include(new InclusiefOverledenPersonenOptioneelValidator());
        Include(new GemeenteVanInschrijvingValidator());
        Include(new FieldsValidator(Constanten.PersoonBeperktFields, Constanten.NotAllowedPersoonFields, 130));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "geboortedatum",
        "geslachtsnaam",
        "voornamen",
        "voorvoegsel",
        "geslacht",
        "inclusiefOverledenPersonen",
        "gemeenteVanInschrijving",
        "fields"
    };
}

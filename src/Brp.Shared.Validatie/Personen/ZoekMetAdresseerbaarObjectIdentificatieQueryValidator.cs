using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Personen;

public class ZoekMetAdresseerbaarObjectIdentificatieQueryValidator : AbstractValidator<JObject>
{
    public ZoekMetAdresseerbaarObjectIdentificatieQueryValidator()
    {
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new AdresseerbaarObjectIdentificatieVerplichtValidator());
        Include(new InclusiefOverledenPersonenOptioneelValidator());
        Include(new GemeenteVanInschrijvingValidator());
        Include(new FieldsValidator(Constanten.GezagPersoonBeperktFields, Constanten.NotAllowedPersoonFields, 130));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "gemeenteVanInschrijving",
        "adresseerbaarObjectIdentificatie",
        "inclusiefOverledenPersonen",
        "fields"
    };
}

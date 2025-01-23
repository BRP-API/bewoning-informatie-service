using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Bewoningen;

public class BewoningMetPeriodeQueryValidator : AbstractValidator<JObject>
{
    public BewoningMetPeriodeQueryValidator()
    {
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new AdresseerbaarObjectIdentificatieVerplichtValidator());
        Include(new PeriodeValidator("datumVan", "datumTot"));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "adresseerbaarObjectIdentificatie",
        "datumVan",
        "datumTot"
    };
}

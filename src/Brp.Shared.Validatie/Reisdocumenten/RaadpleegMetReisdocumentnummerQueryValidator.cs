using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Reisdocumenten;

public class RaadpleegMetReisdocumentnummerQueryValidator : AbstractValidator<JObject>
{
    public RaadpleegMetReisdocumentnummerQueryValidator()
    {
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new ReisdocumentnummerCollectieValidator(true));
        Include(new FieldsValidator(Constanten.ReisdocumentFields, Constanten.NotAllowedReisdocumentFields, 25));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "reisdocumentnummer",
        "fields"
    };
}

using Brp.Shared.Validatie.Handlers;
using Brp.Shared.Validatie.Validators;
using FluentValidation.Results;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Reisdocumenten;

public class RequestBodyValidatieService : IRequestBodyValidator
{
    public ValidationResult ValidateRequestBody(string requestBody)
    {
        var input = JObject.Parse(requestBody);
        return input.Value<string>("type") switch
        {
            "ZoekMetBurgerservicenummer" => new ZoekMetBurgerservicenummerQueryValidator().Validate(input),
            "RaadpleegMetReisdocumentnummer" => new RaadpleegMetReisdocumentnummerQueryValidator().Validate(input),
            _ => new RequestBodyValidator(new string[] {
                "ZoekMetBurgerservicenummer",
                "RaadpleegMetReisdocumentnummer"
            }).Validate(input),
        };
    }
}

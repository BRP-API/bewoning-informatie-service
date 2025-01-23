using Brp.Shared.Validatie.Handlers;
using Brp.Shared.Validatie.Validators;
using FluentValidation.Results;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Bewoningen;

public class RequestBodyValidatieService : IRequestBodyValidator
{
    public ValidationResult ValidateRequestBody(string requestBody)
    {
        var input = JObject.Parse(requestBody);
        return input.Value<string>("type") switch
        {
            "BewoningMetPeildatum" => new BewoningMetPeildatumQueryValidator().Validate(input),
            "BewoningMetPeriode" => new BewoningMetPeriodeQueryValidator().Validate(input),
            _ => new RequestBodyValidator(new string[]
            {
                "BewoningMetPeildatum",
                "BewoningMetPeriode"
            }).Validate(input)
        };
    }
}

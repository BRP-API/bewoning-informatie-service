using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class NietGespecificeerdeParametersValidator : AbstractValidator<JObject>
{
    public NietGespecificeerdeParametersValidator(IEnumerable<string> gespecificeerdeParameterNamen)
    {
        RuleForEach(x => x.Properties()
                          .Where(x => !gespecificeerdeParameterNamen.Contains(x.Name))
                          .Select(p => new KeyValuePair<string, object>(System.Web.HttpUtility.HtmlEncode(p.Name), p.Value)))
            .SetValidator(new NietGespecificeerdeParameterValidator()).OverridePropertyName("MyProperty");
    }
}

public class NietGespecificeerdeParameterValidator : AbstractValidator<KeyValuePair<string, object>>
{
    public NietGespecificeerdeParameterValidator()
    {
        RuleFor(x => x.Key)
            .Null().WithMessage("{PropertyValue}||unknownParam||Parameter is niet verwacht.");
    }
}

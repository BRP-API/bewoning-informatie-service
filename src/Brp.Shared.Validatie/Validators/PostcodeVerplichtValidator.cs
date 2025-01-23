using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class PostcodeVerplichtValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "postcode";

    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string PostcodePattern = @"^[1-9]{1}[0-9]{3}[ ]?[A-Za-z]{2}$";
    const string PostcodeErrorMessage = $"pattern||Waarde voldoet niet aan patroon {PostcodePattern}.";

    public PostcodeVerplichtValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .Matches(PostcodePattern).WithMessage(PostcodeErrorMessage)
            .OverridePropertyName(ParameterNaam);
    }
}

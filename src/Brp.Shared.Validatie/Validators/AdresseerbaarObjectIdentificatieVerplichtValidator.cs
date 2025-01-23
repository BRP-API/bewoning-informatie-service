using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Validators;

public class AdresseerbaarObjectIdentificatieVerplichtValidator : AbstractValidator<JObject>
{
    private const string ParameterNaam = "adresseerbaarObjectIdentificatie";

    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string AdresseerbaarObjectIdentificatiePattern = @"^(?!0{16})[0-9]{16}$";
    const string AdresseerbaarObjectIdentificatiePatternErrorMessage = $"pattern||Waarde voldoet niet aan patroon {AdresseerbaarObjectIdentificatiePattern}.";

    public AdresseerbaarObjectIdentificatieVerplichtValidator()
    {
        RuleFor(x => x.Value<string>(ParameterNaam))
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
            .Matches(AdresseerbaarObjectIdentificatiePattern).WithMessage(AdresseerbaarObjectIdentificatiePatternErrorMessage)
            .OverridePropertyName(ParameterNaam);
    }
}

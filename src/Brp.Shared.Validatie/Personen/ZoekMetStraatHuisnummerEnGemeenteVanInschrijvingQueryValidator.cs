﻿using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Personen;

public class ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingQueryValidator : AbstractValidator<JObject>
{
    public ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingQueryValidator()
    {
        Include(new GemeenteVanInschrijvingValidator(isVerplichtVeld: true));
        Include(new HuisnummerVerplichtValidator());
        Include(new StraatVerplichtValidator());
        Include(new HuisletterValidator());
        Include(new HuisnummertoevoegingValidator());
        Include(new InclusiefOverledenPersonenOptioneelValidator());
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new FieldsValidator(Constanten.PersoonBeperktFields, Constanten.NotAllowedPersoonFields, 130));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "gemeenteVanInschrijving",
        "huisnummer",
        "huisletter",
        "huisnummertoevoeging",
        "straat",
        "inclusiefOverledenPersonen",
        "fields"
    };
}

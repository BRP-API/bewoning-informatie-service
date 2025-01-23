using Brp.Shared.Validatie.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Brp.Shared.Validatie;

public static class BuilderExtensions
{
    public static void SetupRequestValidation(this WebApplicationBuilder builder)
    {
        builder.SetupBewoningenRequestValidation();
        builder.SetupPersonenRequestValidation();
        builder.SetupReisdocumentenRequestValidation();
        builder.SetupVerblijfplaatshistorieRequestValidation();
    }

    public static void SetupBewoningenRequestValidation(this WebApplicationBuilder builder) =>
        builder.Services.AddKeyedTransient<IRequestBodyValidator, Bewoningen.RequestBodyValidatieService>("bewoningen");

    public static void SetupPersonenRequestValidation(this WebApplicationBuilder builder) =>
        builder.Services.AddKeyedTransient<IRequestBodyValidator, Personen.RequestBodyValidatieService>("personen");

    public static void SetupReisdocumentenRequestValidation(this WebApplicationBuilder builder) =>
        builder.Services.AddKeyedTransient<IRequestBodyValidator, Reisdocumenten.RequestBodyValidatieService>("reisdocumenten");

    public static void SetupVerblijfplaatshistorieRequestValidation(this WebApplicationBuilder builder) =>
        builder.Services.AddKeyedTransient<IRequestBodyValidator, Historie.RequestBodyValidatieService>("verblijfplaatshistorie");
}

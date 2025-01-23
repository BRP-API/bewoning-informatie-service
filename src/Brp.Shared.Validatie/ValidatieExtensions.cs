using Brp.Shared.Infrastructure.Http;
using Brp.Shared.Infrastructure.ProblemDetails;
using Brp.Shared.Infrastructure.Utils;
using Brp.Shared.Validatie.Handlers;
using Microsoft.AspNetCore.Http;

namespace Brp.Shared.Validatie;

public static class ValidatieExtensions
{
    public static async Task<bool> ValidateRequest(this HttpContext httpContext, IServiceProvider serviceProvider, string requestBody)
    {
        if (!await httpContext.HandleRequestMethodIsAllowed())
        {
            return false;
        }

        if (!await httpContext.HandleRequestAcceptIsSupported())
        {
            return false;
        }

        if (!await httpContext.HandleMediaTypeIsSupported())
        {
            return false;
        }

        IRequestBodyValidator? requestBodyValidator = serviceProvider.GetServiceForRequestedResource<IRequestBodyValidator>(httpContext.Request);
        if (requestBodyValidator == null)
        {
            await httpContext.Response.WriteProblemDetailsAsync(httpContext.Request.CreateProblemDetailsFor(StatusCodes.Status404NotFound));

            return false;
        }
        if (!await httpContext.HandleRequestBodyIsValidJson(requestBody, requestBodyValidator!))
        {
            return false;
        }

        return true;
    }
}

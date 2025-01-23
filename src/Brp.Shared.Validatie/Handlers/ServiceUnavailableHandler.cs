using Brp.Shared.Infrastructure.Http;
using Brp.Shared.Infrastructure.ProblemDetails;
using Microsoft.AspNetCore.Http;

namespace Brp.Shared.Validatie.Handlers;

public static class ServiceUnavailableHandler
{
    public static async ValueTask<bool> HandleServiceIsAvailable(this HttpContext context, Stream? orgBodyStream = null)
    {
        if (context.Response.StatusCode == StatusCodes.Status502BadGateway)
        {
            var problemDetails = context.Request.CreateProblemDetailsFor(StatusCodes.Status502BadGateway);

            if (orgBodyStream != null)
            {
                context.Response.Body = orgBodyStream;
            }
            await context.Response.WriteProblemDetailsAsync(problemDetails);

            return false;
        }

        return true;
    }
}

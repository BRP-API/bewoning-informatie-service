using Brp.Shared.Infrastructure.Http;
using Microsoft.AspNetCore.Http;

namespace Brp.Shared.Validatie.Middleware;

public class RequestValidatieMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;

    public RequestValidatieMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var requestBody = await httpContext.Request.ReadBodyAsync();

        if (!await httpContext.ValidateRequest(_serviceProvider, requestBody))
        {
            return;
        }

        await _next(httpContext);
    }
}

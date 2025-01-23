using AutoMapper;
using Bewoning.Informatie.Service.Helpers;
using Brp.Shared.Infrastructure.Http;
using Brp.Shared.Infrastructure.Stream;
using Brp.Shared.Validatie.Handlers;
using Serilog;

namespace Bewoning.Informatie.Service.Middlewares;

public class OverwriteResponseBodyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<OverwriteResponseBodyMiddleware> _logger;
    private readonly IMapper _mapper;
    private readonly IDiagnosticContext _diagnosticContext;

    public OverwriteResponseBodyMiddleware(RequestDelegate next, ILogger<OverwriteResponseBodyMiddleware> logger, IMapper mapper, IDiagnosticContext diagnosticContext)
    {
        _next = next;
        _logger = logger;
        _mapper = mapper;
        _diagnosticContext = diagnosticContext;
    }

    public async Task Invoke(HttpContext context)
    {
        var orgBodyStream = context.Response.Body;

        using var newBodyStream = new MemoryStream();
        context.Response.Body = newBodyStream;

        await _next(context);

        if (!await context.HandleNotFound(orgBodyStream))
        {
            return;
        }
        if (!await context.HandleServiceIsAvailable(orgBodyStream))
        {
            return;
        }

        var body = await context.Response.ReadBodyAsync();

        if (Log.IsEnabled(Serilog.Events.LogEventLevel.Debug))
        {
            _diagnosticContext.Set("original response headers", context.Response.Headers);
            _diagnosticContext.Set("original response body", Newtonsoft.Json.Linq.JObject.Parse(body), true);
        }

        var modifiedBody = context.Response.StatusCode == StatusCodes.Status200OK
            ? body.Transform(_mapper, _logger)
            : body;

        if (Log.IsEnabled(Serilog.Events.LogEventLevel.Debug))
        {
            _diagnosticContext.Set("modified response body", Newtonsoft.Json.Linq.JObject.Parse(modifiedBody), true);
        }

        using var bodyStream = modifiedBody.ToMemoryStream(context.Response.UseGzip());

        context.Response.ContentLength = bodyStream.Length;
        await bodyStream.CopyToAsync(orgBodyStream);
    }
}

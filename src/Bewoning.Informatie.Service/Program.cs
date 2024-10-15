using Bewoning.Informatie.Service.Middlewares;
using Brp.Shared.Infrastructure.HealthCheck;
using Brp.Shared.Infrastructure.Logging;
using Brp.Shared.Infrastructure.Utils;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

Log.Logger = SerilogHelpers.SetupSerilogBootstrapLogger();

try
{
    Log.Information("Starting {AppName} v{AppVersion}. TimeZone: {TimeZone}. Now: {TimeNow}",
                    AssemblyHelpers.Name, AssemblyHelpers.Version, TimeZoneInfo.Local.StandardName, DateTime.Now);

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHttpContextAccessor();

    builder.SetupSerilog(Log.Logger);

    builder.Configuration.AddJsonFile(Path.Combine("configuration", "ocelot.json"))
                         .AddJsonFile(Path.Combine("configuration", $"ocelot.{builder.Environment.EnvironmentName}.json"), true)
                         .AddEnvironmentVariables();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddOcelot();


    builder.Services.AddHealthChecks()
                    .AddOcelotDownstreamEndpointCheck(builder.Configuration);

    var app = builder.Build();


    app.SetupSerilogRequestLogging();

    app.UseRouting();

    app.SetupHealthCheckEndpoints(builder.Configuration, Log.Logger);

    app.UseEndpoints(e => e.MapControllers());

    app.UseMiddleware<OverwriteResponseBodyMiddleware>();

    app.UseOcelot().Wait();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "{AppName} terminated unexpectedly", AssemblyHelpers.Name);
}
finally
{
    Log.CloseAndFlush();
}

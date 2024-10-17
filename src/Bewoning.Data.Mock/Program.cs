using Serilog;
using Bewoning.Data.Mock.Repositories;
using Brp.Shared.Infrastructure.Logging;
using Brp.Shared.Infrastructure.Utils;

Log.Logger = SerilogHelpers.SetupSerilogBootstrapLogger();

try
{
    Log.Information("Starting {AppName} v{AppVersion}. TimeZone: {TimeZone}. Now: {TimeNow}",
                    AssemblyHelpers.Name, AssemblyHelpers.Version, TimeZoneInfo.Local.StandardName, DateTime.Now);

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHttpContextAccessor();

    builder.SetupSerilog(Log.Logger);

    builder.Services.AddControllers()
                    .AddNewtonsoftJson();

    _ = builder.Services.AddScoped<PersoonRepository>();

    var app = builder.Build();

    app.SetupSerilogRequestLogging();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "{AppName} terminated unexpectedly", AssemblyHelpers.Name);
}
finally
{
    Log.CloseAndFlush();
}

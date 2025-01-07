using Serilog;
using Bewoning.Data.Mock.Repositories;
using Brp.Shared.Infrastructure.Logging;
using Brp.Shared.Infrastructure.Utils;
using Bewoning.Informatie.Service.Middlewares;

Log.Logger = SerilogHelpers.SetupSerilogBootstrapLogger();

try
{
    Log.Information("Starting {AppName} v{AppVersion}. TimeZone: {TimeZone}. Now: {TimeNow}",
                    AssemblyHelpers.Name, AssemblyHelpers.Version, TimeZoneInfo.Local.StandardName, DateTime.Now);

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHttpContextAccessor();

    builder.SetupSerilog(Log.Logger);

    Brp.Shared.DtoMappers.SetupHelpers.AddBrpSharedDtoMappers();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers()
                    .AddNewtonsoftJson();

    _ = builder.Services.AddScoped<PersoonRepository>();

    var app = builder.Build();

    app.SetupSerilogRequestLogging();

    app.UseMiddleware<OverwriteResponseBodyMiddleware>();

    app.MapControllers();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "{AppName} terminated unexpectedly", AssemblyHelpers.Name);
}
finally
{
    await Log.CloseAndFlushAsync();
}

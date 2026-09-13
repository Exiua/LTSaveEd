using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LTSaveEd;
using LTSaveEd.Models;
using LTSaveEd.Models.JSWrappers;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .WriteTo.BrowserConsole()
            .CreateLogger();

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
builder.Services.AddMudServices();
builder.Services.AddSingleton<ApplicationState>();
builder.Services.AddSingleton<Settings>();
builder.Services.AddScoped<LocalStorageAccessor>();
builder.Services.AddScoped<FileHandler>();

builder.Logging.ClearProviders();
builder.Logging.AddProvider(
    new SerilogLoggerProvider(Log.Logger, dispose: true));

var host = builder.Build();

var localStorageAccessor = host.Services.GetRequiredService<LocalStorageAccessor>();
var settings = host.Services.GetRequiredService<Settings>();
await settings.InitializeAsync(localStorageAccessor);

await host.RunAsync();
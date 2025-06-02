using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LTSaveEd;
using LTSaveEd.Models;
using LTSaveEd.Models.JSWrappers;
using MudBlazor.Services;

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

var host = builder.Build();

var localStorageAccessor = host.Services.GetRequiredService<LocalStorageAccessor>();
var settings = host.Services.GetRequiredService<Settings>();
await settings.InitializeAsync(localStorageAccessor);

await host.RunAsync();
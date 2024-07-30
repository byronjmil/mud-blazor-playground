using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ThreeDiamonds;
using MudBlazor.Services;
using ThreeDiamonds.Service;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddScoped<IHttpService, HttpService>();
// In Program.cs (for Blazor WebAssembly)
builder.Services.AddSingleton<QRCodeService>();

await builder.Build().RunAsync();

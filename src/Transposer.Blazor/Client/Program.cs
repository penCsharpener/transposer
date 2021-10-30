using MediatR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Transposer.Blazor.Client;
using Transposer.Blazor.Shared.Extensions;
using Transposer.Blazor.Shared.Handlers.ChangeKey;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddMediatR(typeof(ChangeKeyResponse).Assembly);
builder.Services.AddSharedDependencies();

await builder.Build().RunAsync();

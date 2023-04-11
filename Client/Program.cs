using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnboardingBot.Client;
using MudBlazor.Services;
using OnboardingBot.Client.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var uri = new Uri(builder.HostEnvironment.BaseAddress);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = uri });
builder.Services.AddMudServices();

RefitProvider.AddRefitInterfaces(builder.Services, uri);

await builder.Build().RunAsync();
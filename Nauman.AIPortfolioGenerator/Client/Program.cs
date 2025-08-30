using Client;
using Client.Contracts;
using Client.Services;
using Client.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton(ILocalStorageService, LocalStorageService);
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProviderService>();
builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient<IClient, Client.Services.Base.Client>(sp =>
    sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
);

await builder.Build().RunAsync();

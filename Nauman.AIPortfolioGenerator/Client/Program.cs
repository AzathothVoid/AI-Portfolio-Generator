using Client;
using Client.Contracts;
using Client.Services;
using Client.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthenticationStateProviderService>();
builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient<IClient, Client.Services.Base.Client>((sp, http) =>
{
    var baseUrl = sp.GetRequiredService<IConfiguration>()
                    .GetValue<string>("ApiSettings:BaseUrl");
    http.BaseAddress = new Uri(baseUrl);
});

await builder.Build().RunAsync();
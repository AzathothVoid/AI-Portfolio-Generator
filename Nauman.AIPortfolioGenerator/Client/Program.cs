using Client;
using Client.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IClient, Client.Services.Base.Client>(sp =>
    sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
);

await builder.Build().RunAsync();

using Blazored.LocalStorage;
using TuetuTech.GestaoDeBilhetes.App.Auth;
using TuetuTech.GestaoDeBilhetes.App.Contracts;
using TuetuTech.GestaoDeBilhetes.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TuetuTech.GestaoDeBilhetes.App;
using TuetuTech.GestaoDeBilhetes.App.Services.Base;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri("https://localhost:7020")
});

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7020"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped<IEventDataService, EventDataService>();
builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
builder.Services.AddScoped<IOrderDataService, OrderDataService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
await builder.Build().RunAsync();

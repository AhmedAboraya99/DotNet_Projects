using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp1;
using BlazorApp1.Pages;
using BlazorApp1.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Implement API service dependency injection container using HttpClient
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5103/api") });
//Implement API service dependency injection container using HttpClient Factory
builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client =>  client.BaseAddress = new Uri("http://localhost:5103"));
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client =>  client.BaseAddress = new Uri("http://localhost:5103"));

await builder.Build().RunAsync();
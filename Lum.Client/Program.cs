using Lum.Client.Adapters;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TakasakiStudio.Lina.AutoDependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAutoDependencyInjection<ApiAdapter>();

await builder.Build().RunAsync();
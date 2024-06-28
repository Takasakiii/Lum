using Lum.Client.Adapters.Endpoints;
using Lum.Client.Adapters.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Client.Adapters;

[HttpClient<IApiAdapter>]
public class ApiAdapter : IApiAdapter
{
    public ApiAdapter(HttpClient httpClient, IWebAssemblyHostEnvironment hostEnvironment)
    {
        httpClient.BaseAddress = new Uri(hostEnvironment.BaseAddress);
        ApiEndpoints = RestService.For<IApiEndpoints>(httpClient);
    }
    
    public IApiEndpoints ApiEndpoints { get; }
}
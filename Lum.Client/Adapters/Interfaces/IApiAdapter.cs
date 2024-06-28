using Lum.Client.Adapters.Endpoints;

namespace Lum.Client.Adapters.Interfaces;

public interface IApiAdapter
{
    IApiEndpoints ApiEndpoints { get; }
}
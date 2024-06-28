using Lum.Shared.ViewModels.Internal;
using Refit;

namespace Lum.Client.Adapters.Endpoints;

public interface IApiEndpoints
{
    [Get("/api/recommend")]
    Task<IEnumerable<AnimeViewModel>> GetRecommends([Query] string username);
}
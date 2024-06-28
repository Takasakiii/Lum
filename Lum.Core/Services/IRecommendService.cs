using Lum.Shared.ViewModels.Internal;

namespace Lum.Core.Services;

public interface IRecommendService
{
    Task<IEnumerable<AnimeViewModel>> GetRecommend(string username);
}
using Lum.Shared.ViewModels.Internal;

namespace Lum.Core.Services;

public interface IRecommendService
{
    Task<IEnumerable<string>> GetRecommend(ICollection<AnimeViewModel> animes);
}
using Lum.Shared.ViewModels.Internal;

namespace Lum.Core.Services;

public interface IRecomendationService
{
    Task<string> GetRecomendation(ICollection<AnimeViewModel> animes);
}
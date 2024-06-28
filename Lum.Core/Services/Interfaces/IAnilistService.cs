using Lum.Shared.ViewModels.Internal;

namespace Lum.Core.Services.Interfaces;

public interface IAnilistService
{
    Task<ICollection<AnimeInUserListViewModel>> GetUserAnimes(string userName);
    Task<IEnumerable<AnimeViewModel>> GetAnimesInfo(IEnumerable<string> animesQuery);
}
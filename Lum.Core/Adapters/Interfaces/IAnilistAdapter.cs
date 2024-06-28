using Lum.Shared.ViewModels.AnilistGraphQl;

namespace Lum.Core.Adapters.Interfaces;

public interface IAnilistAdapter
{
    Task<DataMediaListViewModel?> GetUserAnimeList(string userName);
    Task<DataMediaViewModel?> GetAnimeInfo(string name);
    Task<IEnumerable<DataMediaViewModel>> GetAnimesInfo(IEnumerable<string> names);
}
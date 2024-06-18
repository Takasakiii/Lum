using Lum.Shared.ViewModels.AnilistGraphQl;

namespace Lum.Core.Adapters.Interfaces;

public interface IAnilistAdapter
{
    Task<DataViewModel?> GetUserAnimeList(string userName);
}
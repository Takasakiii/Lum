using Lum.Core.Adapters.Interfaces;
using Lum.Core.Services.Interfaces;
using Lum.Shared.ViewModels.Internal;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Core.Services;

[Service<IAnilistService>]
public class AnilistService(IAnilistAdapter anilistAdapter) : IAnilistService
{
    public async Task<ICollection<AnimeInUserListViewModel>> GetUserAnimes(string userName)
    {
        var response = await anilistAdapter.GetUserAnimeList(userName);
        if (response is null) return [];
        return response.MediaListCollection.Lists.SelectMany(x => x.IsSplitCompletedList)
            .Select(x => new AnimeInUserListViewModel(x.Media.Title.Romaji, x.Score)).ToArray();
    }

    public async Task<IEnumerable<AnimeViewModel>> GetAnimesInfo(IEnumerable<string> animesQuery)
    {
        var response = await anilistAdapter.GetAnimesInfo(animesQuery);
        return response.Select(x => x.Media)
            .Select(x => new AnimeViewModel(
                x.Id ?? 0, 
                x.IdMal ?? 0, 
                x.Title.Romaji,
                x.Genres ?? [], 
                x.Status ?? string.Empty, 
                x.Description ?? string.Empty)
            );
    }
}
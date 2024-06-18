using Lum.Core.Adapters.Interfaces;
using Lum.Core.Services.Interfaces;
using Lum.Shared.ViewModels.Internal;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Core.Services;

[Service<IAnilistService>]
public class AnilistService(IAnilistAdapter anilistAdapter) : IAnilistService
{
    public async Task<ICollection<AnimeViewModel>> GetUserAnimes(string userName)
    {
        var response = await anilistAdapter.GetUserAnimeList(userName);
        if (response is null) return [];
        return response.MediaListCollection.Lists.SelectMany(x => x.IsSplitCompletedList)
            .Select(x => new AnimeViewModel(x.Media.Title.Romaji, x.Score)).ToArray();
    }
}
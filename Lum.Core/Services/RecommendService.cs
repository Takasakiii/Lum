using System.Text;
using Lum.Core.Adapters.Interfaces;
using Lum.Shared.Enums;
using Lum.Shared.ViewModels.IA;
using Lum.Shared.ViewModels.Internal;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Core.Services;

[Service<IRecommendService>]
public class RecommendService(IGeminiAdapter geminiAdapter) : IRecommendService
{
    public async Task<IEnumerable<string>> GetRecommend(ICollection<AnimeViewModel> animes)
    {
        ConversationElementViewModel[] chat =
        [
            new ConversationElementViewModel(ChatActor.System,
                "I need you to suggest 10 new anime to a user based on the list of anime they have already watched, and they cannot under any circumstances already be on the user's list. Just respond with the names of the suggested anime in Romaji without formatting separated by a new line."),
            new ConversationElementViewModel(ChatActor.User, AnilistToStringPrompt(animes))
        ];

        var chatResponse = await geminiAdapter.SendToChat(chat);
        return FormatAnimeList(chatResponse);
    }

    private static string AnilistToStringPrompt(ICollection<AnimeViewModel> animes)
    {
        var builderString = new StringBuilder();
        foreach (var anime in animes)
        {
            builderString.Append(
                $"Anime: {anime.Name}{(anime.Score > 0 ? $" - Score: {anime.Score}" : string.Empty)}\n");
        }

        return builderString.ToString();
    }

    private static IEnumerable<string> FormatAnimeList(IEnumerable<ConversationElementViewModel> chat)
    {
        return (chat.LastOrDefault()?.Message ?? string.Empty).Split('\n').Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x));
    }
}
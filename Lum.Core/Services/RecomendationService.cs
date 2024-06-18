using System.Text;
using Lum.Core.Adapters.Interfaces;
using Lum.Shared.Utils;
using Lum.Shared.ViewModels.Internal;
using OpenAI.Chat;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace Lum.Core.Services;

[Service<IRecomendationService>]
public class RecomendationService(IChatGptAdapter chatGptAdapter) : IRecomendationService
{
    public async Task<string> GetRecomendation(ICollection<AnimeViewModel> animes)
    {
        ChatMessage[] chat =
        [
            new SystemChatMessage(
                "I need you to suggest a new anime to a user based on the list of anime they have already watched. Just respond with the name of the anime suggested in Romaji."),
            new UserChatMessage(AnilistToStringPrompt(animes))
        ];

        var chatResponse = await chatGptAdapter.SendToChat(chat);
        return chatResponse.Content[0].Text;
    }

    private static string AnilistToStringPrompt(ICollection<AnimeViewModel> animes)
    {
        var builderString = new StringBuilder();
        foreach (var anime in animes)
        {
            builderString.Append($"Anime: {anime.Name}{(anime.Score > 0 ? $" - Score: {anime.Score}" : string.Empty)}\n");
        }

        return builderString.ToString();
    }
}
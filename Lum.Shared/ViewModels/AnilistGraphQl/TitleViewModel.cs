using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record TitleViewModel(
    [property:JsonPropertyName("romaji")] string Romaji);
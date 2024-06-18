using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record MediaViewModel(
    [property:JsonPropertyName("title")] TitleViewModel Title);
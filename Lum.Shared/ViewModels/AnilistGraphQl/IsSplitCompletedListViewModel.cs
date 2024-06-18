using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record IsSplitCompletedListViewModel(
    [property:JsonPropertyName("media")] MediaViewModel Media,
    [property:JsonPropertyName("score")] byte Score);
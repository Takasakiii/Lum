using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record DataViewModel(
    [property: JsonPropertyName("MediaListCollection")]
    MediaListCollectionViewModel MediaListCollection);
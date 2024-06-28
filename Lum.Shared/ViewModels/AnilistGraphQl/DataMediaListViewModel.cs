using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record DataMediaListViewModel(
    [property: JsonPropertyName("MediaListCollection")]
    MediaListCollectionViewModel MediaListCollection);
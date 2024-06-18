using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record MediaListCollectionViewModel(
    [property:JsonPropertyName("lists")] ICollection<ListViewModel> Lists);
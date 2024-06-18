using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record ListViewModel(
    [property:JsonPropertyName("name")] string Name,
    [property:JsonPropertyName("isSplitCompletedList")] ICollection<IsSplitCompletedListViewModel> IsSplitCompletedList,
    [property:JsonPropertyName("status")] string Status);
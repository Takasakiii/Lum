using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record MediaViewModel(
    [property:JsonPropertyName("title")] TitleViewModel Title,
    [property:JsonPropertyName("id")] ulong? Id,
    [property:JsonPropertyName("idMal")] ulong? IdMal,
    [property:JsonPropertyName("genres")] ICollection<string> Genres,
    [property:JsonPropertyName("status")] string? Status,
    [property:JsonPropertyName("description")] string? Description);
using System.Text.Json.Serialization;

namespace Lum.Shared.ViewModels.AnilistGraphQl;

public record DataMediaViewModel(
    [property:JsonPropertyName("Media")] MediaViewModel Media);
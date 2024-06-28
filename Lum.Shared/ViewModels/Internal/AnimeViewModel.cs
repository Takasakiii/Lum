namespace Lum.Shared.ViewModels.Internal;

public record AnimeViewModel(
    ulong Id,
    ulong IdMal,
    string Title,
    ICollection<string> Genres,
    string Status,
    string Description);
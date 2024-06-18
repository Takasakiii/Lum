using Lum.Shared.ViewModels.Internal;

namespace Lum.Core.Services.Interfaces;

public interface IAnilistService
{
    Task<ICollection<AnimeViewModel>> GetUserAnimes(string userName);
}
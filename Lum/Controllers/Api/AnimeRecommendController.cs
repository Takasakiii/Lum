using Lum.Core.Services;
using Lum.Shared.Exceptions;
using Lum.Shared.ViewModels.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Lum.Controllers.Api;

[ApiController]
[Route("/api/recommend")]
public class AnimeRecommendController(IRecommendService recommendService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IEnumerable<AnimeViewModel>>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRecommendAnime([FromQuery] string username)
    {
        try
        {
            var animes = await recommendService.GetRecommend(username);
            return Ok(animes);
        }
        catch (AnilistUserNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
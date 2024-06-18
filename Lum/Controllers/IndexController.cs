using Lum.Core.Services;
using Lum.Core.Services.Interfaces;
using Lum.Pages;
using Lum.Shared.ViewModels.Forms;
using Microsoft.AspNetCore.Mvc;
using TakasakiStudio.Lina.AspNet.Controllers;

namespace Lum.Controllers;

[Controller]
[Route("/")]
public class IndexController(IRecomendationService recomendationService, IAnilistService anilistService) : PageController
{
    [HttpGet]
    public IActionResult GetIndex()
    {
        return RenderComponent<IndexPage>();
    }

    [HttpPost]
    public async Task<IActionResult> SubmitForm([FromForm] AnilistUsernameSearchViewModel form)
    {
        
        var animes = await anilistService.GetUserAnimes(form.Username);
        var recomendation = await recomendationService.GetRecomendation(animes);
        return Ok(recomendation);
    }
}
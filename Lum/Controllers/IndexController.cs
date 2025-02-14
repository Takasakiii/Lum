﻿using Lum.Core.Services;
using Lum.Pages;
using Lum.Shared.ViewModels.Forms;
using Microsoft.AspNetCore.Mvc;
using TakasakiStudio.Lina.AspNet.Controllers;

namespace Lum.Controllers;

[Controller]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("/")]
public class IndexController(IRecommendService recommendService) : PageController
{
    [HttpGet]
    public IActionResult GetIndex()
    {
        return RenderComponent<IndexPage>();
    }

    [HttpPost]
    public async Task<IActionResult> SubmitForm([FromForm] AnilistUsernameSearchViewModel form)
    {
        var r = await recommendService.GetRecommend(form.Username);
        return Ok(r);
    }
}
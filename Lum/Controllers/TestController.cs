using Lum.Pages;
using Microsoft.AspNetCore.Mvc;
using TakasakiStudio.Lina.AspNet.Controllers;

namespace Lum.Controllers;

[Controller]
[Route("test")]
[ApiExplorerSettings(IgnoreApi = true)]
public class TestController : PageController
{
    [HttpGet]
    public IActionResult GetIndex()
    {
        return RenderComponent<TestPage>();
    }
}
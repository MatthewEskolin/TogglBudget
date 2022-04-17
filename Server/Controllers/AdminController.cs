using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TogglTimeWeb.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        [Route("GetApiStatus")]
        public async Task<IActionResult> GetApiStatus()
        {
            await Task.CompletedTask;
            return Ok("API running");
        }

    }
}

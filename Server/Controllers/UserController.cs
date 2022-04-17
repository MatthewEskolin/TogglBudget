using Microsoft.AspNetCore.Mvc;
using TogglTimeWeb.API;
using TogglTimeWeb.Shared;

namespace TogglTimeWeb.Server.Controllers
{
    



    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserController()
        {
        }

        /// <summary>
        /// Gets a users data by id - currently hardcoded for my personal user data.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetUser")]
        //[HttpGet("{id}")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var togglClient = new TogglRestClient();
            var me = await togglClient.GetUserData();
            
            //project Me into UserData object
            var userData = new UserInfo(me);

            return Ok(userData);
            
        }

        [Route("GetUserReport")]
        public async Task<IActionResult> GetUserReport(List<Workspace> workspaces)
        {
            await Task.CompletedTask;

            var toggleClient = new TogglRestClient();

            return Ok();

            //query the Toggl API to get the weekly summary for the workspace

        }

        [Route("jsontest")]
        public async Task<IActionResult> GetJsonTest(List<Workspace> workspaces)
        {

            await Task.CompletedTask;
            return Ok(workspaces.Count);

        }

        [Route("testroute")]
        public async Task<IActionResult> TestRoute()
        {
            await Task.CompletedTask;
            return Ok("testroute");
        }

    }
}

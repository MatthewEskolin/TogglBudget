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
        [Route("api/usertest")]
        [HttpGet("{id}")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var togglClient = new TogglRestClient();
            var me = await togglClient.GetUserData();
            
            //project Me into UserData object
            var userData = new UserInfo(me);

            return Ok(userData);
            
        }

        [Route("api/userreport")]
        public async Task<IActionResult> GetUserReport(List<Workspace> workspaces)
        {
            var toggleClient = new TogglRestClient();

            return Ok();

            //query the Toggl API to get the weekly summary for the workspace

        }

        [Route("api/jsontest")]
        public async Task<IActionResult> GetJsonTest(List<Workspace> workspaces)
        {

            return Ok(workspaces.Count);

        }

        public async Task<IActionResult> TestRoute()
        {
            return Ok();
        }

    }
}

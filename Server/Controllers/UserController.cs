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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var togglClient = new TogglRestClient();
            var me = await togglClient.GetUserData();
            
            //project Me into UserData object
            var userData = new UserInfo(me);

            return Ok(userData);
            
        }

    }
}

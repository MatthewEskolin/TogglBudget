using Microsoft.AspNetCore.Mvc;
using TogglTimeWeb.API;
using TogglTimeWeb.API.Json;
using TogglTimeWeb.Shared;

namespace TogglTimeWeb.Server.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly TogglRestClient _togglClient;
        private readonly ILogger<UserController> _logger;

        public UserController(TogglRestClient togglClient, ILogger<UserController> logger)
        {
            this._logger = logger;
            this._togglClient = togglClient;
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
            //TODO add exception handler

            Me me = await _togglClient.GetUserData();
            
            //project Me into UserData object
            var userData = new UserInfo(me);

            return Ok(userData);
            
        }

        [Route("GetUserReport")]
        public async Task<IActionResult> GetUserReport(List<Workspace> workspaces)
        {
            //dictionary for associating a workspace ID with the report data.
            var dict = new Dictionary<string, ReportJson>();

            foreach (var workspace in workspaces)
            {
                var workspaceReport = await _togglClient.GetSummaryReport(workspace.id);

                //log hours in current workspace
                _logger.LogTrace($"Workspace ({workspace.name} - {workspace.id}) milliseconds = {workspaceReport.TotalGrand}");

                dict.Add(workspace.id.ToString(), workspaceReport);
            }

            var userReport = new UserReport(dict);

            return Ok(userReport);

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

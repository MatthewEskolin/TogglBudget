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

        public UserController(TogglRestClient togglClient)
        {
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
            var workspaceReports = new List<ReportJson>();

            foreach (var workspace in workspaces)
            {
                var workspaceReport = await _togglClient.GetSummaryReport();
                workspaceReports.Add(workspaceReport);
            }

           
            //Sum Totals from workspace report
            var grandTotal = workspaceReports.Select(x => x.TotalGrand).Sum();

            var userReport = new UserReport()
            {
                TotalTime = grandTotal
            };

            return Ok(userReport);

            //toggleClient.GetUserData()
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

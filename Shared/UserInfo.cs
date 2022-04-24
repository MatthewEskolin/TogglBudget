using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogglTimeWeb.API.Json;

namespace TogglTimeWeb.Shared
{
    public class JsonBase
    {
        public bool HasErrors { get; set; }
        public string ErrorText { get; set; } = null!;
    }


    /// <summary>
    /// User Info Class for our App - Starting with properties taken from Toggle Me class
    /// </summary>
    public class UserInfo:JsonBase
    {
        public UserInfo()
        {

            TogglWorkspaces = new List<TogglWorkspace>();
        }

        public UserInfo(Me me)
        {
            this.TogglWorkspaces = me.data.workspaces.Select(x => new TogglWorkspace()
            {
                id = x.id,
                name = x.name ?? null,
            }).ToList();
        }

        public List<TogglWorkspace> TogglWorkspaces { get; set; }
    }

    public class UserReport : JsonBase
    {
        /// <summary>
        /// Stores the ReportJson from each source workspace in the User Report
        /// Uses the workspace id as the key
        /// </summary>
        public Dictionary<string,ReportJson> ReportJsons { get; set; }

        public UserReport(Dictionary<string, ReportJson> reportJsons)
        {
            this.ReportJsons = reportJsons;

            //Sum Totals from workspace report
            var rjList = ReportJsons.Select(x => x.Value).ToList();
            var totalmilliseconds = rjList.Select(x => x.TotalGrand).Sum();

            this.TotalTime = totalmilliseconds;

        }

        public long TotalTime { get; set; }

    }

    public class TogglWorkspace
    {
        public int id { get; set; }
        public string? name { get; set; }

    }

}

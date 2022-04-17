using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class TogglWorkspace
    {
        public int id { get; set; }
        public string? name { get; set; }

    }

}

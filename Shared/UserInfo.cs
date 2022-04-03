using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglTimeWeb.Shared
{
    /// <summary>
    /// User Info Class for our App - Starting with properties taken from Toggle Me class
    /// </summary>
    public class UserInfo
    {
        public UserInfo()
        {
        }

        public UserInfo(Me me)
        {
            this.TogglWorkspaces = me.data.workspaces.Select(x => new TogglWorkspace()
            {
                id = x.id,
                name = x.name,
            }).ToList();
        }

        public List<TogglWorkspace> TogglWorkspaces { get; set; }
    }

    public class TogglWorkspace
    {
        public int id { get; set; }
        public string name { get; set; }

    }

}

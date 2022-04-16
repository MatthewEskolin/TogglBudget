using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglTimeWeb.Shared
{
    //May use this class for several variations of time reports
    //Firstly, we would like to use this to track Ellapsed Time by workspace
    public class TimeReport
    {
        //MultiWorkSpace Time Report
        public List<Workspace> Workspaces { get; set; }

        //Total Time Logged
        public TimeSpan TimeLogged { get; set; }


        public TimeReport()
        {
            Workspaces = new List<Workspace>();
        }

    }
}

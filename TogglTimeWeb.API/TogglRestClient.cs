using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TogglTimeWeb.API
{
    public class TogglRestClient
    {
        private readonly Uri _url;

        public TogglRestClient()
        {
            _url = new Uri("https://api.track.toggl.com/api/v8/");
        }


        //public Task<List<TimeEntryJson>> ListTimeEntries(DateTime start, DateTime end)
        //{
        //    var startDate = WebUtility.UrlEncode(start.ToUtc().ToString("o"));
        //    var endDate = WebUtility.UrlEncode(end.ToUtc().ToString("o"));

        //    var url = new Uri(_url, $"time_entries?start_date={startDate}&end_date={endDate}");
        //    return ListObjects<TimeEntryJson>(url);
        //}
    }
}

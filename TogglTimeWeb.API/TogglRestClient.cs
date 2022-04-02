using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TogglTimeWeb.API.Json;

namespace TogglTimeWeb.API
{
    public class TogglRestClient
    {
        private readonly Uri _url;
        private readonly Uri _reportsUrl;

        public TogglRestClient()
        {
            _url = new Uri("https://api.track.toggl.com/api/v8/");
            _reportsUrl = new Uri("https://api.track.toggl.com/reports/api/v2/");
        }



        public async Task<Me> GetUserData()
        {
            var method = "me";
            var url = new Uri(_url, method);

            var client = new RestClient();


            var request = new RestRequest(url)
            {
                Method = Method.Get
            };

            request.AddHeader("Authorization", "Basic MTMyOTBlNzIxOTcwMjI4ZjM4Y2ZlNjQ2M2JiNmIwZjM6YXBpX3Rva2Vu");

            //COOK calculate Authorization Header
            //AuthenticationHeaderValue getAuth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes( $"{"Token"}:api_token")));

            //use rest sharp to make the request

            var tokenSource = new CancellationTokenSource();
            var response = await client.ExecuteAsync(request, tokenSource.Token);

            var respData = response.Content;

            return JsonConvert.DeserializeObject<Me>(respData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })!;

        }

        //Create a method to calculate the elapsed time from the start of the week
        //This data is already captured in Reports so let's try to query it


        //public Task<List<TimeEntryJson>> ListTimeEntries(DateTime start, DateTime end)
        //{
        //    var startDate = WebUtility.UrlEncode(start.ToUtc().ToString("o"));
        //    var endDate = WebUtility.UrlEncode(end.ToUtc().ToString("o"));

        //    var url = new Uri(_url, $"weekly?since={startDate}&until={endDate}");
        //    return ListObjects<TimeEntryJson>(url);
        //}

        //private Task<List<T>> ListObjects<T>(Uri url)
        //    where T : CommonJson, new()
        //{
        //    return ListObjects<T>(url, CancellationToken.None);
        //}

        //public async Task CancellableMethod()
        //{
        //    var tokenSource = new CancellationTokenSource();
        //    // Queue some long running tasks
        //    for (int i = 0; i < 10; ++i)
        //    { 
        //         Task.Run(() => DoSomeWork(tokenSource.Token), tokenSource.Token);
        //    }

        //    // After some delay/when you want manual cancellation
        //    tokenSource.Cancel();
        //}

        //// Runs on a different thread
        //public async Task DoSomeWork(CancellationToken ct)
        //{
        //    int maxIterations = 100;
        //    for (int i = 0; i < maxIterations; ++i)
        //    {
        //        // Do some long running work

        //        if (ct.IsCancellationRequested)
        //        {
        //            Console.WriteLine("Task cancelled.");
        //            ct.ThrowIfCancellationRequested();
        //        }

        //    }
        //}


        //private async Task<List<T>> ListObjects<T>(Uri url, CancellationToken cancellationToken)
        //    where T : CommonJson, new()
        //{
        //    var client = new RestClient();
        //    var request = new RestRequest(url)
        //    {
        //        Method = Method.Get
        //    };

        //    request.AddHeader("Authorization", "Basic MTMyOTBlNzIxOTcwMjI4ZjM4Y2ZlNjQ2M2JiNmIwZjM6YXBpX3Rva2Vu");

        //    //COOK calculate Authorization Header
        //    //AuthenticationHeaderValue getAuth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes( $"{"Token"}:api_token")));

        //    //use rest sharp to make the request

        //    await client.ExecuteAsync(request, cancellationToken);

        //    var httpReq = SetupRequest(new HttpRequestMessage()
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = url,
        //    });

        //    var httpResp = await SendAsync(httpReq, cancellationToken)
        //        .ConfigureAwait(false);

        //    var respData = await httpResp.Content.ReadAsStringAsync()
        //        .ConfigureAwait(false);



        //    //public Task<List<TimeEntryJson>> ListTimeEntries(DateTime start, DateTime end)
        //    //{
        //    //    var startDate = WebUtility.UrlEncode(start.ToUtc().ToString("o"));
        //    //    var endDate = WebUtility.UrlEncode(end.ToUtc().ToString("o"));

        //    //    var url = new Uri(_url, $"time_entries?start_date={startDate}&end_date={endDate}");
        //    //    return ListObjects<TimeEntryJson>(url);
        //    //}
        //}
    }
}


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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

        //common methods
        protected RestClient GetRestClient()
        {
            var client = new RestClient();
            return client;
        }

        protected Uri GetAPIUri(string apiMethod)
        {
            var method = apiMethod;
            var url = new Uri(_url, apiMethod);
            return url;
        }

        protected Uri GetReportAPIUri(string apiMethod)
        {
            var method = apiMethod;
            var url = new Uri(_reportsUrl, apiMethod);
            return url;
        }

        /// <summary>
        /// Adds Authentication Header to new rest request
        /// </summary>
        /// <param name=""></param>
        /// <param name="method">RestSharp method</param>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected RestRequest NewRestRequest(RestSharp.Method method, Uri uri)
        {
            var request = new RestRequest(uri)
            {
                Method = method,
            };

            request.AddHeader("Authorization", "Basic MTMyOTBlNzIxOTcwMjI4ZjM4Y2ZlNjQ2M2JiNmIwZjM6YXBpX3Rva2Vu");
            request.AddParameter("user_agent", "TogglTimeWeb", ParameterType.QueryString);

            //COOK [Basic Authentication Auth Header, TogglAPI] Calculate Authorization Header
            //AuthenticationHeaderValue getAuth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes( $"{"Token"}:api_token")));

            return request;
        }


        public async Task<Me> GetUserData()
        {
            var client = GetRestClient();

            var uri = GetAPIUri("me");

            var request = NewRestRequest(Method.Get, uri);

            var response = await MakeRequest(client,request);

            var respData = response.Content;

            if (respData != null)
            {
                return JsonConvert.DeserializeObject<Me>(respData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })!;
            }
            else
            {
                //Log Error
                Debug.WriteLine("Error - failed to get user data");
                throw new Exception("Failed To Get User Data");
            }
        }

        public async Task<ReportJson> GetSummaryReport()
        {
            var client = GetRestClient();

            var uri = GetReportAPIUri("summary");

            var request = NewRestRequest(Method.Get, uri);

            var response = await MakeRequest(client, request);

            var respData = response.Content;

            if (respData != null)
            {
                return JsonConvert.DeserializeObject<ReportJson>(respData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })!;
            }
            else
            {
                //Log Error
                Debug.WriteLine("Error - failed to get user data");
                throw new Exception("Failed To Get User Data");
            }
        }

        private async Task<RestResponse> MakeRequest(RestClient restClient, RestRequest request)
        {
            var tokenSource = new CancellationTokenSource();
            var response = await restClient.ExecuteAsync(request, tokenSource.Token);
            return response;
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


using System.Diagnostics;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using TogglTimeWeb.Shared;

namespace TogglTimeWeb.Client.Pages.Dashboard
{
    public partial class Dashboard
    {
        public class DashboardOptions
        {
            public int WorkspaceID { get; set; }
        }


        protected UserInfo? Me { get; set; }
        [Inject] private HttpClient _client { get; set; }

        public int WorkSpaceID { get; set; } = 0;

        /* TODO_IDEA It would be cool if this was a live dashboard - and show if we were currently tracking after all this is blazor! */

        #region Time Span Properties
        /// <summary>
        /// Total Time that has Elapsed Since Last Monday as a string representation
        /// </summary>
        private string? ElapsedTime { get; set; }

        /// <summary>
        /// Total Time that has Elapsed Since last Monday
        /// </summary>
        private TimeSpan ElapsedTimeSpan { get; set; }

        /// <summary>
        /// Ellapsed Time as Percedntage of Weekly Time
        /// </summary>
        public double ElapsedTimeWidthPercent { get; set; }


        /// <summary>
        /// Time Remaining until next Monday 00:00 as a string representation
        /// </summary>
        private string? RemainingTime { get; set; }

        /// <summary>
        /// Time Remaining until next Monday 00:00
        /// </summary>
        private TimeSpan RemainingTimeSpan { get; set; }

        /// <summary>
        /// Remaining Time as Percentage of Weekly Time
        /// </summary>
        public double RemainingTimeWidthPercent { get; set; }



        /// <summary>
        /// Total Time that we have Logged in Toggl For this Week as a string representation
        /// </summary>
        private string? TimeLogged { get; set; }

        /// <summary>
        /// Total Time that we have Logged in Toggl For this Week as a string representation
        /// </summary>
        private TimeSpan TimeloggedSpan { get; set; }

        /// <summary>
        /// Total Time Logged as Percentage of Weekly Time
        /// </summary>
        private double TimeloggedWidthPercent { get; set; } = 80;


        #endregion



        public async Task<UserInfo?> LoadUserInfo()
        {
            //Load User Json
            var userInfo =  await  _client.GetFromJsonAsync<UserInfo>("api/usertest") ?? null;
            return userInfo;

        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            Console.WriteLine($"SetParametersAsync Starting");

            await base.SetParametersAsync(parameters);

            Console.WriteLine($"SetParametersAsync Ending");
        }

        protected  override async Task OnParametersSetAsync()
        {

            Console.WriteLine($"OnParametersSetAsync Starting");

            //load user data
            Me = await LoadUserInfo()!;

            //We should be able to perform async tasks here - unlike  in SetParametersAsync override where we were receiving error "the ParameterView instance can no longer be read"
            //Calculate TimeSpans
            ElapsedTimeSpan = CalculateElapsedTime();
            RemainingTimeSpan = CalculateRemainingTime();
            TimeloggedSpan = CalculateLoggedTime();

            //Format Time Spans into strings
            ElapsedTime = FormatTimeSpanForHours(ElapsedTimeSpan);
            RemainingTime = FormatTimeSpanForHours(RemainingTimeSpan);
            TimeLogged = FormatTimeSpanForHours(TimeloggedSpan);

            //The Ratio of Ellapsed Time / Total Time will show us how much of the week has passed.
            //We have already calculated the Elapsed Time,

            //One Week
            var minutesInOneWeek = TimeSpan.FromDays(7).TotalMinutes;
            var minutesEllapsed = ElapsedTimeSpan.TotalMinutes;

            var percentageEllapsed = minutesEllapsed / minutesInOneWeek;

            var progressWidthpercent = percentageEllapsed * 100;

            this.ElapsedTimeWidthPercent = progressWidthpercent;


            //One Week
            var measurementSpan = TimeSpan.FromDays(7);
            var percent = (RemainingTimeSpan.TotalSeconds / measurementSpan.TotalSeconds) * 100;
            RemainingTimeWidthPercent = percent;



            Console.WriteLine($"OnParametersSetAsync Ending");
        }

        private TimeSpan CalculateRemainingTime()
        {
            //Calculate Next Monday

            var dayofWeek = (int)System.DateTime.Now.DayOfWeek;

            int daysToMonday = dayofWeek switch
            {
                0 => 1,
                1 => 0,
                _ => 8 - dayofWeek
            };

            var nextMonday = System.DateTime.Now.AddDays(daysToMonday);

            nextMonday = nextMonday.Date;
            var currentDate = DateTime.Now;

            System.TimeSpan diff = nextMonday.Subtract(currentDate);

            return diff;




        }
        private TimeSpan CalculateLoggedTime()
        {
            return TimeSpan.FromDays(3);
        }
        private TimeSpan CalculateElapsedTime()
        {
            var dayofWeek = (int)System.DateTime.Now.DayOfWeek;
            int daysFromMonday = (dayofWeek == 0) ? 6 : dayofWeek - 1;

            var lastMonday = System.DateTime.Now.AddDays(-daysFromMonday);

            lastMonday = lastMonday.Date;

            var currentDate = DateTime.Now;

            System.TimeSpan diff = currentDate.Subtract(lastMonday);

            return diff;

        }




        /* Learning the LifeCycle - Keep this For Reference */
        protected override async  Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Delay(1);

            var first = firstRender ? "First" : "Non-First";
            Console.WriteLine($"After Render {first}");
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine($"OnInitialized Starting");

            await Task.Delay(1);

            Console.WriteLine($"OnInitializedAsync Done");
        }





        /// <summary>
        /// Formats a timespan into a string based on Hours
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        private static string? FormatTimeSpanForHours(TimeSpan span)
        {
            //Convert Days to Hours and display result in the format 342 H, 23 M -- exclude remaining seconds
            var hours = 0;
            var minutes = 0;

            hours = (int)Math.Floor(span.TotalHours);
            minutes = span.Minutes;

            return $"{hours} H, {minutes} M";
        }




    }
}

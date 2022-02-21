namespace TogglTimeWeb.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class DateTime
    {
        public void DateHelp()
        {
            var dayofWeek = (int)System.DateTime.Now.DayOfWeek;
            var daysFromMonday = dayofWeek - 1;

            System.DateTime.Now.AddDays(-daysFromMonday);

        }

    }

    public class TimeLimit
    {
        public int TimeLimitID { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public string Description { get; set; } 
        

    }
}
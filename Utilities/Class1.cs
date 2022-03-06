using System.Transactions;

namespace Utilities
{
    public class TimeSpanTools
    {
        public static string FormatTimeSpan(TimeSpan span)
        {

            if (span.TotalHours > 0)
            {
                var hours = Math.Floor(span.TotalHours);
                return $"{span.Hours} Hours, {span.Minutes}";
                
            }
            else if(span.TotalMinutes > 0)
            {
                var minutes = Math.Floor(span.TotalMinutes);
                return $"{span.Minutes} Minutes";
                //display minutes only
            }

            return "UNKNOWN";
        }

    }
}
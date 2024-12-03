namespace BabyCradle.Services
{
    public static class Time
    {
        public static DateTime ConvertTimeInEgyptToUTC(DateTime dateTime)   
        {
            //TimeZoneInfo egyptTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
            // var timeInUTC = TimeZoneInfo.ConvertTimeToUtc(dateTime, egyptTimeZone);
            var timeInUTC = dateTime - TimeSpan.FromHours(2);
            return timeInUTC;
        }
    }
}

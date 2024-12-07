namespace BabyCradle.Model
{
    public class Vaccination :NotificationItem, INotifiable 
    {
        public string VaccineName { get; set; } = string.Empty;

        public string Title { get; set; } = "Time for Your Baby Vaccination!";

        public TimeSpan? RemainingTime { get; set; }      


    }
}

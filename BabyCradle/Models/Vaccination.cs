namespace BabyCradle.Model
{
    public class Vaccination :NotificationItem, INotifiable 
    {
        public string VaccineName { get; set; } = string.Empty;

        public string Title { get; set; } = "Time for Your Baby Vaccination!";

        [Column(TypeName = "bigint")]
        public TimeSpan? RemainingTime { get; set; }      


    }
}

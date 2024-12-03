namespace BabyCradle.Model
{
    public class Vaccination :NotificationItem, INotifiable 
    {
        public string VaccineName { get; set; } = string.Empty;


    }
}

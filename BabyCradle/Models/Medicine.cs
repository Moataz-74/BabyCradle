namespace BabyCradle.Model
{
    public class Medicine:NotificationItem, INotifiable
    {
        public string MedicineName { get; set; } = string.Empty;
        public string Title { get; set; }= string.Empty;

    }
}

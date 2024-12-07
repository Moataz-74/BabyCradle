namespace BabyCradle.Models
{
    public class Note:NotificationItem, INotifiable
    {
        public string Title { get; set; } = string.Empty;

    }
}

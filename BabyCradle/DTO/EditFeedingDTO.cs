namespace BabyCradle.DTO
{
    public class EditFeedingDTO
    {
        public string? Content { get; set; }    
        [FutureDate]
        public DateTime NotificationTime { get; set; }
    }
}

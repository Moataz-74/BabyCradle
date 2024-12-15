namespace BabyCradle.DTO
{
    public class AddFeedingDTO
    {
     
        public string? Content { get; set; }    

        [FutureDate]
        public DateTime NotificationTime { get; set; }
    }
}

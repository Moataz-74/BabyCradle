namespace BabyCradle.DTO
{
    public class AddNoteDTO     
    {
        public string Title { get; set; } = string.Empty;
    
        public string? Content { get; set; } = string.Empty;
        public int ChildId { get; set; }

        [FutureDate]
        public DateTime NotificationTime { get; set; }

    }
}

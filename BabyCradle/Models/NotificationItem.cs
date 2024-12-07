namespace BabyCradle.Models
{
    public  class NotificationItem
    {
        public int Id { get; set; }
        
        public string Content { get; set; } = string.Empty;

        [FutureDate]
        public DateTime NotificationTime { get; set; }

        [ForeignKey("Child")]
        public int ChildId { get; set; }
        public Child? Child { get; set; }
    }

}

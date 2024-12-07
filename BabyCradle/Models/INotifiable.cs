namespace BabyCradle.Models
{
    public interface INotifiable
    {
        public int Id { get; set; }
       
        public string Content { get; set; } 

        [FutureDate]
        public DateTime NotificationTime { get; set; } 

        [ForeignKey("Child")]
        public int ChildId { get; set; }
        public Child? Child { get; set; }
    }
}

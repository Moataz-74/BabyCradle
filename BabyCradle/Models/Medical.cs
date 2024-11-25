namespace BabyCradle.Model
{
    public class Medical
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public DateTime Time { get; set; }
        public Child? Child { get; set; }
        [ForeignKey("Child")]
        public int ChildId { get; set; }    
    }
}

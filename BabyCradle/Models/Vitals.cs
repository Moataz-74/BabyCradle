namespace BabyCradle.Models
{
    public class Vitals
    {
        public int Id { get; set; }

        [ForeignKey("Child")]
        public int ChildId { get; set; }
        public DateTime Date { get; set; }
        public bool IsNormal { get; set; }
        public Child? Child { get; set; }
    }
}

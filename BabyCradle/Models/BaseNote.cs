namespace BabyCradle.Model
{
    public class BaseNote
    {
      public  int Id {  get; set; }
      public  string Note { get; set; } = string.Empty;
      public DateTime Time { get; set; }
       
        [ForeignKey("Child")]
      public  int ChildId { get; set; }
        public Child? Child { get; set; }
    }
}

namespace BabyCradle.Models
{
    public class Heart : Vitals
    {
        public const int MinimumRange = 60;
        public const int MiximumRange = 200;
        public int HeartRate { get; set; }  
    }
}

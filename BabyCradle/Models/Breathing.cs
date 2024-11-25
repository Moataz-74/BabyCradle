namespace BabyCradle.Models
{
    public class Breathing : Vitals
    {
        public const int MinimumRange = 20;
        public const int MiximumRange = 60;
        public int BreathingRate { get; set; }   
    }
}

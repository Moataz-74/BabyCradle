namespace BabyCradle.Models
{
    public class spO2 : Vitals
    {
        public const float MinimumRange = 0.9f;

        public const float MiximumRange = 1f;
        public float spO2Rate { get; set; } 
    }
}

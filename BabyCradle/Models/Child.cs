namespace BabyCradle.Model
{
    public class Child
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public  string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfbirth { get; set; }
        public ApplicationUser? User { get; set; }
        public List<Vaccination>? Vaccinations { get; set; }
        public List<Medicine>? Medicines { get; set; }
        public List<Feeding>? FeedingList { get; set; } 
        public List<Breathing>? BreathingList { get; set; }
        public List<Heart>? HeartList { get; set; }
        public List<spO2>? spO2List { get; set; }
        public List<Temprature>? TempratureList { get; set; }
    }
}

namespace BabyCradle.Models
{
    public class VaccinationTemplate
    {
        public int Id { get; set; }
        public string VaccineName { get; set; } = string.Empty;
        public string Information { get; set; } = string.Empty; // معلومات اللقاح

        [Column(TypeName = "bigint")]
        public TimeSpan IntervalAfterBirth { get; set; } // الفترة الزمنية بعد الولادة
    }
}

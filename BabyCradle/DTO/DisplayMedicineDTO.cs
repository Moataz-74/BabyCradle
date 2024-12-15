namespace BabyCradle.DTO
{
    public class DisplayMedicineDTO
    {
        public string MedicineName { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;

        [FutureDate]
        public DateTime NotificationTime { get; set; }
    }
}

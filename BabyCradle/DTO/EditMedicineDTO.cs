namespace BabyCradle.DTO
{
    public class EditMedicineDTO
    {
        public string MedicineName { get; set; } = string.Empty;
        public string? Content { get; set; }    

        [FutureDate]
        public DateTime NotificationTime { get; set; }
    }
}

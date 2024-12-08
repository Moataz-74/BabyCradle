public class VaccinationService
{
    private readonly ApplicationDbContext context;
    private readonly SendNotificationService sendNotificationService;

    public VaccinationService(ApplicationDbContext context , SendNotificationService sendNotificationService)
    {
       this.context = context;
        this.sendNotificationService = sendNotificationService;
    }

    public List<Vaccination> GenerateVaccinationSchedule(DateTime dateOfBirth, int childId)
    {
        var vaccinationTemplates = context.VaccinationTemplates.ToList();
        var vaccinations = new List<Vaccination>();

        foreach (var template in vaccinationTemplates)
        {
            var notificationTime = dateOfBirth + template.IntervalAfterBirth;
            var remainingTime = notificationTime - DateTime.Now;

            var vaccination = new Vaccination
            {
                VaccineName = template.VaccineName,
                Title = $"Time for {template.VaccineName}!",
                Content = template.Information,
                NotificationTime = notificationTime,
                RemainingTime = remainingTime > TimeSpan.Zero ? remainingTime : null,
                ChildId = childId
            };
            vaccinations.Add(vaccination);
        }
        return vaccinations;
    }

}

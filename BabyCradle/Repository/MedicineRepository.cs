namespace BabyCradle.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly SendNotificationService notificationService;
        private readonly PresentUserService presentUser;

        public MedicineRepository(ApplicationDbContext context, IMapper mapper, SendNotificationService notificationService, PresentUserService presentUser)
        {
            this.context = context;
            this.mapper = mapper;
            this.notificationService = notificationService;
            this.presentUser = presentUser;
        }

        public async Task AddMedicine(AddMedicineDTO medicineDTO)
        {
            var medicine = new Medicine();

            mapper.Map(medicineDTO, medicine);

            var childId = presentUser.GetIdForPresentChild();
            if (childId != 0)
            {
                medicine.ChildId = childId;
            }

            var duration = medicine.NotificationTime - DateTime.Now;
            medicine.NotificationTime = Time.ConvertTimeInEgyptToUTC(medicineDTO.NotificationTime);
            BackgroundJob.Schedule(() => notificationService.SendNotification(medicine), duration);
           

            await context.Medicines.AddAsync(medicine);
            await context.SaveChangesAsync();
        }

        public async Task EditMedicine(int id, EditMedicineDTO medicineDTO)
        {
            var medicine = context.Medicines.AsNoTracking().SingleOrDefault(m => m.Id == id);
            if (medicine != null)
            {
                mapper.Map(medicineDTO, medicine);
                medicine.Title = $"Remember the medicine time now :{medicineDTO.MedicineName}";
                context.Medicines.Update(medicine);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DisplayMedicineDTO>> GetAllMedicines()
        {
            var childId = presentUser.GetIdForPresentChild();
            var medicines =  await context.Medicines.AsNoTracking().Where(m => m.ChildId == childId).ToListAsync();
            var medicinesDTO = new List<DisplayMedicineDTO>();
            foreach (var medicne in medicines)
            {
                var medicneDTO = mapper.Map<DisplayMedicineDTO>(medicne);
                medicinesDTO.Add(medicneDTO);
            }
            return medicinesDTO;
        }

        public async Task<bool> MedicineExistsAsync(int id)
        {
            return await context.Medicines.AnyAsync(m => m.Id == id);
        }

        public async Task DeleteMedicine(int id)
        {
            var medicine = context.Medicines.AsNoTracking().SingleOrDefault(m => m.Id == id);
            if (medicine != null)
            {
                context.Medicines.Remove(medicine);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveMedicine(DateTime dateTime)
        {
            var medicines = context.Medicines.Where(m => m.NotificationTime == dateTime).ToList();
            context.Medicines.RemoveRange(medicines);
            Console.WriteLine("Medicine Removed");
            await context.SaveChangesAsync();
        }
    }
}

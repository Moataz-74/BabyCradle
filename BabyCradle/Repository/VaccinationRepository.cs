namespace BabyCradle.Repository
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly PresentUserService presentUserService;
        
        public VaccinationRepository(ApplicationDbContext context , PresentUserService presentUserService)
        {
            this.context = context;
            this.presentUserService = presentUserService;
        }
        
        public async Task<IEnumerable<Vaccination>> GetAllVaccinesForChild()
        {
            var childId = presentUserService.GetIdForPresentChild();
         return await context.Vaccinations.Where(v=>v.ChildId == childId).ToListAsync();

        }
    }
}

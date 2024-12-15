namespace BabyCradle.Repository
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly PresentUserService presentUserService;
        private readonly IMapper mapper;

        public VaccinationRepository(ApplicationDbContext context , PresentUserService presentUserService , IMapper mapper)
        {
            this.context = context;
            this.presentUserService = presentUserService;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<DisplayVaccineDTO>> GetAllVaccinesForChild()
        {
            var childId = presentUserService.GetIdForPresentChild();
         var vaccines =  await context.Vaccinations.Where(v=>v.ChildId == childId).ToListAsync();
            var VaccinesDTO = new List<DisplayVaccineDTO>();
            foreach (var vaccine  in vaccines)
            {
                var vaccineDTO = mapper.Map<DisplayVaccineDTO>(vaccine);
                if (vaccine.RemainingTime != null)
                {
                    vaccineDTO.Date = DateTime.Now + vaccine.RemainingTime.Value;
                }
                VaccinesDTO.Add(vaccineDTO);
            }
            return VaccinesDTO;

        }
    }
}

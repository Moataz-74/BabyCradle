namespace BabyCradle.Repository
{
    public class ChildRepository : IChildRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly PresentUserService presentUser;
        private readonly VaccinationService vaccinationService;

        public ChildRepository(ApplicationDbContext context ,IMapper mapper , PresentUserService presentUser , VaccinationService vaccinationService )
        {
            this.context = context;
            this.mapper = mapper;
            this.presentUser = presentUser;
            this.vaccinationService = vaccinationService;
        }
        public async Task AddChild(AddChildDTO childDTO)
        {
            var child = new Child();
            mapper.Map(childDTO, child);
            child.UserId = presentUser.GetIdForPresentUser();

            
           
            await context.Children.AddAsync(child);
            await context.SaveChangesAsync();
            var vaccinations = vaccinationService.GenerateVaccinationSchedule(childDTO.DateOfbirth, child.Id);
            await context.AddRangeAsync(vaccinations);
            await context.SaveChangesAsync();
        }

        public async Task EditChild(int id ,AddChildDTO childDTO)
        {
            var child = await context.Children.AsNoTracking().SingleOrDefaultAsync(c=>c.Id == id);
            if(child is not null)
            {
                mapper.Map(childDTO,child);
                context.Children.Update(child);
                await context.SaveChangesAsync();
                if (childDTO.DateOfbirth != child.DateOfbirth)
                {
                    var vaccinations = vaccinationService.GenerateVaccinationSchedule(childDTO.DateOfbirth, child.Id);
                    context.UpdateRange(vaccinations);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task<bool> ChildExistsAsync(int id)    
        {
            return await context.Children.AnyAsync(n => n.Id == id);
        }
    }
}

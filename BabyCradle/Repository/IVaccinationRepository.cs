namespace BabyCradle.Repository
{
    public interface IVaccinationRepository
    {
        public Task<IEnumerable<Vaccination>> GetAllVaccinesForChild();
    }
}

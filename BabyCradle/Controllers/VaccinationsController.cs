namespace BabyCradle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationsController : ControllerBase
    {
        private readonly IVaccinationRepository vaccinationRepository;

        public VaccinationsController(IVaccinationRepository vaccinationRepository)
        {
            this.vaccinationRepository = vaccinationRepository;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Vaccination>> GetAllVaccinesForChild()
        {
          var vaccines =  await vaccinationRepository.GetAllVaccinesForChild();

           return Ok(vaccines);
        }
        
        
    }
}

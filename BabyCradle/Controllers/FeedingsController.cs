namespace BabyCradle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingsController : ControllerBase
    {
        private readonly IFeedingRepository feedingRepository;

        public FeedingsController(IFeedingRepository feedingRepository)
        {
            this.feedingRepository = feedingRepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddFeeding(AddFeedingDTO feedingDTO)
        {
            if (ModelState.IsValid)
            {
                await feedingRepository.AddFeeding(feedingDTO);
                return Ok("Feeding Added");
            }
            return BadRequest("Invalid input");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayFeedingDTO>>> GetAllFeedings()
        {
            var feedings = await feedingRepository.GetAllFeedings();
            return feedings.ToList();
        }

        [Authorize]
        [HttpPut("EditFeeding/{id}")]
        public async Task<IActionResult> EditFeeding(int id, EditFeedingDTO editFeedingDTO)
        {
            if (ModelState.IsValid)
            {
                await feedingRepository.EditFeeding(id, editFeedingDTO);
                return Ok("Modified successfully");
            }
            return BadRequest("Invalid input");
        }

        [Authorize]
        [HttpDelete("DeleteFeeding/{id}")]
        public async Task<IActionResult> DeleteFeeding(int id)
        {
            await feedingRepository.DeleteFeeding(id);
            return Ok("Feeding deleted");
        }
    }
}

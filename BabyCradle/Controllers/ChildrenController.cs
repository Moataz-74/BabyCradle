namespace BabyCradle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildRepository childRepository;
        private readonly ChildService childService;

        public ChildrenController(IChildRepository childRepository , ChildService childService)
        {
            this.childRepository = childRepository;
            this.childService = childService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddChild(AddChildDTO childDTO)
        {
            if (ModelState.IsValid)
            {
              await  childRepository.AddChild(childDTO);
                return Ok("Done");
            }
            return BadRequest("invalid input");
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> EditChild(int id , AddChildDTO childDTO)
        {
            if (ModelState.IsValid)
            {
                await childService.EditChild(id, childDTO);
              return  Ok("child modified");
            }
            return BadRequest();
        }
    }
}

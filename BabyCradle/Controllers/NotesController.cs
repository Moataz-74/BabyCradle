namespace BabyCradle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteService noteService;
        private readonly INoteRepository noteRepository;
       

        public NotesController(NoteService noteService , INoteRepository noteRepository )
        {
            this.noteService = noteService;
            this.noteRepository = noteRepository;
            
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNote(AddNoteDTO noteDTO)
        {
            if (ModelState.IsValid)
            { 
                await noteRepository.AddNote(noteDTO);
                
                return Ok("Note Added");
            }
            return BadRequest("invalid input");
        }

        [Authorize,HttpGet]
        
        public async Task<ActionResult<IEnumerable<Note>>> GetAllNotes()
        {
            var notes = await noteRepository.GetAllNotes();
            return notes.ToList();
        }

        [Authorize]
        [HttpPut("EditNote/{id}")]
        public async Task<IActionResult> EditNote(int id ,EditNoteDTO editNoteDTO)
        {
            if (ModelState.IsValid)
            {
              await   noteService.EditNote (id, editNoteDTO);
                return Ok("Modified successfully");
            }
            return BadRequest();
        }
        [Authorize]
        [HttpDelete("DeleteNote/{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var result = await noteService.DeleteNoteAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
       
    }
}

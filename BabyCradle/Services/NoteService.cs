namespace BabyCradle.Services
{
    public class NoteService
    {
        private readonly INoteRepository _noteRepository;
        

        public NoteService(INoteRepository noteRepository )
        {
            _noteRepository = noteRepository;
            
        }
        
      
        public async Task<Result> EditNote (int id , EditNoteDTO note)
        {
            if (!await _noteRepository.NoteExistsAsync(id))
            {
                return Result.Failure("There is no note that has this ID.");
            }
            await _noteRepository.EditNote(id , note);
            return Result.Success("Note added Successfully.");
        }
        public async Task<Result> DeleteNoteAsync(int id)
        {
            // Check if the note exists
            if (!await _noteRepository.NoteExistsAsync(id))
            {
                return Result.Failure("There is no note that has this ID.");
            }

            // Delete the note
            await _noteRepository.DeleteNote(id);

            return Result.Success("Deleted successfully.");
        }
    }

}

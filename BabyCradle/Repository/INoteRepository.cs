namespace BabyCradle.Repository
{
    public interface INoteRepository
    {
        Task<bool> NoteExistsAsync(int id);
        public Task AddNote (AddNoteDTO note);

        public Task<IEnumerable<DisplayNoteDTO>> GetAllNotes ();
        public Task EditNote(int id ,EditNoteDTO note);
        public Task DeleteNote(int id);
    }
}

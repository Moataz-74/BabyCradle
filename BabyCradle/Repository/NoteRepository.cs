namespace BabyCradle.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly SendNotificationService notificationService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public NoteRepository(ApplicationDbContext context , IMapper mapper , SendNotificationService notificationService , IHttpContextAccessor httpContextAccessor )
        {
            this.context = context;
            this.mapper = mapper;
            this.notificationService = notificationService;
            this.httpContextAccessor = httpContextAccessor;
        }

        
        public async Task AddNote(AddNoteDTO noteDTO)
        {
            var note = new Note();
            
            mapper.Map(noteDTO, note);
            // الجزء ده عشان اعرفه خاصة ب انهي طفل
            var user = httpContextAccessor.HttpContext?.User;
            var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var child = await context.Children.Where(c=>c.UserId == userId).SingleOrDefaultAsync();
            if (child != null)
            {
                var childId = child.Id;
                note.ChildId = childId;
            }
            

            var duration = note.NotificationTime - DateTime.Now;
            note.NotificationTime = Time.ConvertTimeInEgyptToUTC(noteDTO.NotificationTime);
            BackgroundJob.Schedule(() => notificationService.SendNotification(note), duration);
            BackgroundJob.Schedule(() => RemoveNote(note.NotificationTime), duration);
            await context.Notes.AddAsync(note);
           await   context.SaveChangesAsync();
          
        }
        public async Task EditNote(int id ,EditNoteDTO noteDTO)   
        {
          var note = context.Notes.AsNoTracking().SingleOrDefault(x => x.Id == id);
            if (note != null)
            {
                mapper.Map(noteDTO, note);
                context.Notes.Update(note);
              await  context.SaveChangesAsync();
                
            }
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            var notes = await context.Notes.AsNoTracking().ToListAsync();
            return notes;
        }
        public async Task<bool> NoteExistsAsync(int id)
        {
            return await context.Notes.AnyAsync(n => n.Id == id);
        }
        public async Task DeleteNote(int id)
        {
            var note = context.Notes.AsNoTracking().SingleOrDefault(n => n.Id == id);
            if (note != null)

            {
                context.Notes.Remove(note);
                await context.SaveChangesAsync();
            }
            
        }
        public async Task RemoveNote (DateTime dateTime)
        {
            var notes = context.Notes.Where(n=>n.NotificationTime == dateTime).ToList();
            context.Notes.RemoveRange(notes);
            Console.WriteLine("Note Removed ");
            await context.SaveChangesAsync();
        }
          
        
    }
}

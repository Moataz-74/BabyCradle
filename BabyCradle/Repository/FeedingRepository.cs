namespace BabyCradle.Repository
{
    public class FeedingRepository : IFeedingRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly SendNotificationService notificationService;
        private readonly PresentUserService presentUser;

        public FeedingRepository(ApplicationDbContext context, IMapper mapper, SendNotificationService notificationService, PresentUserService presentUser)
        {
            this.context = context;
            this.mapper = mapper;
            this.notificationService = notificationService;
            this.presentUser = presentUser;
        }

        public async Task AddFeeding(AddFeedingDTO feedingDTO)
        {
            var feeding = new Feeding();

            mapper.Map(feedingDTO, feeding);

            var childId = presentUser.GetIdForPresentChild();
            if (childId != 0)
            {
                feeding.ChildId = childId;
            }

            var duration = feeding.NotificationTime - DateTime.Now;
            feeding.NotificationTime = Time.ConvertTimeInEgyptToUTC(feedingDTO.NotificationTime);
            BackgroundJob.Schedule(() => notificationService.SendNotification(feeding), duration);
            BackgroundJob.Schedule(() => RemoveFeeding(feeding.NotificationTime), duration);

            await context.Feedings.AddAsync(feeding);
            await context.SaveChangesAsync();
        }

        public async Task EditFeeding(int id, EditFeedingDTO feedingDTO)
        {
            var feeding = context.Feedings.AsNoTracking().SingleOrDefault(f => f.Id == id);
            if (feeding != null)
            {
                mapper.Map(feedingDTO, feeding);
                context.Feedings.Update(feeding);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Feeding>> GetAllFeedings()
        {
            var childId = presentUser.GetIdForPresentChild();
            return await context.Feedings.AsNoTracking().Where(f => f.ChildId == childId).ToListAsync();
        }

        public async Task<bool> FeedingExistsAsync(int id)
        {
            return await context.Feedings.AnyAsync(f => f.Id == id);
        }

        public async Task DeleteFeeding(int id)
        {
            var feeding = context.Feedings.AsNoTracking().SingleOrDefault(f => f.Id == id);
            if (feeding != null)
            {
                context.Feedings.Remove(feeding);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFeeding(DateTime dateTime)
        {
            var feedings = context.Feedings.Where(f => f.NotificationTime == dateTime).ToList();
            context.Feedings.RemoveRange(feedings);
            Console.WriteLine("Feeding Removed");
            await context.SaveChangesAsync();
        }
    }
}

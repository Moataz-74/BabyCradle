namespace BabyCradle.Repository
{
    public interface IFeedingRepository
    {
        Task<bool> FeedingExistsAsync(int id);

        Task AddFeeding(AddFeedingDTO feedingDTO);

        Task<IEnumerable<Feeding>> GetAllFeedings();

        Task EditFeeding(int id, EditFeedingDTO feedingDTO);

        Task DeleteFeeding(int id);
    }
}

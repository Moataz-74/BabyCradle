namespace BabyCradle.Repository
{
    public interface IChildRepository
    {
        public Task AddChild(AddChildDTO childDTO);
        public Task EditChild(int id , AddChildDTO childDTO);

        Task<bool> ChildExistsAsync(int id);    


    }

    
}

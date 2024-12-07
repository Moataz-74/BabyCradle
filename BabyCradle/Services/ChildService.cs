namespace BabyCradle.Services
{
    public class ChildService
    {
        private readonly IChildRepository childRepository;

        public ChildService(IChildRepository childRepository)
        {
            this.childRepository = childRepository;
        }

        public async Task<Result> EditChild(int id, AddChildDTO child)
        {

            if (!await childRepository.ChildExistsAsync(id))
            {
                return Result.Failure("There is no child that has this ID.");
            }
            await childRepository.EditChild(id, child);
            return Result.Success("child added Successfully.");
        }
    }
}

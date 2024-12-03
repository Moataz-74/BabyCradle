namespace BabyCradle.Map
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<AddNoteDTO, Note>();
            CreateMap<EditNoteDTO, Note>();

        }
    }
}

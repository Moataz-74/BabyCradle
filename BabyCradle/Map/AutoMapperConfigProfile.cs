namespace BabyCradle.Map
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<AddNoteDTO, Note>();
            CreateMap<EditNoteDTO, Note>();
            CreateMap<AddMedicineDTO, Medicine>();
            CreateMap<EditMedicineDTO, Medicine>();
            CreateMap<AddFeedingDTO, Feeding>();
            CreateMap<EditFeedingDTO, Feeding>();

            CreateMap<AddChildDTO, Child>();


        }
    }
}

namespace BabyCradle.DTO
{
    public class AddChildDTO
    {
        public string Name { get; set; } = string.Empty;

        [ChildAge]
        public DateTime DateOfbirth { get; set; } 
    }
}

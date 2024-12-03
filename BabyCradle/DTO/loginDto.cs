using System.ComponentModel.DataAnnotations;

namespace BabyCradle.DTO
{
    public class loginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

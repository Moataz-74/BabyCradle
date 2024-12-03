

using System.ComponentModel.DataAnnotations;

namespace BabyCradle.DTO
{
    public class RegisterDto
    {
       public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}

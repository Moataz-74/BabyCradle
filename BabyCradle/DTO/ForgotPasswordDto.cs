using System.ComponentModel.DataAnnotations;

namespace BabyCradle.DTO
{
    public class ForgotPasswordDto
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}

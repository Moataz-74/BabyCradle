using System.ComponentModel.DataAnnotations;

namespace BabyCradle.DTO
{
    public class VerifyCodeDto
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Code { get; set; }
    }
}

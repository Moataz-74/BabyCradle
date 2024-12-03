using System.ComponentModel.DataAnnotations;

namespace BabyCradle.DTO
{
    public class ResetPasswordDTO
    {
    
        public string Code { get; set; }

  
        [EmailAddress]
        public string Email { get; set; }

        
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}

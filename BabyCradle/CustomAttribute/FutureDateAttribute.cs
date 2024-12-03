namespace BabyCradle.CustomAttribute
{
     using System.ComponentModel.DataAnnotations;

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is DateTime dateValue)
                {
                    if (dateValue <= DateTime.Now) // التحقق من أن التاريخ في المستقبل
                    {
                        return new ValidationResult("The date must be in the future."); // رسالة خطأ
                    }
                }

                return ValidationResult.Success;
            }
            else { return new ValidationResult("value should not empty"); }
        }
    }

}

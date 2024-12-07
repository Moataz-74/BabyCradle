namespace BabyCradle.CustomAttribute
{
    using System.ComponentModel.DataAnnotations;
    public class ChildAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is DateTime dateValue)
                {
                    var now = DateTime.Now;
                    var age = now - dateValue;
                    if (age > TimeSpan.FromDays(365)) // التحقق من أن التاريخ في المستقبل
                    {
                        return new ValidationResult("This age is older than the allowed age."); // رسالة خطأ
                    }
                    else if (dateValue > now)
                    {
                        return new ValidationResult("invalid birthdate");

                    }

                }

                return ValidationResult.Success;
            }
            else { return new ValidationResult("value should not empty"); }
        }
    }
}

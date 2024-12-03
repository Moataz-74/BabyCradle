namespace BabyCradle.Repository
{
    public class GenerateVerificationCodeRepo : IGenerateVerificationCodeRepo
    {
        public string GenerateVerificationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();// Generates a 6-digit code
        }
    }
}

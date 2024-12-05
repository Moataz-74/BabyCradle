namespace BabyCradle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        //private readonly IMemoryCache _cache;
        //IGenerateVerificationCodeRepo generatecode;


        public AccountController(UserManager<ApplicationUser> UserManager, IConfiguration config /* IEmailSenderRepository emailSender*/ )/*, IMemoryCache cache, IGenerateVerificationCodeRepo generatecode)*/
        {
            userManager = UserManager;
            this.config = config;
            //this.emailSender = emailSender;
            //_cache = cache;
            //this.generatecode = generatecode;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto UserFromRequest)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = UserFromRequest.FullName;
                user.Email = UserFromRequest.Email;
                IdentityResult result =
                await userManager.CreateAsync(user, UserFromRequest.Password);
                if (result.Succeeded)
                {
                    return Ok("Created");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);
                }
            }
            return BadRequest(ModelState);




        }

        [HttpPost("login")]

        public async Task<IActionResult> login(loginDto userfromReq)
        {
            if (ModelState.IsValid)
            {
                //check

               var userfromDb =
                        await userManager.FindByEmailAsync(userfromReq.Email);

                if (userfromDb != null)
                {
                    bool found =
                    await userManager.CheckPasswordAsync(userfromDb, userfromReq.Password);
                    if (found == true)
                    {
                        //generate token

                        //payload
                        List<Claim> UserClaims = new List<Claim>();
                        //Token generated id change (jwt predefind Claims)    
                        UserClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));  //change token's id

                        UserClaims.Add(new Claim(ClaimTypes.NameIdentifier, userfromDb.Id));
                        UserClaims.Add(new Claim(ClaimTypes.Name, userfromDb.UserName));
                        var UserRoles = await userManager.GetRolesAsync(userfromDb);
                        foreach (var roleName in UserRoles)
                        {
                            UserClaims.Add(new Claim(ClaimTypes.Role, roleName));    //put each role in claim 
                        }
                        //Signature
                        var singinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecritKey"]));
                        SigningCredentials signingCred =
                            new SigningCredentials(singinkey, SecurityAlgorithms.HmacSha256);              //(key, alogorthims make encrypt)


                        //design token
                        JwtSecurityToken token = new JwtSecurityToken(

                           //header
                           audience: config["JWT:AudienceIP"],         //angular
                             issuer: config["JWT:IssuerIP"],
                             expires: DateTime.Now.AddHours(200),

                            //payload
                            claims: UserClaims,

                            //Signature
                            signingCredentials: signingCred
                             );

                        //generate token resopnse

                        return Ok(new
                        {

                            token = new JwtSecurityTokenHandler().WriteToken(token),   //transform token from 3 blocks to strings
                            expiration = DateTime.Now.AddHours(200)
                        });
                    }
                }
                ModelState.AddModelError("UserName", "UserName or Password not valid");

            }
            return BadRequest(ModelState);
        }

        ////ForgetPassword
        //[HttpPost("forgot-password")]
        //public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Do not reveal whether the email exists
        //        return Ok(new { Message = "If the email is registered, a code will be sent." });
        //    }

        //    // Generate a 6-digit code
        //    var code = generatecode.GenerateVerificationCode();

        //    // Store the code in memory cache with expiration (e.g., 5 minutes)
        //    _cache.Set(model.Email, code, TimeSpan.FromMinutes(5));

        //    // Send the code via email
        //    var subject = "Your Password Reset Code";
        //    var message = $"Your password reset code is: <strong>{code}</strong>";
        //    await emailSender.SendEmailAsync(model.Email, subject, message);

        //    return Ok(new { Message = "If the email is registered, a code will be sent." });
        //}

        ////Verify-code

        //[HttpPost("verify-code")]
        //public IActionResult VerifyCode([FromBody] VerifyCodeDto model)
        //{
        //    if (!_cache.TryGetValue(model.Email, out string storedCode))
        //    {
        //        return BadRequest(new { Message = "Code expired or invalid." });
        //    }

        //    if (storedCode != model.Code)
        //    {
        //        return BadRequest(new { Message = "Invalid code." });
        //    }

        //    return Ok(new { Message = "Code verified successfully." });
        //}

        //[HttpPost("reset-password")]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        //{
        //    if (!_cache.TryGetValue(model.Email, out string storedCode))
        //    {
        //        return BadRequest(new { Message = "Code expired or invalid." });
        //    }

        //    if (storedCode != model.Code)
        //    {
        //        return BadRequest(new { Message = "Invalid code." });
        //    }

        //    var user = await userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        return BadRequest(new { Message = "Invalid request." });
        //    }

        //    var result = await userManager.ResetPasswordAsync(user, await userManager.GeneratePasswordResetTokenAsync(user), model.NewPassword);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //    return Ok(new { Message = "Password reset successfully." });
        //}
    }
}






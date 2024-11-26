using BabyCradle.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BabyCradle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> UserManager, IConfiguration config)
        {
            userManager = UserManager;
            this.config = config;
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

                ApplicationUser userfromDb =
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
                             expires: DateTime.Now.AddHours(1),

                            //payload
                            claims: UserClaims,

                            //Signature
                            signingCredentials: signingCred
                             );

                        //generate token resopnse

                        return Ok(new
                        {

                            token = new JwtSecurityTokenHandler().WriteToken(token),   //transform token from 3 blocks to strings
                            expiration = DateTime.Now.AddHours(1)
                        });
                    }
                }
                ModelState.AddModelError("UserName", "UserName or Password not valid");

            }
            return BadRequest(ModelState);
        }
    }
}






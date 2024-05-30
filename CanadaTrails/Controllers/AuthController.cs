using CanadaTrails.CustomActionFilter;
using CanadaTrails.Models.DTO;
using CanadaTrails.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CanadaTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        //POST: /api/auth/register
        [HttpPost("register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if(identityResult.Succeeded)
            {
                //Add role to the user
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if(identityResult.Succeeded)
                {
                    return Ok("User created successfully");
                }
            }
            return BadRequest("Something went wrong");
        }

        //POST: /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var identityUser = await userManager.FindByNameAsync(loginRequestDto.Username);
           

            if(identityUser != null && await userManager.CheckPasswordAsync(identityUser, loginRequestDto.Password))
            {
                var roles = await userManager.GetRolesAsync(identityUser);
                if(roles != null || roles.Any())
                {
                    var token = tokenRepository.CreateToken(identityUser, roles.ToList());
                    var response = new LoginResponseDto
                    {
                        Token = token,
                        Username = identityUser.UserName,
                        Roles = roles.ToArray()
                    };
                    return Ok(response);
                }
                  
            }
            return BadRequest("Invalid login attempt");
        }
    }
}

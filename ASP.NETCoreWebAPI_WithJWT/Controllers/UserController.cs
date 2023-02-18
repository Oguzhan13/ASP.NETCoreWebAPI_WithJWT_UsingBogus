using ASP.NETCoreWebAPI_WithJWT.Models.Dtos;

namespace ASP.NETCoreWebAPI_WithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // if injection using in controller:
        //private readonly UserManager<User> _userManager;      //open field 
        //public UserController(UserManager<User> userManager)
        //{
        //    _userManager = userManager;
        //}
        private readonly IJwtService _jwtService;
        public UserController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        //only do injection for Create -> use [FromServices]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromServices] UserManager<User> userManager, RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User()
            {
                Email = registerDto.Email,
                EmailConfirmed = true,
                UserName = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };
            var createUserResult = await userManager.CreateAsync(user, registerDto.Password);
            if (!createUserResult.Succeeded)
            {
                return BadRequest(new AuthResult
                {
                    IsSuccess = false,
                });
            }
            var token = _jwtService.GetJwtToken(user);
            return Ok(new AuthResult
            {
                IsSuccess = true,
                Token = token
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromServices] SignInManager<User> signInManager, LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await signInManager.UserManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return BadRequest(new AuthResult
                { IsSuccess = false, });
            }
            var signInResult = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);    // Set false as an argument to prevent login and logout operations in method
            if (!signInResult.Succeeded)
            {
                return BadRequest(new AuthResult
                { IsSuccess = false });
            }
            var token = _jwtService.GetJwtToken(user);
            return Ok(new AuthResult
            {
                IsSuccess = true,
                Token = token
            });
        }
    }
}
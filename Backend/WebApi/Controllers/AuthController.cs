using AutoMapper;
using Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApi.ApiDtos.Auth;
using WebApi.ApiDtos.Categories;

namespace WebApi.Controllers
{
    /// <summary>
    /// Handles user authentication and registration,
    /// allows users to register, login, and handles token creation.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenRepository tokenRepository;

        /// <summary>
        /// Constructor to initialize AuthController with necessary dependencies.
        /// </summary>
        /// <param name="userManager">ASP.NET Core Identity UserManager to manage user accounts.</param>
        /// <param name="tokenRepository">Repository to handle JWT token generation.</param>
        public AuthController(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        /// <summary>
        /// Registers a new user with provided credentials. If it is the first user in the database, he gets admin role. 
        /// Subsequent registered people get user role. 
        /// </summary>
        /// <param name="registerRequest">Request object containing username, password, and roles.</param>
        /// <returns>Success message or error message if registration fails.</returns>
        /// <remarks>
        /// This endpoint creates a new user in the system and assigns roles. If registration or role assignment fails, 
        /// it returns appropriate error messages.
        /// </remarks>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var user = new ApplicationUser
            {
                UserName = registerRequest.Username,
                Nickname = registerRequest.Nickname,
                Email = registerRequest.Username
            };
            var identityResult = await userManager.CreateAsync(user, registerRequest.Password);
            if (!identityResult.Succeeded)
            {
                return BadRequest("Something went wrong");
            }
            if(userManager.Users.Count() == 1)
            {
                // the first user that we just created is admin
                identityResult = await userManager.AddToRolesAsync(user, new List<string>() { "Admin" });
            }

            identityResult = await userManager.AddToRolesAsync(user, new List<string>() { "User" });
            if (!identityResult.Succeeded)
            {
                return BadRequest("Something went wrong, couldnt asign roles to the user manager");
            }
            return Ok("User was registered, please log in");
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token if login is successful.
        /// </summary>
        /// <param name="loginRequest">Request object containing the user's credentials.</param>
        /// <returns>A JWT token or error message if login fails.</returns>
        /// <remarks>
        /// Validates the user's credentials and generates a JWT token for authorized access. 
        /// If the credentials are invalid, an error message is returned.
        /// </remarks>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.Username);
            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }
            var passwordValid = await userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!passwordValid)
            {
                return BadRequest("Invalid credentials");
            }
            // here we will create JWT token in the next lecture
            var roles = await userManager.GetRolesAsync(user);
            if (roles == null)
            {
                return BadRequest("No roles for the user");
            }
            var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
            var response = new LoginResponse
            {
                JwtToken = jwtToken
            };
            return Ok(response);
        }
    }
}

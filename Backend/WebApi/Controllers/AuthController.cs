using Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.Auth;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase {
		private readonly UserManager<ApplicationUser> userManager;
		private readonly ITokenRepository tokenRepository;

		public AuthController(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository) {
			this.userManager = userManager;
			this.tokenRepository = tokenRepository;
		}

		// POST /api/Auth/Register
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest) {
			var user = new ApplicationUser {
				UserName = registerRequest.Username,
				Email = registerRequest.Username
			};
			var identityResult = await userManager.CreateAsync(user, registerRequest.Password);
			if (!identityResult.Succeeded) {
				return BadRequest("Something went wrong");
			}
			if (registerRequest.Roles == null || !registerRequest.Roles.Any()) {
				return BadRequest("Something went wrong, you didnt provide role");
			}

			identityResult = await userManager.AddToRolesAsync(user, registerRequest.Roles);
			if (!identityResult.Succeeded) {
				return BadRequest("Something went wrong, couldnt asign roles to the user manager");
			}
			return Ok("User was registered, please log in");
		}
		// POST /api/Auth/Login
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest) {
			var user = await userManager.FindByEmailAsync(loginRequest.Username);
			if (user == null) {
				return BadRequest("Invalid credentials");
			}
			var passwordValid = await userManager.CheckPasswordAsync(user, loginRequest.Password);
			if (!passwordValid) {
				return BadRequest("Invalid credentials");
			}
			// here we will create JWT token in the next lecture
			var roles = await userManager.GetRolesAsync(user);
			if (roles == null) {
				return BadRequest("No roles for the user");
			}
			var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
			var response = new LoginResponse {
				JwtToken = jwtToken
			};
			return Ok(response);
		}
	}
}

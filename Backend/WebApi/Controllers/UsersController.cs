using AutoMapper;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public UsersController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The GUID of the user.</param>
        /// <returns>UserDto with basic info or 404 if not found.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();
            return Ok(mapper.Map<UserDto>(user));
        }

        [HttpGet("{id:guid}/detail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            var roles = await userManager.GetRolesAsync(user);
            var dto = mapper.Map<UserDetailDto>(user);
            dto.Roles = roles.ToList();
            return Ok(dto);
        }

        [HttpPost("{id:guid}/roles/admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdminRole(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            var result = await userManager.AddToRoleAsync(user, "Admin");
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var roles = await userManager.GetRolesAsync(user);
            var dto = mapper.Map<UserDetailDto>(user);
            dto.Roles = roles.ToList();
            return Ok(dto);
        }

        [HttpDelete("{id:guid}/roles/admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAdminRole(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            var result = await userManager.RemoveFromRoleAsync(user, "Admin");
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var roles = await userManager.GetRolesAsync(user);
            var dto = mapper.Map<UserDetailDto>(user);
            dto.Roles = roles.ToList();
            return Ok(dto);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            await userManager.DeleteAsync(user);
            return Ok(mapper.Map<UserDto>(user));
        }

    }
}


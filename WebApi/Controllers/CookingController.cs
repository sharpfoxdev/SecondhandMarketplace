using Application.Interfaces.Repositories;
using Domain.Entities.Listings.Cooking;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CookingController : ControllerBase {

		private readonly IListingRepository repository;

		public CookingController(IListingRepository repository) {
			this.repository = repository;
		}

		// GET: api/<CookingController>
		[HttpGet]
		public async Task<IActionResult> Get() {
			return Ok(await repository.GetAllAsync<Cooking>());
		}

		// GET api/<CookingController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id) {
			return Ok(await repository.GetByIdAsync<Cooking>(id));
		}

	}
}

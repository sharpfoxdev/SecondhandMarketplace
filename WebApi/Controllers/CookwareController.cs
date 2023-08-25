using Application.Interfaces.Repositories;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CookwareController : ControllerBase {
		private readonly IListingRepository repository;

		public CookwareController(IListingRepository repository) {
			this.repository = repository;
		}
		// GET: api/<StovesController>
		[HttpGet]
		public async Task<IActionResult> Get() {
			return Ok(await repository.GetAllAsync<Cookware>());
		}

		// GET api/<CookwareController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id) {
			return Ok(await repository.GetByIdAsync<Cookware>(id));
		}

		// POST api/<CookwareController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Cookware stove) {
			return Ok(await repository.CreateAsync(stove));
		}

		// PUT api/<CookwareController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] Cookware stove) {
			return Ok(await repository.UpdateAsync(id, stove));
		}

		// DELETE api/<CookwareController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
	
}

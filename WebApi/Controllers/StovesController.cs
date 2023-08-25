using Application.Interfaces.Repositories;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class StovesController : ControllerBase {
		private readonly IListingRepository repository;

		public StovesController(IListingRepository repository)
        {
			this.repository = repository;
		}
        // GET: api/<StovesController>
        [HttpGet]
		public async Task<IActionResult> Get() {
			return Ok(await repository.GetAllAsync<Stove>());
		}

		// GET api/<StovesController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id) {
			return Ok(await repository.GetByIdAsync<Stove>(id));
		}

		// POST api/<StovesController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Stove stove) {
			return Ok(await repository.CreateAsync(stove));
		}

		// PUT api/<StovesController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] Stove stove) {
			return Ok(await repository.UpdateAsync(id, stove));
		}

		// DELETE api/<StovesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}

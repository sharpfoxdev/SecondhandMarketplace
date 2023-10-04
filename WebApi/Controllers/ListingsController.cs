using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ListingsController : ControllerBase {
		private readonly IListingRepository repository;

		public ListingsController(IListingRepository repository)
        {
			this.repository = repository;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var result = await repository.GetAllAsync();
			return Ok(result);
			//return await Task.CompletedTask;
		}
		[HttpGet]
		[Route("id:Guid")]
		public async Task<IActionResult> GetById(Guid id) {
			throw new NotImplementedException();
		}
		[HttpPost]
		public async Task<IActionResult> Post() {
			throw new NotImplementedException();
		}
		[HttpPut]
		public async Task<IActionResult> Put() {
			throw new NotImplementedException();
		}
		[HttpDelete]
		[Route("id:Guid")]
		public async Task<IActionResult> Delete(Guid id) {
			throw new NotImplementedException();
		}

	}
}

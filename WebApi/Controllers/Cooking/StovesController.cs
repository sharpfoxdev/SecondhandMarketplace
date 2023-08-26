using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.Listings.CreateListing;
using WebApi.ApiDtos.Listings.ListingDtos;
using WebApi.ApiDtos.Listings.UpdateListing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class StovesController : BaseListingController {
		public StovesController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<StovesController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Stove, StoveDto>();
		}

		// GET api/<StovesController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Stove, StoveDto>(id);
		}

		// POST api/<StovesController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateStoveRequest requestDto) {
			return await GenericCreateAsync<Stove, StoveDto, CreateStoveRequest>(requestDto);
		}

		// PUT api/<StovesController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateStoveRequest requestDto) {
			return await GenericUpdateAsync<Stove, StoveDto, UpdateStoveRequest>(id, requestDto);
		}

		// DELETE api/<StovesController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<StoveDto>(id);
		}
	}
}

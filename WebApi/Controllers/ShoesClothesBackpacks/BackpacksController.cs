using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.Listings.CreateListing;
using WebApi.ApiDtos.Listings.ListingDtos;
using WebApi.ApiDtos.Listings.UpdateListing;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class BackpacksController : BaseListingController {
		public BackpacksController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<BackpacksController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Backpack, BackpackDto>();
		}

		// GET api/<BackpacksController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Backpack, BackpackDto>(id);
		}

		// POST api/<BackpacksController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateBackpackRequest requestDto) {
			return await GenericCreateAsync<Backpack, BackpackDto, CreateBackpackRequest>(requestDto);

		}

		// PUT api/<BackpacksController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateBackpackRequest requestDto) {
			return await GenericUpdateAsync<Backpack, BackpackDto, UpdateBackpackRequest>(id, requestDto);
		}

		// DELETE api/<BackpacksController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<BackpackDto>(id);
		}
	}
}

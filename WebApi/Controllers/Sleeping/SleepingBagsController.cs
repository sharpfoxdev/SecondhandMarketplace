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
	public class SleepingBagsController : BaseListingController {
		public SleepingBagsController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<SleepingBagsController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<SleepingBag, SleepingBagDto>();
		}

		// GET api/<SleepingBagsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<SleepingBag, SleepingBagDto>(id);
		}

		// POST api/<SleepingBagsController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateSleepingBagRequest requestDto) {
			return await GenericCreateAsync<SleepingBag, SleepingBagDto, CreateSleepingBagRequest>(requestDto);
		}

		// PUT api/<SleepingBagsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSleepingBagRequest requestDto) {
			return await GenericUpdateAsync<SleepingBag, SleepingBagDto, UpdateSleepingBagRequest>(id, requestDto);
		}

		// DELETE api/<SleepingBagsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<SleepingBagDto>(id);
		}
	}
}

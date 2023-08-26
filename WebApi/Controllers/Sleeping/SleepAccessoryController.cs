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
	public class SleepAccessoryController : BaseListingController {
		public SleepAccessoryController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<SleepAccessoryController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<SleepAccessory, SleepAccessoryDto>();
		}

		// GET api/<SleepAccessoryController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<SleepAccessory, SleepAccessoryDto>(id);
		}

		// POST api/<SleepAccessoryController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateSleepAccessoryRequest requestDto) {
			return await GenericCreateAsync<SleepAccessory, SleepAccessoryDto, CreateSleepAccessoryRequest>(requestDto);
		}

		// PUT api/<SleepAccessoryController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSleepAccessoryRequest requestDto) {
			return await GenericUpdateAsync<SleepAccessory, SleepAccessoryDto, UpdateSleepAccessoryRequest>(id, requestDto);
		}

		// DELETE api/<SleepAccessoryController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<SleepAccessoryDto>(id);
		}
	}
}

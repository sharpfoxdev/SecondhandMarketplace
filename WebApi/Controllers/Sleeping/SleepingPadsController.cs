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
	public class SleepingPadsController : BaseListingController {
		public SleepingPadsController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<SleepingPadsController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<SleepingPad, SleepingPadDto>();
		}

		// GET api/<SleepingPadsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<SleepingPad, SleepingPadDto>(id);
		}

		// POST api/<SleepingPadsController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateSleepingPadRequest requestDto) {
			return await GenericCreateAsync<SleepingPad, SleepingPadDto, CreateSleepingPadRequest>(requestDto);
		}

		// PUT api/<SleepingPadsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSleepingPadRequest requestDto) {
			return await GenericUpdateAsync<SleepingPad, SleepingPadDto, UpdateSleepingPadRequest>(id, requestDto);
		}

		// DELETE api/<SleepingPadsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<SleepingPadDto>(id);
		}
	}
}

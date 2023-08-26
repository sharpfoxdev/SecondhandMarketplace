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
	public class OtherSleepingController : BaseListingController {
		public OtherSleepingController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<OtherSleepingController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<OtherSleeping, OtherSleepingDto>();
		}

		// GET api/<OtherSleepingController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<OtherSleeping, OtherSleepingDto>(id);
		}

		// POST api/<OtherSleepingController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateOtherSleepingRequest requestDto) {
			return await GenericCreateAsync<OtherSleeping, OtherSleepingDto, CreateOtherSleepingRequest>(requestDto);
		}

		// PUT api/<OtherSleepingController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateOtherSleepingRequest requestDto) {
			return await GenericUpdateAsync<OtherSleeping, OtherSleepingDto, UpdateOtherSleepingRequest>(id, requestDto);
		}

		// DELETE api/<OtherSleepingController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<OtherSleepingDto>(id);
		}
	}
}

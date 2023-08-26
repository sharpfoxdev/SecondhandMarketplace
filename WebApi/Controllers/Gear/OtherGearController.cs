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
	public class OtherGearController : BaseListingController {
		public OtherGearController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<OtherGearController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<OtherGear, OtherGearDto>();
		}

		// GET api/<OtherGearController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<OtherGear, OtherGearDto>(id);
		}

		// POST api/<OtherGearController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateOtherGearRequest requestDto) {
			return await GenericCreateAsync<OtherGear, OtherGearDto, CreateOtherGearRequest>(requestDto);
		}

		// PUT api/<OtherGearController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateOtherGearRequest requestDto) {
			return await GenericUpdateAsync<OtherGear, OtherGearDto, UpdateOtherGearRequest>(id, requestDto);
		}

		// DELETE api/<OtherGearController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<OtherGearDto>(id);
		}
	}
}

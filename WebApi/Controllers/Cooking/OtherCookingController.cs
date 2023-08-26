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
	public class OtherCookingController : BaseListingController {
		public OtherCookingController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<OtherCookingController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<OtherCooking, OtherCookingDto>();
		}

		// GET api/<OtherCookingController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<OtherCooking, OtherCookingDto>(id);
		}

		// POST api/<OtherCookingController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateOtherCookingRequest requestDto) {
			return await GenericCreateAsync<OtherCooking, OtherCookingDto, CreateOtherCookingRequest>(requestDto);
		}

		// PUT api/<OtherCookingController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateOtherCookingRequest requestDto) {
			return await GenericUpdateAsync<OtherCooking, OtherCookingDto, UpdateOtherCookingRequest>(id, requestDto);
		}

		// DELETE api/<OtherCookingController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<OtherCookingDto>(id);
		}
	}
}

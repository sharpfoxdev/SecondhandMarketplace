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
	public class LightingController : BaseListingController {
		public LightingController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<LightingController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Lighting, LightingDto>();
		}

		// GET api/<LightingController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Lighting, LightingDto>(id);
		}

		// POST api/<LightingController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateLightingRequest requestDto) {
			return await GenericCreateAsync<Lighting, LightingDto, CreateLightingRequest>(requestDto);
		}

		// PUT api/<LightingController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateLightingRequest requestDto) {
			return await GenericUpdateAsync<Lighting, LightingDto, UpdateLightingRequest>(id, requestDto);
		}

		// DELETE api/<LightingController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<LightingDto>(id);
		}
	}
}

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
	public class BinocularsController : BaseListingController {
		public BinocularsController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<BinocularsController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Binoculars, BinocularsDto>();
		}

		// GET api/<BinocularsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Binoculars, BinocularsDto>(id);
		}

		// POST api/<BinocularsController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateBinocularsRequest requestDto) {
			return await GenericCreateAsync<Binoculars, BinocularsDto, CreateBinocularsRequest>(requestDto);
		}

		// PUT api/<BinocularsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateBinocularsRequest requestDto) {
			return await GenericUpdateAsync<Binoculars, BinocularsDto, UpdateBinocularsRequest>(id, requestDto);
		}

		// DELETE api/<BinocularsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<BinocularsDto>(id);
		}
	}
}

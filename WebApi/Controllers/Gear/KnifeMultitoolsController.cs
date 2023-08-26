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
	public class KnifeMultitoolsController : BaseListingController {
		public KnifeMultitoolsController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<KnifeMultitoolsController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<KnifeMultitool, KnifeMultitoolDto>();
		}

		// GET api/<KnifeMultitoolsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<KnifeMultitool, KnifeMultitoolDto>(id);
		}

		// POST api/<KnifeMultitoolsController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateKnifeMultitoolRequest requestDto) {
			return await GenericCreateAsync<KnifeMultitool, KnifeMultitoolDto, CreateKnifeMultitoolRequest>(requestDto);
		}

		// PUT api/<KnifeMultitoolsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateKnifeMultitoolRequest requestDto) {
			return await GenericUpdateAsync<KnifeMultitool, KnifeMultitoolDto, UpdateKnifeMultitoolRequest>(id, requestDto);
		}

		// DELETE api/<KnifeMultitoolsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<KnifeMultitoolDto>(id);
		}
	}
}

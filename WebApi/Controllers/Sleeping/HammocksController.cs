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
	public class HammocksController : BaseListingController {
		public HammocksController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<HammocksController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Hammock, HammockDto>();
		}

		// GET api/<HammocksController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Hammock, HammockDto>(id);
		}

		// POST api/<HammocksController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateHammockRequest requestDto) {
			return await GenericCreateAsync<Hammock, HammockDto, CreateHammockRequest>(requestDto);
		}

		// PUT api/<HammocksController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateHammockRequest requestDto) {
			return await GenericUpdateAsync<Hammock, HammockDto, UpdateHammockRequest>(id, requestDto);
		}

		// DELETE api/<HammocksController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<HammockDto>(id);
		}
	}
}

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
	public class TentsController : BaseListingController {
		public TentsController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<TentsController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Tent, TentDto>();
		}

		// GET api/<TentsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Tent, TentDto>(id);
		}

		// POST api/<TentsController>
		[HttpPost]
		public async Task<IActionResult> Post([FromForm] CreateTentRequest requestDto) {
			return await GenericCreateAsync<Tent, TentDto, CreateTentRequest>(requestDto);
		}

		// PUT api/<TentsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromForm] UpdateTentRequest requestDto) {
			return await GenericUpdateAsync<Tent, TentDto, UpdateTentRequest>(id, requestDto);
		}

		// DELETE api/<TentsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<TentDto>(id);
		}
	}
}

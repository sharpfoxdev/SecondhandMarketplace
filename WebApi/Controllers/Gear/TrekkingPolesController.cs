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
	public class TrekkingPolesController : BaseListingController {
		public TrekkingPolesController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<TrekkingPolesController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<TrekkingPole, TrekkingPoleDto>();
		}

		// GET api/<TrekkingPolesController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<TrekkingPole, TrekkingPoleDto>(id);
		}

		// POST api/<TrekkingPolesController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateTrekkingPoleRequest requestDto) {
			return await GenericCreateAsync<TrekkingPole, TrekkingPoleDto, CreateTrekkingPoleRequest>(requestDto);
		}

		// PUT api/<TrekkingPolesController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTrekkingPoleRequest requestDto) {
			return await GenericUpdateAsync<TrekkingPole, TrekkingPoleDto, UpdateTrekkingPoleRequest>(id, requestDto);
		}

		// DELETE api/<TrekkingPolesController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<TrekkingPoleDto>(id);
		}
	}
}

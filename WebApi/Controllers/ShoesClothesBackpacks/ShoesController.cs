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
	public class ShoesController : BaseListingController {
		public ShoesController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<ShoesController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Shoe, ShoeDto>();
		}

		// GET api/<ShoesController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Shoe, ShoeDto>(id);
		}

		// POST api/<ShoesController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateShoeRequest requestDto) {
			return await GenericCreateAsync<Shoe, ShoeDto, CreateShoeRequest>(requestDto);
		}

		// PUT api/<ShoesController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateShoeRequest requestDto) {
			return await GenericUpdateAsync<Shoe, ShoeDto, UpdateShoeRequest>(id, requestDto);
		}

		// DELETE api/<ShoesController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<ShoeDto>(id);
		}
	}
}

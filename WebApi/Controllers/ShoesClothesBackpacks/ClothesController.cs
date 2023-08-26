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
	public class ClothesController : BaseListingController {
		public ClothesController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<ClothesController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Clothes, ClothesDto>();
		}

		// GET api/<ClothesController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Clothes, ClothesDto>(id);
		}

		// POST api/<ClothesController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateClothesRequest requestDto) {
			return await GenericCreateAsync<Clothes, ClothesDto, CreateClothesRequest>(requestDto);
		}

		// PUT api/<ClothesController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateClothesRequest requestDto) {
			return await GenericUpdateAsync<Clothes, ClothesDto, UpdateClothesRequest>(id, requestDto);
		}

		// DELETE api/<ClothesController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<ClothesDto>(id);
		}
	}
}

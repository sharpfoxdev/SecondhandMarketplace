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
	public class ElectronicsController : BaseListingController {
		public ElectronicsController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<ElectronicsController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Electronics, ElectronicsDto>();
		}

		// GET api/<ElectronicsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Electronics, ElectronicsDto>(id);
		}

		// POST api/<ElectronicsController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateElectronicsRequest requestDto) {
			return await GenericCreateAsync<Electronics, ElectronicsDto, CreateElectronicsRequest>(requestDto);
		}

		// PUT api/<ElectronicsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateElectronicsRequest requestDto) {
			return await GenericUpdateAsync<Electronics, ElectronicsDto, UpdateElectronicsRequest>(id, requestDto);
		}

		// DELETE api/<ElectronicsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<ElectronicsDto>(id);
		}
	}
}

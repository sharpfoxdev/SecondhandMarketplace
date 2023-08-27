using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.ApiDtos.Listings.CreateListing;
using WebApi.ApiDtos.Listings.ListingDtos;
using WebApi.ApiDtos.Listings.UpdateListing;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class TarpsController : BaseListingController {
		public TarpsController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<TarpsController>
		[HttpGet]
		public async Task<IActionResult> GetAll([FromHeader(Name = "Auth-Token")] string jwt) {
			Console.WriteLine(jwt);
			return await GenericGetAllAsync<Tarp, TarpDto>();
		}

		// GET api/<TarpsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Tarp, TarpDto>(id);
		}

		// POST api/<TarpsController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateTarpRequest requestDto) {
			return await GenericCreateAsync<Tarp, TarpDto, CreateTarpRequest>(requestDto);
		}

		// PUT api/<TarpsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTarpRequest requestDto, [FromHeader(Name = "Auth-Token")] string jwt) {
			Console.WriteLine(jwt);
			return await GenericUpdateAsync<Tarp, TarpDto, UpdateTarpRequest>(id, requestDto);
		}

		// DELETE api/<TarpsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<TarpDto>(id);
		}
	}
}

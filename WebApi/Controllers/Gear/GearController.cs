using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.Listings.ListingDtos;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class GearController : BaseListingController {
		public GearController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<GearController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Gear, GearDto>();

		}

		// GET api/<GearController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Gear, GearDto>(id);
		}
	}
}

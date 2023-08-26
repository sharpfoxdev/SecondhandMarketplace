using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.Listings.ListingDtos;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class SleepingController : BaseListingController {
		public SleepingController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<SleepingController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Sleeping, SleepingDto>();

		}

		// GET api/<SleepingController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Sleeping, SleepingDto>(id);
		}
	}
}

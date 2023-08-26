using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.Listings.ListingDtos;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CampingListingsController : BaseListingController {
		public CampingListingsController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<CampingListingsController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<CampingListing, CampingListingDto>();

		}

		// GET api/<CampingListingsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<CampingListing, CampingListingDto>(id);
		}
	}
}

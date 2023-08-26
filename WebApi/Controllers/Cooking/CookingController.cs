using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApi.ApiDtos.Listings.ListingDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CookingController : BaseListingController {

		public CookingController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}
		// GET: api/<CookingController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Cooking, CookingDto>();

		}

		// GET api/<CookingController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Cooking, CookingDto>(id);
		}

	}
}

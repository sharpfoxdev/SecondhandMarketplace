using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings.Backpack;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.ListingsProperties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ListingPropertiesController : ControllerBase {
		private readonly IMapper _mapper;
		private readonly IListingPropertyRepository _repository;

		public ListingPropertiesController(IMapper mapper, IListingPropertyRepository repository)
        {
			this._mapper = mapper;
			this._repository = repository;
		}
        [HttpGet]
		[Route("/backpackbrand")]
		public async Task<IActionResult> GetAll() {
			var domain = await _repository.GetAllAsync<BackpackBrand>();
			return Ok(_mapper.Map<List<BackpackBrandDto>>(domain));
		}
		[HttpGet]
		[Route("/backpackbrand/{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await _repository.GetByIdAsync<BackpackBrand>(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(_mapper.Map<BackpackBrandDto>(domain));
		}

	}
}

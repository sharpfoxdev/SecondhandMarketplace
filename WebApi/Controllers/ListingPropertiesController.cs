using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
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
		// backpacks
		// BackpackBrand
        [HttpGet]
		[Route("BackpackBrand")]
		public async Task<IActionResult> BackpackBrandGetAll() {
			var domain = await _repository.GetAllAsync<BackpackBrand>();
			return Ok(_mapper.Map<List<BackpackBrandDto>>(domain));
		}
		[HttpGet]
		[Route("BackpackBrand/{id:Guid}")]
		public async Task<IActionResult> BackpackBrandGetById(Guid id) {
			var domain = await _repository.GetByIdAsync<BackpackBrand>(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(_mapper.Map<BackpackBrandDto>(domain));
		}
		// BackpackType
		[HttpGet]
		[Route("BackpackType")]
		public async Task<IActionResult> BackpackTypeGetAll() {
			var domain = await _repository.GetAllAsync<BackpackType>();
			return Ok(_mapper.Map<List<BackpackTypeDto>>(domain));
		}
		[HttpGet]
		[Route("BackpackType/{id:Guid}")]
		public async Task<IActionResult> BackpackTypeGetById(Guid id) {
			var domain = await _repository.GetByIdAsync<BackpackType>(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(_mapper.Map<BackpackTypeDto>(domain));
		}
	}
}

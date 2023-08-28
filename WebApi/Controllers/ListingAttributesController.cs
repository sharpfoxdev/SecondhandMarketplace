using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.ListingAttribute;

namespace WebApi.Controllers {
	[Route("api/Attributes")]
	[ApiController]
	public class ListingAttributesController : ControllerBase {
		private readonly IMapper mapper;
		private readonly IListingAttributeRepository repository;

		public ListingAttributesController(IMapper mapper, IListingAttributeRepository repository)
        {
			this.mapper = mapper;
			this.repository = repository;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<ListingAttributeDto>>(domain));
		}
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingAttributeDto>(domain));
		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateListingAttributeRequest request) {
			var domain = mapper.Map<ListingAttribute>(request);
			domain = await repository.CreateAsync(domain);
			return Ok(mapper.Map<ListingAttributeDto>(domain));
		}
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Put(Guid id, UpdateListingAttributeRequest request) {
			var domain = mapper.Map<ListingAttribute>(request);
			domain = await repository.UpdateAsync(id, domain);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingAttributeDto>(domain));
		}
		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingAttributeDto>(domain));
		}
	}
}

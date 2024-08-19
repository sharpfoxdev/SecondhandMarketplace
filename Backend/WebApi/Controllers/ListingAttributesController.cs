using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.ListingAttribute;

namespace WebApi.Controllers {
	/// <summary>
	/// Manages attributes, which are possible values of given attribute group.
	/// </summary>
	[Route("api/Attributes")]
	[ApiController]
	public class ListingAttributesController : ControllerBase {
		private readonly IMapper mapper;
		private readonly IListingPropertyValueRepository repository;

		public ListingAttributesController(IMapper mapper, IListingPropertyValueRepository repository)
        {
			this.mapper = mapper;
			this.repository = repository;
		}
		/// <summary>
		/// Lists all attributes regardles of the attribute group. 
		/// </summary>
		/// <returns>List of ListingAttributeDto </returns>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<ListingAttributeDto>>(domain));
		}
		/// <summary>
		/// Gets specified attribute. 
		/// </summary>
		/// <param name="id">Id of attribute</param>
		/// <returns>Requested attribute. </returns>
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingAttributeDto>(domain));
		}
		/// <summary>
		/// Adds a new attribute to the specified attribute group within CreateAttributeGroupRequest.
		/// </summary>
		/// <param name="request"></param>
		/// <returns>Created attribute. </returns>
		[HttpPost]
		public async Task<IActionResult> Post(CreateListingAttributeRequest request) {
			var domain = mapper.Map<ListingPropertyValue>(request);
			domain = await repository.CreateAsync(domain);
			return Ok(mapper.Map<ListingAttributeDto>(domain));
		}
		/// <summary>
		/// Updates specified attribute.
		/// TO CHECK should it be able to change the attribute group? Doesnt sound like a good idea, 
		/// it is better to delete the attribute and create a new one in a place we want. 
		/// 
		/// TO CHECK what happens, when a listing is using the attribute, that is being updated or deleted?
		/// Should be replaced with null in the listing. 
		/// </summary>
		/// <param name="id">Id of attribute to update. </param>
		/// <param name="request"></param>
		/// <returns>404 if id not found, else the updated attribute. </returns>
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Put(Guid id, UpdateListingAttributeRequest request) {
			var domain = mapper.Map<ListingPropertyValue>(request);
			domain = await repository.UpdateAsync(id, domain);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingAttributeDto>(domain));
		}
		/// <summary>
		/// Deletes specified attribute.
		/// TO CHECK what happens, when a listing is using the attribute, that is being updated or deleted?
		/// Should be replaced with null in the listing. 
		/// </summary>
		/// <param name="id">Id of attribute. </param>
		/// <returns>Deleted resource or 404 if id not found. </returns>
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

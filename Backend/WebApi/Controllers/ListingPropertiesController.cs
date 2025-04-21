using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.ListingProperties;
using WebApi.ApiDtos.ListingPropertyValues;

namespace WebApi.Controllers {

	/// <summary>
	/// Endpoints for manipulating ListingProperties
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ListingPropertiesController : ControllerBase {
		private readonly IListingPropertyRepository repository;
		private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of ListingPropertiesController.
        /// </summary>
        /// <param name="repository">Repository used to access listing property data.</param>
        /// <param name="mapper">Mapper used to convert between domain models and DTOs.</param>
        public ListingPropertiesController(IListingPropertyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Lists all listing properties in the database. 
        /// </summary>
        /// <returns>List of ListingPropertyDtos.</returns>
        [HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<ListingPropertyDetailDto>>(domain));
		}
		/// <summary>
		/// Gets a listing property by id and prints information about it. 
		/// </summary>
		/// <param name="id">Id of the listing property. </param>
		/// <returns>
		/// 404 if such id doesnt exist. Else it returns the
		/// requested ListingPropertyDto. 
		/// </returns>
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			if(domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingPropertyDetailDto>(domain));
		}
		/// <summary>
		/// Creates a new listing property. It is also possible to create new propertyValues witin it
		/// in this step. 
		/// </summary>
		/// <param name="request"></param>
		/// <returns>
		/// Created resource in a form of ListingPropertyDto. 
		/// </returns>
		[HttpPost]
		public async Task<IActionResult> Post(CreateListingPropertyRequest request) {
			var domain = mapper.Map<ListingProperty>(request);
			domain = await repository.CreateAsync(domain);
			return Ok(mapper.Map<ListingPropertyDto>(domain));
		}
		/// <summary>
		/// Updates information about the property. You cannot change the id. 
		/// TO CHECK: should I be able to change the category it is tied to? That would affect the listings,
		/// as they are tied to the categories as well and have to have matching propertyValues. So that
		/// sounds like a bad idea. Or can delete the matching propertyValues in the listings and in the
		/// listings, that use the new category add null as the matching attribute. Currently the 
		/// update request doesn't allow to change the category.
		/// </summary>
		/// <param name="id">Id of property to update. </param>
		/// <param name="request"></param>
		/// <returns>
		/// 404 if the property with given id is not found. 
		/// Else returns the updated ListingPropertyDto.
		/// </returns>
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Put(Guid id, UpdateListingPropertyRequest request) {
			var domain = mapper.Map<ListingProperty>(request);
			domain = await repository.UpdateAsync(id, domain);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingPropertyDto>(domain));
		}
		/// <summary>
		/// Deletes the given property and cascade deletes also all the propertyValues associated to it. 
		/// TO CHECK what happens in the listings, that use the values of this property
		/// </summary>
		/// <param name="id">Id of property to delete. </param>
		/// <returns>Deleted property or 404, when the id is not found. </returns>
		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingPropertyDto>(domain));
		}
		/// <summary>
		/// Adds list of values to the property. 
		/// </summary>
		/// <param name="id">Id of property to which we want to add values. </param>
		/// <param name="propertyValues">List of values to add. </param>
		/// <returns>
		/// Updated property with the added propertyValues. 
		/// 404 when the id of property is not found.
		/// </returns>
		[HttpPost]
		[Route("AddPropertyValues" +
			"/{id:Guid}")]
		public async Task<IActionResult> AddPropertyValues(Guid id, List<CreatePropertyValueInsidePropertyRequest> propertyValues) {
			var listAttrDomain = mapper.Map<List<ListingPropertyValue>>(propertyValues);
			var propertyDomain = await repository.AddListingPropertyValueAsync(id, listAttrDomain);
			if(propertyDomain == null) {
				// couldnt find the property
				return NotFound();
			}
			return Ok(mapper.Map<ListingPropertyDetailDto>(propertyDomain));
		}
	}
}

using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.ListingPropertyValues;

namespace WebApi.Controllers {
	/// <summary>
	/// Manages property values, which are possible values of given listing property.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ListingPropertyValuesController : ControllerBase {
		private readonly IMapper mapper;
		private readonly IListingPropertyValueRepository repository;
        /// <summary>
        /// Initializes a new instance of the ListingPropertyValuesController.
        /// </summary>
        /// <param name="mapper">Mapper instance used for converting between domain models and DTOs.</param>
        /// <param name="repository">Repository for accessing listing property values data.</param>
        public ListingPropertyValuesController(IMapper mapper, IListingPropertyValueRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        /// <summary>
        /// Lists all values regardles of the listing property. 
        /// </summary>
        /// <returns>List of ListingPropertyValueDto </returns>
        [HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<ListingPropertyValueDto>>(domain));
		}
		/// <summary>
		/// Gets specified value. 
		/// </summary>
		/// <param name="id">Id of value</param>
		/// <returns>Requested value. </returns>
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingPropertyValueDto>(domain));
		}
		/// <summary>
		/// Adds a new value to the specified listing property within CreateListingPropertyRequest.
		/// </summary>
		/// <param name="request"></param>
		/// <returns>Created value. </returns>
		[HttpPost]
		public async Task<IActionResult> Post(CreateListingPropertyValueRequest request) {
			var domain = mapper.Map<ListingPropertyValue>(request);
			domain = await repository.CreateAsync(domain);
			return Ok(mapper.Map<ListingPropertyValueDto>(domain));
		}
        /// <summary>
        /// Updates specified value.
        /// TO CHECK should it be able to change the listing property? Doesnt sound like a good idea, 
        /// it is better to delete the value and create a new one in a place we want. 
        /// 
        /// TO CHECK what happens, when a listing is using the value, that is being updated or deleted?
        /// Should be replaced with null in the listing. 
        /// </summary>
        /// <param name="id">Id of value to update. </param>
        /// <param name="request"></param>
        /// <returns>404 if id not found, else the updated value. </returns>
        [HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Put(Guid id, UpdateListingPropertyValueRequest request) {
			var domain = mapper.Map<ListingPropertyValue>(request);
			domain = await repository.UpdateAsync(id, domain);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingPropertyValueDto>(domain));
		}
        /// <summary>
        /// Deletes specified value.
        /// TO CHECK what happens, when a listing is using the value, that is being updated or deleted?
        /// Should be replaced with null in the listing. 
        /// </summary>
        /// <param name="id">Id of value. </param>
        /// <returns>Deleted resource or 404 if id not found. </returns>
        [HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingPropertyValueDto>(domain));
		}
	}
}

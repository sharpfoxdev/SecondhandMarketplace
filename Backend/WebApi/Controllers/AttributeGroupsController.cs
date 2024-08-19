using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.AttributeGroups;
using WebApi.ApiDtos.ListingAttribute;

namespace WebApi.Controllers {

	/// <summary>
	/// Endpoints for manipulating ListingProperties
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class AttributeGroupsController : ControllerBase {
		private readonly IListingPropertyRepository repository;
		private readonly IMapper mapper;

		public AttributeGroupsController(IListingPropertyRepository repository, IMapper mapper)
        {
			this.repository = repository;
			this.mapper = mapper;
		}
		/// <summary>
		/// Lists all attribute groups in the database. 
		/// </summary>
		/// <returns>List of AttributeGroupDtos.</returns>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<AttributeGroupDto>>(domain));
		}
		/// <summary>
		/// Gets an attribute group by id and prints information about it. 
		/// </summary>
		/// <param name="id">Id of the attribute group. </param>
		/// <returns>
		/// 404 if such id doesnt exist. Else it returns the
		/// requested AttributeGroupDto. 
		/// </returns>
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			if(domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<AttributeGroupDto>(domain));
		}
		/// <summary>
		/// Creates a new attribute group. It is also possible to create new attributes witin it
		/// in this step. 
		/// </summary>
		/// <param name="request"></param>
		/// <returns>
		/// Created resource in a form of AttributeGroupDto. 
		/// </returns>
		[HttpPost]
		public async Task<IActionResult> Post(CreateAttributeGroupRequest request) {
			var domain = mapper.Map<ListingProperty>(request);
			domain = await repository.CreateAsync(domain);
			return Ok(mapper.Map<AttributeGroupDto>(domain));
		}
		/// <summary>
		/// Updates information about the group. You cannot change the id. 
		/// TO CHECK: should I be able to change the category it is tied to? That would affect the listings,
		/// as they are tied to the categories as well and have to have matching attributes. So that
		/// sounds like a bad idea. Or can delete the matching attributes in the listings and in the
		/// listings, that use the new category add null as the matching attribute. Currently the 
		/// update request doesn't allow to change the category.
		/// </summary>
		/// <param name="id">Id of group to update. </param>
		/// <param name="request"></param>
		/// <returns>
		/// 404 if the group with given id is not found. 
		/// Else returns the updated AttributeGroupDto.
		/// </returns>
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Put(Guid id, UpdateAttributeGroupRequest request) {
			var domain = mapper.Map<ListingProperty>(request);
			domain = await repository.UpdateAsync(id, domain);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<AttributeGroupDto>(domain));
		}
		/// <summary>
		/// Deletes the given group and cascade deletes also all the attributes associated to it. 
		/// TO CHECK what happens in the listings, that use the attributes of this group
		/// </summary>
		/// <param name="id">Id of group to delete. </param>
		/// <returns>Deleted group or 404, when the id is not found. </returns>
		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<AttributeGroupDto>(domain));
		}
		/// <summary>
		/// Adds list of attributes to the group. 
		/// </summary>
		/// <param name="id">Id of group to which we want to add attributes. </param>
		/// <param name="attributes">List of attributes to add. </param>
		/// <returns>
		/// Updated group with the added attributes. 
		/// 404 when the id of group is not found.
		/// </returns>
		[HttpPost]
		[Route("AddAttributes/{id:Guid}")]
		public async Task<IActionResult> AddAttributes(Guid id, List<CreateListingAttributeInsideGroupRequest> attributes) {
			var listAttrDomain = mapper.Map<List<ListingPropertyValue>>(attributes);
			var groupDomain = await repository.AddListingPropertyValueAsync(id, listAttrDomain);
			if(groupDomain == null) {
				// couldnt find the group
				return NotFound();
			}
			return Ok(mapper.Map<AttributeGroupDto>(groupDomain));
		}
	}
}

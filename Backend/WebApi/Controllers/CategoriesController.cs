using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApi.ApiDtos.AttributeGroups;
using WebApi.ApiDtos.Categories;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase {
		private readonly ICategoryRepository repository;
		private readonly IMapper mapper;

		public CategoriesController(ICategoryRepository repository, IMapper mapper) {
			this.repository = repository;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<CategoryDto>>(domain));
		}
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			return Ok(mapper.Map<CategoryDto>(domain));
		}
		[HttpGet]
		[Route("{categoryName}")]
		public async Task<IActionResult> GetListingsByCategoryName(string categoryName) {
			var domain = await repository.GetListingsByCategoryNameAsync(categoryName);
			return Ok(mapper.Map<CategoryDto>(domain));
		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateCategoryRequest request) {
			var domain = mapper.Map<Category>(request);
			domain = await repository.CreateAsync(domain);
			return Ok(mapper.Map<CategoryDto>(domain));
		}
		/// <summary>
		/// Updates the category. It is not possible to change attribute groups tied to this category.
		/// For that use other endpoints. It currently is not supported to move category within the
		/// tree of categories, as that would mess up the listings and what attributes they should have
		/// </summary>
		/// <param name="id">Id of category to update</param>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Put(Guid id, UpdateCategoryRequest request) {
			var domain = mapper.Map<Category>(request);
			domain = await repository.UpdateAsync(id, domain);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<CategoryDto>(domain));
		}
		/// <summary>
		/// Adds attribute groups to the category. Recursivelly adds these
		/// attribute groups also to the sub categories. 
		/// </summary>
		/// <param name="id">Id of category to add groups to. </param>
		/// <param name="groupIds">List of ids of groups to add. </param>
		/// <returns>Updated category or 404, when the ids are not found. </returns>
		[HttpPut]
		[Route("AddGroups/{id:Guid}")]
		public async Task<IActionResult> AddGroups(Guid id, List<Guid> groupIds) {
			var domain = await repository.AddListingPropertiesAsync(id, groupIds);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<CategoryDto>(domain));
		}
		/// <summary>
		/// Removes attribute group from the category. Recursivelly removes these
		/// attribute groups also from sub categories. Also removes the group up to
		/// the highest parent, that has this group, to keep the data sane, 
		/// as this is one of the properties, that gets inherited in the tree of categories.
		/// So it would behave strangely, if suddenly parent would have some group and children
		/// wouldn't. 
		/// </summary>
		/// <param name="id">Id of category to add groups to. </param>
		/// <param name="groupIds">List of ids of groups to add. </param>
		/// <returns>Updated category or 404, when the ids are not found. </returns>
		[HttpPut]
		[Route("RemoveGroup/{id:Guid}")]
		public async Task<IActionResult> RemoveGroup(Guid id, Guid groupId) {
			var domain = await repository.RemoveListingPropertyAsync(id, groupId);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<CategoryDto>(domain));
		}
		/// <summary>
		/// Deletes the given category and cascade deletes also all subcategories.  
		/// It doesnt delete related groups tied to this category, as they are in many-to-many
		/// relationship. 
		/// </summary>
		/// <param name="id">Id of category to delete. </param>
		/// <returns>Deleted category or 404, when the id is not found. </returns>
		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<CategoryDto>(domain));
		}
	}
}

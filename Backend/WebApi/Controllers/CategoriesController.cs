using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApi.ApiDtos.ListingProperties;
using WebApi.ApiDtos.Categories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.ApiDtos.Listings;
using Application.Filters;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller for handling category-related operations.
    /// This includes creating, retrieving, and fetching listings by category name.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor for CategoriesController.
        /// </summary>
        /// <param name="repository">Repository for interacting with category data.</param>
        /// <param name="mapper">AutoMapper for mapping between domain models and DTOs.</param>
        public CategoriesController(ICategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>A list of all categories.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await repository.GetAllAsync();
            var mapped = mapper.Map<List<CategoryDto>>(domain);
            return Ok(mapped);
        }

        /// <summary>
        /// Retrieves a specific category by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The requested category, or a NotFound response if the category doesn't exist.</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var domain = await repository.GetByIdAsync(id);
            return Ok(mapper.Map<CategoryDto>(domain));
        }

        /// <summary>
        /// Retrieves listings associated with a specific category by its name.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        /// <returns>The listings in the requested category.</returns>
        [HttpPost]
        [Route("{categoryName}")]
        public async Task<IActionResult> GetListingsByCategoryName(string categoryName, ListingFilterDto filter)
        {
            var domainFilter = mapper.Map<ListingFilter>(filter);
            var domain = await repository.GetListingsByCategoryNameAsync(categoryName, domainFilter);
            return Ok(mapper.Map<List<ListingDto>>(domain));
        }
        [HttpGet]
        [Route("GetByName/{categoryName}")]
        public async Task<IActionResult> GetCategoryByCategoryName(string categoryName)
        {
            var domain = await repository.GetByNameAsync(categoryName);
            var mapped = mapper.Map<CategoryDto>(domain);
            return Ok(mapped);
        }
        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="request">Request object containing category details.</param>
        /// <returns>The created category.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryRequest request)
        {
            var domain = mapper.Map<Category>(request);
            domain = await repository.CreateAsync(domain);
            return Ok(mapper.Map<CategoryDto>(domain));
        }
        /// <summary>
        /// Updates the category. It is not possible to change listing properties tied to this category.
        /// For that use other endpoints. It currently is not supported to move category within the
        /// tree of categories, as that would mess up the listings and what property values they should have
        /// </summary>
        /// <param name="id">Id of category to update</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, UpdateCategoryRequest request)
        {
            var domain = mapper.Map<Category>(request);
            domain = await repository.UpdateAsync(id, domain);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CategoryDto>(domain));
        }
        /// <summary>
        /// Adds listing properties to the category. Recursivelly adds these
        /// listing properties also to the sub categories. 
        /// </summary>
        /// <param name="id">Id of category to add properties to. </param>
        /// <param name="request">Request with list of ids of properties to add. </param>
        /// <returns>Updated category or 404, when the ids are not found. </returns>
        [HttpPut]
        [Route("AddListingProperties/{id:Guid}")]
        public async Task<IActionResult> AddListingProperties(Guid id, AddListingPropertiesToCategoryRequest request)
        {
            var domain = await repository.AddListingPropertiesAsync(id, request.ListingPropertyIds);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CategoryDto>(domain));
        }
        /// <summary>
        /// Removes listing property from the category. Recursivelly removes these
        /// listing properties also from sub categories. Also removes the property up to
        /// the highest parent, that has this property, to keep the data sane, 
        /// as this is one of the properties, that gets inherited in the tree of categories.
        /// So it would behave strangely, if suddenly parent would have some property and children
        /// wouldn't. 
        /// </summary>
        /// <param name="id">Id of category to add property to. </param>
        /// <param name="request">Request with listing property to remove </param>
        /// <returns>Updated category or 404, when the ids are not found. </returns>
        [HttpPut]
        [Route("RemoveListingProperty/{id:Guid}")]
        public async Task<IActionResult> RemoveListingProperty(Guid id, RemoveListingPropertyFromCategoryRequest request)
        {
            var domain = await repository.RemoveListingPropertyAsync(id, request.Id);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CategoryDto>(domain));
        }
        /// <summary>
        /// Deletes the given category and cascade deletes also all subcategories.  
        /// It doesnt delete listing properties related tied to this category, as they are in many-to-many
        /// relationship. 
        /// </summary>
        /// <param name="id">Id of category to delete. </param>
        /// <returns>Deleted category or 404, when the id is not found. </returns>
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var domain = await repository.DeleteAsync(id);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CategoryDto>(domain));
        }
    }
}

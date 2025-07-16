using Application.Filters;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using AutoMapper;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.ApiDtos;
using WebApi.ApiDtos.ListingPropertyValues;
using WebApi.ApiDtos.Listings;

namespace WebApi.Controllers
{
    /// <summary>
    /// Manages the listings, including retrieval, creation, updating, and deletion of listings.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IListingRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of ListingsController
        /// </summary>
        /// <param name="repository">The repository for interacting with listing data.</param>
        /// <param name="mapper">Mapper instance to handle mapping between domain models and DTOs.</param>
        public ListingsController(IListingRepository repository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all listings. I am using post, because with get a cannot pass a filter in the body of request. 
        /// </summary>
        /// <returns>A list of all listings.</returns>
        [HttpPost]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] ListingFilterDto filter, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 12)
        {
            var filterDomain = mapper.Map<ListingFilter>(filter);
            var pagedDomain = await repository.GetAllAsync(filterDomain, pageNumber, pageSize);
            var dtoItems = mapper.Map<List<ListingDto>>(pagedDomain.Items);
            var result = new PageDto<ListingDto>
            {
                Items = dtoItems,
                TotalPages = pagedDomain.TotalPages,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a listing by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the listing.</param>
        /// <returns>The requested listing, or NotFound if the listing does not exist.</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var domain = await repository.GetByIdAsync(id);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ListingDetailDto>(domain));
        }
        /// <summary>
        /// User to get the listings owned by the user, that is signed in. 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetByUser")]
        [Authorize]
        public async Task<IActionResult> GetAllByUser()
        {
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = Guid.Parse(userIdString);
            var filter = new ListingFilter() { SellerId = userId};
            var domain = await repository.GetAllAsync(filter, 1, int.MaxValue);
            return Ok(mapper.Map<List<ListingDto>>(domain.Items));
        }
        /// <summary>
        /// Creates a new listing.
        /// </summary>
        /// <param name="request">The request object containing details of the listing to create.</param>
        /// <returns>The created listing.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(CreateListingRequest request)
        {
            var domain = mapper.Map<Listing>(request);
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = Guid.Parse(userIdString);
            domain.SellerId = userId;
            domain.CreatedAt = DateTime.Now;
            List<IListingPropertyValueSelection> interfaceListSelections = request.PropertyValueSelection.Cast<IListingPropertyValueSelection>().ToList();
            domain = await repository.CreateAsync(domain, interfaceListSelections);
            return Ok(mapper.Map<ListingDto>(domain));
        }

        /// <summary>
        /// Updates an existing listing by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the listing to update.</param>
        /// <param name="request">The request object containing updated listing details.</param>
        /// <returns>The updated listing, or NotFound if the listing does not exist.</returns>
        [Authorize]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, UpdateListingRequest request)
        {
            if (!await UserOwnsTheListing(id))
            {
                return Forbid();
            }
            var domain = mapper.Map<Listing>(request);
            domain = await repository.UpdateAsync(id, domain);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ListingDto>(domain));
        }

        /// <summary>
        /// Deletes a listing by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the listing to delete.</param>
        /// <returns>The deleted listing, or NotFound if the listing does not exist.</returns>
        [HttpDelete]
        [Authorize]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userOwnsListing = await UserOwnsTheListing(id);
            var userIsAdmin = await UserIsAdmin(id);
            if (!userOwnsListing && !userIsAdmin){
                return Forbid();
            }
            var domain = await repository.DeleteAsync(id);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ListingDto>(domain));
        }
        private async Task<bool> UserOwnsTheListing(Guid id) {
            var domain = await repository.GetByIdAsync(id);
            if (domain == null)
            {
                return false;
            }
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = Guid.Parse(userIdString);
            if (domain.SellerId != userId)
            {
                return false;
            }
            return true;
        }
        private async Task<bool> UserIsAdmin(Guid id)
        {
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByIdAsync(userIdString);
            var roles = await userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                return true;
            }
            return false;
        }
    }
}

using Application.Interfaces;
using Application.Interfaces.Repositories;
using AutoMapper;
using Azure.Core;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of ListingsController
        /// </summary>
        /// <param name="repository">The repository for interacting with listing data.</param>
        /// <param name="mapper">Mapper instance to handle mapping between domain models and DTOs.</param>
        public ListingsController(IListingRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all listings.
        /// </summary>
        /// <returns>A list of all listings.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await repository.GetAllAsync();
            return Ok(mapper.Map<List<ListingDto>>(domain));
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
        [Authorize]
        [HttpGet]
        [Route("GetByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var domain = await repository.GetAllAsync();
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = Guid.Parse(userIdString);
            var filtered = domain.Where(x => x.SellerId == userId).ToList();
            return Ok(mapper.Map<List<ListingDto>>(filtered));
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
            domain.CityId = Guid.Parse("0008c116-2243-4bed-9da7-67a7942da9e3");
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
            if (!await UserOwnsTheListing(id)){
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
    }
}

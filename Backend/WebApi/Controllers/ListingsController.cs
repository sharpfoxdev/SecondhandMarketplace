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

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ListingsController : ControllerBase {
		private readonly IListingRepository repository;
		private readonly IMapper mapper;

		public ListingsController(IListingRepository repository, IMapper mapper)
        {
			this.repository = repository;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<ListingDto>>(domain));
		}
		[HttpGet]
		[Route("id:Guid")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingDto>(domain));
		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateListingRequest request) {
			var domain = mapper.Map<Listing>(request);
			string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			Guid userId = Guid.Parse(userIdString);
			domain.SellerId = userId;
			// converting, because I cannot use interface directly in the API inside the request, as it cannot be deserialized
			List<IListingPropertyValueSelection> interfaceListSelections = request.PropertyValueSelection.Cast<IListingPropertyValueSelection>().ToList();
			domain = await repository.CreateAsync(domain, interfaceListSelections);
			return Ok(mapper.Map<ListingDto>(domain));
		}
		[HttpPut]
		public async Task<IActionResult> Put(Guid id, UpdateListingRequest request) {
			var domain = mapper.Map<Listing>(request);
			domain = await repository.UpdateAsync(id, domain);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingDto>(domain));
		}
		[HttpDelete]
		[Route("id:Guid")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ListingDto>(domain));
		}

	}
}

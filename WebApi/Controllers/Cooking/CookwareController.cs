using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using WebApi.ApiDtos.Listings.CreateListing;
using WebApi.ApiDtos.Listings.ListingDtos;
using WebApi.ApiDtos.Listings.UpdateListing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CookwareController : BaseListingController {
		public CookwareController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<CookwareController>
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			return await GenericGetAllAsync<Cookware, CookwareDto>();
		}

		// GET api/<CookwareController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id) {
			return await GenericGetByIdAsync<Cookware, CookwareDto>(id);
		}

		// POST api/<CookwareController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateCookwareRequest requestDto) {
			return await GenericCreateAsync<Cookware, CookwareDto, CreateCookwareRequest>(requestDto);
		}

		// PUT api/<CookwareController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCookwareRequest requestDto) {
			return await GenericUpdateAsync<Cookware, CookwareDto, UpdateCookwareRequest>(id, requestDto);
		}

		// DELETE api/<CookwareController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return await GenericDeleteAsync<CookwareDto>(id);
		}
	}
	
}

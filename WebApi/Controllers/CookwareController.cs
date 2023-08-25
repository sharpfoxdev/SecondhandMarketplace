using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using WebApi.ApiDtos.Listings.CreateListing;
using WebApi.ApiDtos.Listings.ListingDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CookwareController : BaseListingController {
		public CookwareController(IListingRepository repository, IMapper mapper) : base(repository, mapper) {
		}

		// GET: api/<StovesController>
		[HttpGet]
		public async Task<IActionResult> Get() {
			return await GenericGetAll<Cookware, CookwareDto>();
			//var domain = await _repository.GetAllAsync<Cookware>();
			//return Ok(_mapper.Map<List<CookwareListingDto>>(domain));
		}

		// GET api/<CookwareController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id) {
			return await GenericGetById<Cookware, CookwareDto>(id);
			//return Ok(await _repository.GetByIdAsync<Cookware>(id));
		}

		// POST api/<CookwareController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateCookwareRequest requestDto) {
			return await GenericCreate<Cookware, CookwareDto, CreateCookwareRequest>(requestDto);
			/*var domain = _mapper.Map<Cookware>(requestDto);
			domain = (Cookware)await _repository.CreateAsync(domain);
			return Ok(_mapper.Map<CookwareListingDto>(domain));*/
			//return Ok(await _repository.CreateAsync(stove));
		}

		// PUT api/<CookwareController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Guid id, [FromBody] Cookware stove) {
			return Ok(await _repository.UpdateAsync(id, stove));
		}

		// DELETE api/<CookwareController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
	
}

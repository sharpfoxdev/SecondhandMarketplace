using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.AttributeGroups;
using WebApi.ApiDtos.ListingAttribute;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AttributeGroupsController : ControllerBase {
		private readonly IAttributeGroupRepository repository;
		private readonly IMapper mapper;

		public AttributeGroupsController(IAttributeGroupRepository repository, IMapper mapper)
        {
			this.repository = repository;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<AttributeGroupDto>>(domain));
		}
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			if(domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<AttributeGroupDto>(domain));
		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateAttributeGroupRequest request) {
			var domain = mapper.Map<AttributeGroup>(request);
			domain = await repository.CreateAsync(domain);
			return Ok(mapper.Map<AttributeGroupDto>(domain));
		}
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Put(Guid id, UpdateAttributeGroupRequest request) {
			var domain = mapper.Map<AttributeGroup>(request);
			domain = await repository.UpdateAsync(id, domain);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<AttributeGroupDto>(domain));
		}
		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<AttributeGroupDto>(domain));
		}
		[HttpPost]
		[Route("AddAttributes/{id:Guid}")]
		public async Task<IActionResult> AddAttributes(Guid id, List<CreateListingAttributeInsideGroupRequest> attributes) {
			var listAttrDomain = mapper.Map<List<ListingAttribute>>(attributes);
			var groupDomain = await repository.AddAttributesAsync(id, listAttrDomain);
			if(groupDomain == null) {
				// couldnt find the group
				return NotFound();
			}
			return Ok(mapper.Map<AttributeGroupDto>(groupDomain));
		}
	}
}

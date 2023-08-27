using Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}

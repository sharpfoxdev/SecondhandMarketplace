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
			var result = await repository.GetAllAsync();
			return Ok(result);
		}
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var result = await repository.GetByIdAsync(id);
			return Ok(result);
		}
		[HttpGet]
		[Route("{CategoryName}")]
		public async Task<IActionResult> GetListingsByCategoryName(string name) {
			var result = await repository.GetListingsByCategoryNameAsync(name);
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> Post(CreateCategoryRequest request) {
			var domain = mapper.Map<Category>(request);
			domain = await repository.CreateAsync(domain);
			return Ok(mapper.Map<CategoryDto>(domain));
		}
	}
}

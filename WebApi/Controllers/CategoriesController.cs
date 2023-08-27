﻿using Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

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
		[Route("{id:guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var result = await repository.GetByIdAsync(id);
			return Ok(result);
		}
		[HttpGet]
		[Route("{name:string}")]
		public async Task<IActionResult> GetListingsByCategoryName(string name) {
			var result = await repository.GetListingsByCategoryNameAsync(name);
			return Ok(result);
		}
	}
}

using Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApi.ApiDtos.Cities;
using WebApi.ApiDtos.ListingProperties;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICityRepository repository;
        /// <summary>
        /// Initializes a new instance of the CitiesController.
        /// </summary>
        /// <param name="mapper">Mapper instance used for converting between domain models and DTOs.</param>
        /// <param name="repository">Repository for accessing cities from database.</param>
        public CitiesController(IMapper mapper, ICityRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? filter)
        {
            var domain = await repository.GetAllAsync(filter);
            return Ok(mapper.Map<List<CityDto>>(domain));
        }
    }
}

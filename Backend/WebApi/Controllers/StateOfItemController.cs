using Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.ListingProperties;
using WebApi.ApiDtos.StateOfItem;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateOfItemController : ControllerBase
    {
        private readonly IStateOfItemRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of StateOfItemController.
        /// </summary>
        /// <param name="repository">Repository used to access state of item data.</param>
        /// <param name="mapper">Mapper used to convert between domain models and DTOs.</param>
        public StateOfItemController(IStateOfItemRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Lists all states of items in the database. 
        /// </summary>
        /// <returns>List of ListingPropertyDtos.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await repository.GetAllAsync();
            return Ok(mapper.Map<List<StateOfItemDto>>(domain));
        }
    }
}
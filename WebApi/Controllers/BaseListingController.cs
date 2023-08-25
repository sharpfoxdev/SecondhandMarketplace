using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.Listings.ListingDtos;

namespace WebApi.Controllers {
	[ApiController]
	public class BaseListingController : ControllerBase {
		protected readonly IListingRepository _repository;
		protected readonly IMapper _mapper;

		public BaseListingController(IListingRepository repository, IMapper mapper) {
			this._repository = repository;
			this._mapper = mapper;
		}
		protected async Task<IActionResult> GenericGetAll<DomainType, DtoType>() where DomainType : BaseListing {
			var domainObject = await _repository.GetAllAsync<DomainType>();
			return Ok(_mapper.Map<List<DtoType>>(domainObject));
		}
		protected async Task<IActionResult> GenericGetById<DomainType, DtoType>(Guid id) where DomainType : BaseListing {
			var domainObject = await _repository.GetByIdAsync<DomainType>(id);
			if (domainObject == null) {
				return NotFound();
			}
			return Ok(_mapper.Map<DtoType>(domainObject));
		}
		protected async Task<IActionResult> GenericCreate<DomainType, ReturnDtoType, RequestDtoType>(RequestDtoType requestDto) where DomainType : BaseListing {
			var domain = _mapper.Map<DomainType>(requestDto);
			domain = (DomainType)await _repository.CreateAsync(domain);
			return Ok(_mapper.Map<DtoType>(domain));
		}
	}
}

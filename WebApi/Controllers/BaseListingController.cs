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
		protected async Task<IActionResult> GenericGetAllAsync<DomainType, ReturnDtoType>() where DomainType : BaseListing {
			var domainObject = await _repository.GetAllAsync<DomainType>();
			return Ok(_mapper.Map<List<ReturnDtoType>>(domainObject));
		}
		protected async Task<IActionResult> GenericGetByIdAsync<DomainType, ReturnDtoType>(Guid id) where DomainType : BaseListing {
			var domainObject = await _repository.GetByIdAsync<DomainType>(id);
			if (domainObject == null) {
				return NotFound();
			}
			return Ok(_mapper.Map<ReturnDtoType>(domainObject));
		}
		protected async Task<IActionResult> GenericCreateAsync<DomainType, ReturnDtoType, RequestDtoType>(RequestDtoType requestDto) where DomainType : BaseListing {
			var domain = _mapper.Map<DomainType>(requestDto);
			domain = (DomainType)await _repository.CreateAsync(domain);
			return Ok(_mapper.Map<ReturnDtoType>(domain));
		}
		protected async Task<IActionResult> GenericUpdateAsync<DomainType, ReturnDtoType, RequestDtoType>(Guid id, RequestDtoType requestDto) where DomainType : BaseListing {
			var domain = _mapper.Map<DomainType>(requestDto);
			domain = (DomainType)await _repository.UpdateAsync(id, domain);
			if(domain == null) {
				return NotFound();
			}
			return Ok(_mapper.Map<ReturnDtoType>(domain));
		}
		protected async Task<IActionResult> GenericDeleteAsync<ReturnDtoType>(Guid id) {
			var domain = await _repository.DeleteAsync(id);
			if(domain == null) {
				return NotFound();
			}
			return Ok(_mapper.Map<ReturnDtoType>(domain));
		}
	}
}

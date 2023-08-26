using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Common;
using Domain.Entities.Listings;
using Microsoft.AspNetCore.Mvc;
using WebApi.ApiDtos.ListingsProperties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ListingPropertiesController : ControllerBase {
		private readonly IMapper _mapper;
		private readonly IListingPropertyRepository _repository;

		public ListingPropertiesController(IMapper mapper, IListingPropertyRepository repository)
        {
			this._mapper = mapper;
			this._repository = repository;
		}
		public async Task<IActionResult> GenericGetAllAsync<DomainType, DtoType>() where DomainType : class, IEntity  {
			var domainObject = await _repository.GetAllAsync<DomainType>();
			return Ok(_mapper.Map<List<DtoType>>(domainObject));
		}
		public async Task<IActionResult> GenericGetByIdAsync<DomainType, DtoType>(Guid id) where DomainType : class, IEntity {
			var domainObject = await _repository.GetByIdAsync<DomainType>(id);
			if (domainObject == null) {
				return NotFound();
			}
			return Ok(_mapper.Map<DtoType>(domainObject));
		}
		// backpacks
		// BackpackBrand
		[HttpGet]
		[Route("BackpackBrand")]
		public async Task<IActionResult> BackpackBrandGetAll() {
			return await GenericGetAllAsync<BackpackBrand, BackpackBrandDto>();

		}
		[HttpGet]
		[Route("BackpackBrand/{id:Guid}")]
		public async Task<IActionResult> BackpackBrandGetById(Guid id) {
			return await GenericGetByIdAsync<BackpackBrand, BackpackBrandDto>(id);
		}
		// BackpackType
		[HttpGet]
		[Route("BackpackType")]
		public async Task<IActionResult> BackpackTypeGetAll() {
			return await GenericGetAllAsync<BackpackType, BackpackTypeDto>();
		}
		[HttpGet]
		[Route("BackpackType/{id:Guid}")]
		public async Task<IActionResult> BackpackTypeGetById(Guid id) {
			return await GenericGetByIdAsync<BackpackType, BackpackTypeDto>(id);
		}

		// Clothes
		// ClothesBrand
		[HttpGet]
		[Route("ClothesBrand")]
		public async Task<IActionResult> ClothesBrandGetAll() {
			return await GenericGetAllAsync<ClothesBrand, ClothesBrandDto>();
		}
		[HttpGet]
		[Route("ClothesBrand/{id:Guid}")]
		public async Task<IActionResult> ClothesBrandGetById(Guid id) {
			return await GenericGetByIdAsync<ClothesBrand, ClothesBrandDto>(id);
		}
		// ClothesSize
		[HttpGet]
		[Route("ClothesSize")]
		public async Task<IActionResult> ClothesSizeGetAll() {
			return await GenericGetAllAsync<ClothesSize, ClothesSizeDto>();
		}
		[HttpGet]
		[Route("ClothesSize/{id:Guid}")]
		public async Task<IActionResult> ClothesSizeGetById(Guid id) {
			return await GenericGetByIdAsync<ClothesSize, ClothesSizeDto>(id);
		}
		// ClothesType
		[HttpGet]
		[Route("ClothesType")]
		public async Task<IActionResult> ClothesTypeGetAll() {
			return await GenericGetAllAsync<ClothesType, ClothesTypeDto>();
		}
		[HttpGet]
		[Route("ClothesType/{id:Guid}")]
		public async Task<IActionResult> ClothesTypeGetById(Guid id) {
			return await GenericGetByIdAsync<ClothesType, ClothesTypeDto>(id);
		}

		// Common Properties
		// Color
		[HttpGet]
		[Route("Color")]
		public async Task<IActionResult> ColorGetAll() {
			return await GenericGetAllAsync<Color, ColorDto>();
		}
		[HttpGet]
		[Route("Color/{id:Guid}")]
		public async Task<IActionResult> ColorGetById(Guid id) {
			return await GenericGetByIdAsync<Color, ColorDto>(id);
		}
		// Gender
		[HttpGet]
		[Route("Gender")]
		public async Task<IActionResult> GenderGetAll() {
			return await GenericGetAllAsync<Gender, GenderDto>();
		}
		[HttpGet]
		[Route("Gender/{id:Guid}")]
		public async Task<IActionResult> GenderGetById(Guid id) {
			return await GenericGetByIdAsync<Gender, GenderDto>(id);
		}
		// StateOfItem
		[HttpGet]
		[Route("StateOfItem")]
		public async Task<IActionResult> StateOfItemGetAll() {
			return await GenericGetAllAsync<StateOfItem, StateOfItemDto>();
		}
		[HttpGet]
		[Route("StateOfItem/{id:Guid}")]
		public async Task<IActionResult> StateOfItemGetById(Guid id) {
			return await GenericGetByIdAsync<StateOfItem, StateOfItemDto>(id);
		}

		// Cooking
		// Cookware
		// CookwareBrand
		[HttpGet]
		[Route("CookwareBrand")]
		public async Task<IActionResult> CookwareBrandGetAll() {
			return await GenericGetAllAsync<CookwareBrand, CookwareBrandDto>();
		}
		[HttpGet]
		[Route("CookwareBrand/{id:Guid}")]
		public async Task<IActionResult> CookwareBrandGetById(Guid id) {
			return await GenericGetByIdAsync<CookwareBrand, CookwareBrandDto>(id);
		}
		// CookwareMaterial
		[HttpGet]
		[Route("CookwareMaterial")]
		public async Task<IActionResult> CookwareMaterialGetAll() {
			return await GenericGetAllAsync<CookwareMaterial, CookwareMaterialDto>();
		}
		[HttpGet]
		[Route("CookwareMaterial/{id:Guid}")]
		public async Task<IActionResult> CookwareMaterialGetById(Guid id) {
			return await GenericGetByIdAsync<CookwareMaterial, CookwareMaterialDto>(id);
		}
		// CookwareType
		[HttpGet]
		[Route("CookwareType")]
		public async Task<IActionResult> CookwareTypeGetAll() {
			return await GenericGetAllAsync<CookwareType, CookwareTypeDto>();
		}
		[HttpGet]
		[Route("CookwareType/{id:Guid}")]
		public async Task<IActionResult> CookwareTypeGetById(Guid id) {
			return await GenericGetByIdAsync<CookwareType, CookwareTypeDto>(id);
		}
		// Stoves
		// StoveBrand
		[HttpGet]
		[Route("StoveBrand")]
		public async Task<IActionResult> StoveBrandGetAll() {
			return await GenericGetAllAsync<StoveBrand, StoveBrandDto>();
		}
		[HttpGet]
		[Route("StoveBrand/{id:Guid}")]
		public async Task<IActionResult> StoveBrandGetById(Guid id) {
			return await GenericGetByIdAsync<StoveBrand, StoveBrandDto>(id);
		}
		// StoveFuelType
		[HttpGet]
		[Route("StoveFuelType")]
		public async Task<IActionResult> StoveFuelTypeGetAll() {
			return await GenericGetAllAsync<StoveFuelType, StoveFuelTypeDto>();
		}
		[HttpGet]
		[Route("StoveFuelType/{id:Guid}")]
		public async Task<IActionResult> StoveFuelTypeGetById(Guid id) {
			return await GenericGetByIdAsync<StoveFuelType, StoveFuelTypeDto>(id);
		}
		// Gear
		// Binoculars
		// BinocularsType
		[HttpGet]
		[Route("BinocularsType")]
		public async Task<IActionResult> BinocularsTypeGetAll() {
			return await GenericGetAllAsync<BinocularsType, BinocularsTypeDto>();
		}
		[HttpGet]
		[Route("BinocularsType/{id:Guid}")]
		public async Task<IActionResult> BinocularsTypeGetById(Guid id) {
			return await GenericGetByIdAsync<BinocularsType, BinocularsTypeDto>(id);
		}
		// Electronics
		// ElectronicsType
		[HttpGet]
		[Route("ElectronicsType")]
		public async Task<IActionResult> ElectronicsTypeGetAll() {
			return await GenericGetAllAsync<ElectronicsType, ElectronicsTypeDto>();
		}
		[HttpGet]
		[Route("ElectronicsType/{id:Guid}")]
		public async Task<IActionResult> ElectronicsTypeGetById(Guid id) {
			return await GenericGetByIdAsync<ElectronicsType, ElectronicsTypeDto>(id);
		}
		// KnifeMultitool
		// KnifeMultitoolBrand
		[HttpGet]
		[Route("KnifeMultitoolBrand")]
		public async Task<IActionResult> KnifeMultitoolBrandGetAll() {
			return await GenericGetAllAsync<KnifeMultitoolBrand, KnifeMultitoolBrandDto>();
		}
		[HttpGet]
		[Route("KnifeMultitoolBrand/{id:Guid}")]
		public async Task<IActionResult> KnifeMultitoolBrandGetById(Guid id) {
			return await GenericGetByIdAsync<KnifeMultitoolBrand, KnifeMultitoolBrandDto>(id);
		}
		// KnifeMultitoolType
		[HttpGet]
		[Route("KnifeMultitoolType")]
		public async Task<IActionResult> KnifeMultitoolTypeGetAll() {
			return await GenericGetAllAsync<KnifeMultitoolType, KnifeMultitoolTypeDto>();
		}
		[HttpGet]
		[Route("KnifeMultitoolType/{id:Guid}")]
		public async Task<IActionResult> KnifeMultitoolTypeGetById(Guid id) {
			return await GenericGetByIdAsync<KnifeMultitoolType, KnifeMultitoolTypeDto>(id);
		}
		// Lighting
		// LightingBrand
		[HttpGet]
		[Route("LightingBrand")]
		public async Task<IActionResult> LightingBrandGetAll() {
			return await GenericGetAllAsync<LightingBrand, LightingBrandDto>();
		}
		[HttpGet]
		[Route("LightingBrand/{id:Guid}")]
		public async Task<IActionResult> LightingBrandGetById(Guid id) {
			return await GenericGetByIdAsync<LightingBrand, LightingBrandDto>(id);
		}
		// LightingType
		[HttpGet]
		[Route("LightingType")]
		public async Task<IActionResult> LightingTypeGetAll() {
			return await GenericGetAllAsync<LightingType, LightingTypeDto>();
		}
		[HttpGet]
		[Route("LightingType/{id:Guid}")]
		public async Task<IActionResult> LightingTypeGetById(Guid id) {
			return await GenericGetByIdAsync<LightingType, LightingTypeDto>(id);
		}
		// TrekkingPole
		// TrekkingPoleBrand
		[HttpGet]
		[Route("TrekkingPoleBrand")]
		public async Task<IActionResult> TrekkingPoleBrandGetAll() {
			return await GenericGetAllAsync<TrekkingPoleBrand, TrekkingPoleBrandDto>();
		}
		[HttpGet]
		[Route("TrekkingPoleBrand/{id:Guid}")]
		public async Task<IActionResult> TrekkingPoleBrandGetById(Guid id) {
			return await GenericGetByIdAsync<TrekkingPoleBrand, TrekkingPoleBrandDto>(id);
		}
		// TrekkingPoleType
		[HttpGet]
		[Route("TrekkingPoleType")]
		public async Task<IActionResult> TrekkingPoleTypeGetAll() {
			return await GenericGetAllAsync<TrekkingPoleType, TrekkingPoleTypeDto>();
		}
		[HttpGet]
		[Route("TrekkingPoleType/{id:Guid}")]
		public async Task<IActionResult> TrekkingPoleTypeGetById(Guid id) {
			return await GenericGetByIdAsync<TrekkingPoleType, TrekkingPoleTypeDto>(id);
		}
		// Shoes
		// ShoeBrand
		[HttpGet]
		[Route("ShoeBrand")]
		public async Task<IActionResult> ShoeBrandGetAll() {
			return await GenericGetAllAsync<ShoeBrand, ShoeBrandDto>();
		}
		[HttpGet]
		[Route("ShoeBrand/{id:Guid}")]
		public async Task<IActionResult> ShoeBrandGetById(Guid id) {
			return await GenericGetByIdAsync<ShoeBrand, ShoeBrandDto>(id);
		}
		// ShoeSize
		[HttpGet]
		[Route("ShoeSize")]
		public async Task<IActionResult> ShoeSizeGetAll() {
			return await GenericGetAllAsync<ShoeSize, ShoeSizeDto>();
		}
		[HttpGet]
		[Route("ShoeSize/{id:Guid}")]
		public async Task<IActionResult> ShoeSizeGetById(Guid id) {
			return await GenericGetByIdAsync<ShoeSize, ShoeSizeDto>(id);
		}
		// ShoeType
		[HttpGet]
		[Route("ShoeType")]
		public async Task<IActionResult> ShoeTypeGetAll() {
			return await GenericGetAllAsync<ShoeType, ShoeTypeDto>();
		}
		[HttpGet]
		[Route("ShoeType/{id:Guid}")]
		public async Task<IActionResult> ShoeTypeGetById(Guid id) {
			return await GenericGetByIdAsync<ShoeType, ShoeTypeDto>(id);
		}

		// Sleeping
		// Hammock
		// HammockBrand
		[HttpGet]
		[Route("HammockBrand")]
		public async Task<IActionResult> HammockBrandGetAll() {
			return await GenericGetAllAsync<HammockBrand, HammockBrandDto>();
		}
		[HttpGet]
		[Route("HammockBrand/{id:Guid}")]
		public async Task<IActionResult> HammockBrandGetById(Guid id) {
			return await GenericGetByIdAsync<HammockBrand, HammockBrandDto>(id);
		}
		// SleepAccessory
		// SleepAccessoryType
		[HttpGet]
		[Route("SleepAccessoryType")]
		public async Task<IActionResult> SleepAccessoryTypeGetAll() {
			return await GenericGetAllAsync<SleepAccessoryType, SleepAccessoryTypeDto>();
		}
		[HttpGet]
		[Route("SleepAccessoryType/{id:Guid}")]
		public async Task<IActionResult> SleepAccessoryTypeGetById(Guid id) {
			return await GenericGetByIdAsync<SleepAccessoryType, SleepAccessoryTypeDto>(id);
		}
		// SleepingBag
		// SleepingBagBrand
		[HttpGet]
		[Route("SleepingBagBrand")]
		public async Task<IActionResult> SleepingBagBrandGetAll() {
			return await GenericGetAllAsync<SleepingBagBrand, SleepingBagBrandDto>();
		}
		[HttpGet]
		[Route("SleepingBagBrand/{id:Guid}")]
		public async Task<IActionResult> SleepingBagBrandGetById(Guid id) {
			return await GenericGetByIdAsync<SleepingBagBrand, SleepingBagBrandDto>(id);
		}
		// SleepingBagInsulationType
		[HttpGet]
		[Route("SleepingBagInsulationType")]
		public async Task<IActionResult> SleepingBagInsulationTypeGetAll() {
			return await GenericGetAllAsync<SleepingBagInsulationType, SleepingBagInsulationTypeDto>();
		}
		[HttpGet]
		[Route("SleepingBagInsulationType/{id:Guid}")]
		public async Task<IActionResult> SleepingBagInsulationTypeGetById(Guid id) {
			return await GenericGetByIdAsync<SleepingBagInsulationType, SleepingBagInsulationTypeDto>(id);
		}
		// SleepingBagSeason
		[HttpGet]
		[Route("SleepingBagSeason")]
		public async Task<IActionResult> SleepingBagSeasonGetAll() {
			return await GenericGetAllAsync<SleepingBagSeason, SleepingBagSeasonDto>();
		}
		[HttpGet]
		[Route("SleepingBagSeason/{id:Guid}")]
		public async Task<IActionResult> SleepingBagSeasonGetById(Guid id) {
			return await GenericGetByIdAsync<SleepingBagSeason, SleepingBagSeasonDto>(id);
		}
		// SleepingBagShape
		[HttpGet]
		[Route("SleepingBagShape")]
		public async Task<IActionResult> SleepingBagShapeGetAll() {
			return await GenericGetAllAsync<SleepingBagShape, SleepingBagShapeDto>();
		}
		[HttpGet]
		[Route("SleepingBagShape/{id:Guid}")]
		public async Task<IActionResult> SleepingBagShapeGetById(Guid id) {
			return await GenericGetByIdAsync<SleepingBagShape, SleepingBagShapeDto>(id);
		}
		// SleepingBagZipSide
		[HttpGet]
		[Route("SleepingBagZipSide")]
		public async Task<IActionResult> SleepingBagZipSideGetAll() {
			return await GenericGetAllAsync<SleepingBagZipSide, SleepingBagZipSideDto>();
		}
		[HttpGet]
		[Route("SleepingBagZipSide/{id:Guid}")]
		public async Task<IActionResult> SleepingBagZipSideGetById(Guid id) {
			return await GenericGetByIdAsync<SleepingBagZipSide, SleepingBagZipSideDto>(id);
		}
		// Sleeping Pad
		// SleepingPadBrand
		[HttpGet]
		[Route("SleepingPadBrand")]
		public async Task<IActionResult> SleepingPadBrandGetAll() {
			return await GenericGetAllAsync<SleepingPadBrand, SleepingPadBrandDto>();
		}
		[HttpGet]
		[Route("SleepingPadBrand/{id:Guid}")]
		public async Task<IActionResult> SleepingPadBrandGetById(Guid id) {
			return await GenericGetByIdAsync<SleepingPadBrand, SleepingPadBrandDto>(id);
		}
		// SleepingPadType
		[HttpGet]
		[Route("SleepingPadType")]
		public async Task<IActionResult> SleepingPadTypeGetAll() {
			return await GenericGetAllAsync<SleepingPadType, SleepingPadTypeDto>();
		}
		[HttpGet]
		[Route("SleepingPadType/{id:Guid}")]
		public async Task<IActionResult> SleepingPadTypeGetById(Guid id) {
			return await GenericGetByIdAsync<SleepingPadType, SleepingPadTypeDto>(id);
		}
		// Tarp
		// TarpBrand
		[HttpGet]
		[Route("TarpBrand")]
		public async Task<IActionResult> TarpBrandGetAll() {
			return await GenericGetAllAsync<TarpBrand, TarpBrandDto>();
		}
		[HttpGet]
		[Route("TarpBrand/{id:Guid}")]
		public async Task<IActionResult> TarpBrandGetById(Guid id) {
			return await GenericGetByIdAsync<TarpBrand, TarpBrandDto>(id);
		}
		// TarpShape
		[HttpGet]
		[Route("TarpShape")]
		public async Task<IActionResult> TarpShapeGetAll() {
			return await GenericGetAllAsync<TarpShape, TarpShapeDto>();
		}
		[HttpGet]
		[Route("TarpShape/{id:Guid}")]
		public async Task<IActionResult> TarpShapeGetById(Guid id) {
			return await GenericGetByIdAsync<TarpShape, TarpShapeDto>(id);
		}
		// Tent
		// TentBrand
		[HttpGet]
		[Route("TentBrand")]
		public async Task<IActionResult> TentBrandGetAll() {
			return await GenericGetAllAsync<TentBrand, TentBrandDto>();
		}
		[HttpGet]
		[Route("TentBrand/{id:Guid}")]
		public async Task<IActionResult> TentBrandGetById(Guid id) {
			return await GenericGetByIdAsync<TentBrand, TentBrandDto>(id);
		}
	}
}

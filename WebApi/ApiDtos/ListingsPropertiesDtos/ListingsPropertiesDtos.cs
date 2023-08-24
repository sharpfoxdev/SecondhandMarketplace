namespace WebApi.ApiDtos.ListingsProperties {
	public class ListingPropertyWithNameDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
	// Backpacks
	public class BackpackBrandDto : ListingPropertyWithNameDto { }
	public class BackpackTypeDto : ListingPropertyWithNameDto { }

	// Clothes
	public class ClothesBrandDto : ListingPropertyWithNameDto { }
	public class ClothesSizeDto : ListingPropertyWithNameDto { }
	public class ClothesTypeDto : ListingPropertyWithNameDto { }

    // Common properties
	public class ColorDto : ListingPropertyWithNameDto { }
	public class GenderDto : ListingPropertyWithNameDto { }
	public class StateOfItemDto : ListingPropertyWithNameDto { }

	// Cooking
	// Cookware
	public class CookwareBrandDto : ListingPropertyWithNameDto { }
	public class CookwareMaterialDto : ListingPropertyWithNameDto { }
	public class CookwareTypeDto : ListingPropertyWithNameDto { }
	// Stoves
	public class StoveBrandDto : ListingPropertyWithNameDto { }
	public class StoveFuelTypeDto : ListingPropertyWithNameDto { }

	// Gear
	// Binoculars
	public class BinocularsTypeDto : ListingPropertyWithNameDto { }
	// Electronics
	public class ElectronicsTypeDto : ListingPropertyWithNameDto { }
	// KnivesMultitools
	public class KnifeMultitoolBrandDto : ListingPropertyWithNameDto { }
	public class KnifeMultitoolTypeDto : ListingPropertyWithNameDto { }
	// Lighting
	public class LightingBrandDto : ListingPropertyWithNameDto { }
	public class LightingTypeDto : ListingPropertyWithNameDto { }
	// TrekkingPoles
	public class TrekkingPoleBrandDto : ListingPropertyWithNameDto { }
	public class TrekkingPoleTypeDto : ListingPropertyWithNameDto { }

	// Shoes
	public class ShoeBrandDto : ListingPropertyWithNameDto { }
	public class ShoeSizeDto : ListingPropertyWithNameDto { }
	public class ShoeTypeDto : ListingPropertyWithNameDto { }

	// Sleeping
	// Hammocks
	public class HammockBrandDto : ListingPropertyWithNameDto { }
	// Sleep Accessoties
	public class SleepAccessoryTypeDto : ListingPropertyWithNameDto { }
	// Sleeping Bags
	public class SleepingBagBrandDto : ListingPropertyWithNameDto { }
	public class SleepingBagInsulationTypeDto : ListingPropertyWithNameDto { }
	public class SleepingBagSeasonDto : ListingPropertyWithNameDto { }
	public class SleepingBagShapeDto : ListingPropertyWithNameDto { }
	public class SleepingBagZipSideDto : ListingPropertyWithNameDto { }
	// Sleeping Pads
	public class SleepingPadBrandDto : ListingPropertyWithNameDto { }
	public class SleepingPadTypeDto : ListingPropertyWithNameDto { }
	// Tarps
	public class TarpBrandDto : ListingPropertyWithNameDto { }
	public class TarpShapeDto : ListingPropertyWithNameDto { }
	// Tents
	public class TentBrandDto : ListingPropertyWithNameDto { }
}

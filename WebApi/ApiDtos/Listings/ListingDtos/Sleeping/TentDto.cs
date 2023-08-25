using WebApi.ApiDtos.ListingsProperties;

namespace WebApi.ApiDtos.Listings.ListingDtos {
	public class TentDto : SleepingDto {
		public int NumberOfPeople { get; set; }
		public int NumberOfDoors { get; set; }
		public TentBrandDto TentBrand { get; set; }
	}
}

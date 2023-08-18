namespace Marketplace.API.Models.DTO.AddListing {
	public class CreateElectronicsListingDto : CreateListingCampingDto {
		public Guid ElectronicsTypeId { get; set; }
	}
}

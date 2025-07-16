using Application.Interfaces;

namespace WebApi.ApiDtos.Listings {

	public class ListingPropertyValueSelectionDto : IListingPropertyValueSelection {
		public Guid ListingPropertyId { get; set; }
		public Guid SelectedListingPropertyValueId { get; set; }

	}

}

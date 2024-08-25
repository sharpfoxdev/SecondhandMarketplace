using Application.Interfaces;

namespace WebApi.ApiDtos.Listings {
	/// <summary>
	/// Not needed anymore, replaced by the IListingPropertyValueSelection
	/// TODO: what is going on here?
	/// </summary>
	public class ListingPropertyValueSelectionDto : IListingPropertyValueSelection {
		public Guid ListringPropertyId { get; set; }
		public Guid SelectedListingPropertyValueId { get; set; }

	}

}

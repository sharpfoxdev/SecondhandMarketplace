using Application.Interfaces;

namespace WebApi.ApiDtos.Listings {
	/// <summary>
	/// Not needed anymore, replaced by the IAttributeSelection
	/// </summary>
	public class AttributeSelectionDto : IListingPropertyValueSelection {
		public Guid ListringPropertyId { get; set; }
		public Guid SelectedListingPropertyValueId { get; set; }

	}

}

using Application.Interfaces;

namespace WebApi.ApiDtos.Listings {
	/// <summary>
	/// Not needed anymore, replaced by the IAttributeSelection
	/// </summary>
	public class AttributeSelectionDto : IAttributeSelection {
		public Guid AttributeGroupId { get; set; }
		public Guid SelectedAttributeId { get; set; }

	}

}

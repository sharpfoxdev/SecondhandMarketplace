namespace WebApi.ApiDtos.ListingPropertyValues {
	/// <summary>
	/// I am not liking to be able to update listing property of the value, it is
	/// better to delete the value and create a new one in the correct property.
	/// </summary>
	public class UpdateListingPropertyValueRequest {
		public string Name { get; set; }
		
		//public Guid ListingPropertyId { get; set; }
	}
}

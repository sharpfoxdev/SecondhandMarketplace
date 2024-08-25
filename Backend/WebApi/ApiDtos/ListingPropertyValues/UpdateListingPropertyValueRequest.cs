namespace WebApi.ApiDtos.ListingPropertyValues {
	/// <summary>
	/// I am not liking to be able to update group of the group, it is
	/// better to delete the attribute and create a new one in the correct group.
	/// </summary>
	public class UpdateListingPropertyValueRequest {
		public string Name { get; set; }
		
		//public Guid AttributeGroupId { get; set; }
	}
}

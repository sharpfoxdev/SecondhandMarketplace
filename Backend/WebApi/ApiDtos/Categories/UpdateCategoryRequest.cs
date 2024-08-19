namespace WebApi.ApiDtos.Categories {
	public class UpdateCategoryRequest {
		public string Name { get; set; }

		// currently not possible, as that would mess up the attributes
		// public Guid? ParentCategoryId { get; set; }

		// todo will possibly be needed, if we wanna assign attribute
		// groups to categories at their creation
		// or we can have separate endpoint for that
		//public List<ListingProperty> ListingProperties { get; set; }
	}
}

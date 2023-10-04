namespace WebApi.ApiDtos.Categories {
	public class UpdateCategoryRequest {
		public string Name { get; set; }
		public Guid? ParentCategoryId { get; set; }

		// todo will possibly be needed, if we wanna assign attribute
		// groups to categories at their creation
		// or we can have separate endpoint for that
		//public List<AttributeGroup> AttributeGroups { get; set; }
	}
}

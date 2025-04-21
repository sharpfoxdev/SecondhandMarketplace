namespace WebApi.ApiDtos.Categories {
	public class UpdateCategoryRequest {
		public string Name { get; set; }

		// currently not possible, as that would mess up the property values
		// public Guid? ParentCategoryId { get; set; }
	}
}

using Domain.Entities;

namespace WebApi.ApiDtos.Categories {
	public class CreateCategoryRequest {
		public string Name { get; set; }
		public Guid? ParentCategoryId { get; set; }
	}
}

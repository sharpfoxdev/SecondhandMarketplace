﻿using Domain.Entities;

namespace WebApi.ApiDtos.Categories {
	public class CreateCategoryRequest {
		public string Name { get; set; }
		public Guid? ParentCategoryId { get; set; }
		
		// todo will possibly be needed, if we wanna assign properties
		// to categories at their creation
		// or we can have separate endpoint for that
		//public List<ListingProperty> ListingProperties { get; set; }
	}
}

﻿using WebApi.ApiDtos.ListingAttribute;

namespace WebApi.ApiDtos.AttributeGroups {
	public class CreateAttributeGroupRequest {
		public string Name { get; set; } = null!;
		//public List<CreateListingAttributeRequest> Attributes { get; set; } = null!;
	}
}

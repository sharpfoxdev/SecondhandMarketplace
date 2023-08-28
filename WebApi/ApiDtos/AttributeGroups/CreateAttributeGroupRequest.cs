using WebApi.ApiDtos.ListingAttribute;

namespace WebApi.ApiDtos.AttributeGroups {
	public class CreateAttributeGroupRequest {
		public string Name { get; set; }
		public List<CreateListingAttributeInsideGroupRequest> Attributes { get; set; }
	}
}

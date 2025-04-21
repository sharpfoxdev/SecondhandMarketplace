using Domain.Entities;
using WebApi.ApiDtos.Categories;
using WebApi.ApiDtos.ListingPropertyValues;

namespace WebApi.ApiDtos.ListingProperties {
	public class ListingPropertyDto {
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
    public class ListingPropertyDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ListingPropertyValueDto> ListingPropertyValues { get; set; }
    }
}

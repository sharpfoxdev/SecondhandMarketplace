using Domain.Entities;
using WebApi.ApiDtos.ListingPropertyValues;

namespace WebApi.ApiDtos.Categories
{
    public class ListingFilterDto
    {
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public List<Guid> StateOfItemIds { get; set; }
        public List<Guid> SelectedListingPropertyValueIds { get; set; }
    }
}

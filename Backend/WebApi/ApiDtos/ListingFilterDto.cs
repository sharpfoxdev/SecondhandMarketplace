using Application.Filters;
using Domain.Entities;
using WebApi.ApiDtos.ListingPropertyValues;

namespace WebApi.ApiDtos
{
    public class ListingFilterDto
    {
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public List<Guid> StateOfItemIds { get; set; }
        public List<Guid> SelectedListingPropertyValueIds { get; set; }
        public Guid? SellerId { get; set; }
        public Guid? CityId { get; set; }
        public int? Radius { get; set; }
        public string? Search { get; set; }
        public Ordering Ordering { get; set; } = Ordering.CreatedAt;
        public OrderingDirection OrderingDirection { get; set; } = OrderingDirection.Descending;

    }
}

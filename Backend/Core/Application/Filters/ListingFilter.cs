using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Filters
{
    public enum Ordering { Price, CreatedAt }
    public enum OrderingDirection { Ascending, Descending }
    public class ListingFilter
    {
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public Guid? SellerId { get; set; }
        public Guid? CityId { get; set; }
        public int? Radius { get; set; }
        public string? Search {  get; set; }
        public Ordering Ordering { get; set; } = Ordering.CreatedAt;
        public OrderingDirection OrderingDirection { get; set; } = OrderingDirection.Descending;
        public List<Guid> StateOfItemIds { get; set; }
        public List<Guid> SelectedListingPropertyValueIds { get; set; }

    }
}

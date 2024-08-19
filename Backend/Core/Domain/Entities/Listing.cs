using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {

    /// <summary>
    /// Represents item being sold. Belongs to one category. Has a list of ListingPropertyValues, that
    /// have to match the ListingProperties of the category it belongs to. So for example
    /// if the category is "Clothes" with ListingProperties "Color", "Size", this listing then
    /// has to have ListingPropertyValues matching the ListingProperties, so for example "Red" and "XXL".
    /// 
    /// TODO: what to do when the categories is updates the ListingProperties. 
    /// When deleting - also delete the the matching attribute
    /// When adding - add null instead (user can fill in, if they want to - can prompt them)
    /// </summary>
    public class Listing : IEntity {
		public Guid Id { get; set; }
		public decimal Price { get; set; }
		// TODO will be mapped to Ids of users, just placeholders for now
		public Guid SellerId { get; set; }

		public StateOfItem StateOfItem { get; set; }
		public Guid StateOfItemId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		public bool IsSold { get; set; }

		public Guid CategoryId { get; set; }
		public Category Category { get; set; }
		public List<ListingPropertyValue> SelectedListingPropertyValues { get; set; }
		public List<Image> Images { get; set; }
	}
}

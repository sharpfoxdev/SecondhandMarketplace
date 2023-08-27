using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	public class Listing : IEntity {
		public Guid Id { get; set; }
		public decimal Price { get; set; }
		public Guid SellerId { get; set; }
		public StateOfItem StateOfItem { get; set; }
		public Guid StateOfItemId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ReasonOfSale { get; set; }
		public string ListingImageUrl { get; set; }
		public bool IsSold { get; set; }

		public Guid CategoryId { get; set; }
		public Category Category { get; set; }
		public List<ListingAttribute> SelectedAttributes { get; set; }
	}
}

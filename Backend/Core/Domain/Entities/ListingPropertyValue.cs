using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
    /// <summary>
    /// ListingPropertyValue is a concrete value of a ListingProperty.
    /// For example ListingProperty "Color" can have values "Red", "Blue", "Green" etc.
    /// </summary>
    public class ListingPropertyValue : IEntity {
		public Guid Id { get; set; }

        /// <summary>
        /// Value of the ListingProperty. For example "Red", "Blue", "Green" etc.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ListingProperties to which this ListingPropertyValue belongs. It is a one to many relationship. 
        /// </summary>
        public Guid ListingPropertyId { get; set; }
		public ListingProperty ListingProperty { get; set; }
        /// <summary>
        /// Listings, that use this ListingPropertyValue. It is a many to many relationship.
        /// </summary>
        public List<Listing> Listings { get; set; }
	}
}

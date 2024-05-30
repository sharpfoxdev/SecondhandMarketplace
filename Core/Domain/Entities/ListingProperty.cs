using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
    /// <summary>
    /// ListingProperty is a property of Listing. For example "Color"
    /// is a ListingProperty, that can have ListingPropertyValues "Red", "Blue", "Green" etc.
    /// 
    /// Each category has a list of ListingProperties. For example category "Clothes" 
    /// can have ListingProperties "ClothesColor", "ClothesSize", "Color" etc.
    /// </summary>
    public class ListingProperty : IEntity {
		public Guid Id { get; set; }
        /// <summary>
        /// Name of the ListingProperty. For example "Color", "ClothesSize" etc.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of categories, that use this ListingProperty. It is a many to many relationship.
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// List of values of this ListingProperty. It is a one to many relationship.
        /// </summary>
        public List<ListingPropertyValue> ListingPropertyValues { get; set; }
	}
}

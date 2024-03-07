using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	/// <summary>
	/// Attribute group is a group of attributes. For example "Color"
	/// is an attribute group, that can have attributes "Red", "Blue", "Green" etc.
	/// 
	/// Each category has a list of attribute groups. For example category "Clothes" 
	/// can have attribute groups "ClothesColor", "ClothesSize", "Color" etc.
	/// </summary>
	public class ListingProperty : IEntity {
		public Guid Id { get; set; }
		/// <summary>
		/// Name of the attribute group. For example "Color", "ClothesSize" etc.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// List of categories, that use this attribute group. It is a many to many relationship.
		/// </summary>
		public List<Category> Categories { get; set; }

		/// <summary>
		/// List of attributes of this attribute group. It is a one to many relationship.
		/// </summary>
		public List<ListingPropertyValue> ListingPropertyValues { get; set; }
	}
}

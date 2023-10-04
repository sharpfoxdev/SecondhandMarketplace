using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	/// <summary>
	/// Attribute is a concrete value of an attribute group.
	/// For example article group "Color" can have attributes "Red", "Blue", "Green" etc.
	/// </summary>
	public class ListingAttribute : IEntity {
		public Guid Id { get; set; }

		/// <summary>
		/// Value of the attribute. For example "Red", "Blue", "Green" etc.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Attribute group to which this attribute belongs. It is a one to many relationship. 
		/// </summary>
		public Guid AttributeGroupId { get; set; }
		public AttributeGroup AttributeGroup { get; set; }
		/// <summary>
		/// Listings, that use this attribute. It is a many to many relationship.
		/// </summary>
		public List<Listing> Listings { get; set; }
	}
}

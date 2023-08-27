using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	public class ListingAttribute : IEntity {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid AttributeGroupId { get; set; }
		public AttributeGroup AttributeGroup { get; set; }
		public List<Listing> Listings { get; set; }
	}
}

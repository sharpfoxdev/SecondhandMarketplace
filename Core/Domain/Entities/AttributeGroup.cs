using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	public class AttributeGroup {
		public Guid Id { get; set; }
		public string Name { get; set; }
		// possibly list of categories
		//public Guid CategoryId { get; set; }
		//public Category Category { get; set; }
		public List<Attribute> Attributes { get; set; }
	}
}

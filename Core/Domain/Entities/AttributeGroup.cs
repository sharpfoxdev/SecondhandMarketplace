﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	public class AttributeGroup : IEntity {
		public Guid Id { get; set; }
		public string Name { get; set; }
		// possibly list of categories
		//public Guid CategoryId { get; set; }
		public List<Category> Categories { get; set; }
		public List<ListingAttribute> Attributes { get; set; }
	}
}

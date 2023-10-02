using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
	/// <summary>
	/// Describes a state of item (new, good, very good, ...). 
	/// Might be moved into a attribute group "StateOfItem" and
	/// possible Name values will be mapped to the attribute values. But since it is a common
	/// for all listings, I have it separately for now. Otherwise it would reside in some
	/// sort of root category, that would be common predecesor for all categories
	/// </summary>
	public class StateOfItem : IEntity {
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}

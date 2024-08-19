using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common {

	/// <summary>
	/// Common interface for all entities. All entities must have an Id.
	/// </summary>
	public interface IEntity {
		public Guid Id { get; set; }
	}
}

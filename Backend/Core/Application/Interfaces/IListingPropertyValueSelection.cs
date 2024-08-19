using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
	public interface IListingPropertyValueSelection {
		public Guid ListringPropertyId { get; set; }
		public Guid SelectedListingPropertyValueId { get; set; }
	}
}

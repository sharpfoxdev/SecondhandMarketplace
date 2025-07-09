using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
	public interface IListingPropertyValueSelection {
		public Guid ListingPropertyId { get; set; }
		public Guid SelectedListingPropertyValueId { get; set; }
	}
}

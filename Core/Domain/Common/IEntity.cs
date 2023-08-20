using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common {
	internal interface IEntity {
		public Guid Id { get; set; }
	}
}

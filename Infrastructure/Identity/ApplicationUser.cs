using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity {
	public class ApplicationUser : IdentityUser<Guid> {
		public List<Listing> Listings { get; set; }
	}
}

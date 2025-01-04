using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity {
    /// <summary>
    /// Setup, so that users use Guid as a key instead of a string
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid> {
        /// <summary>
        /// One to many relation with listings
        /// </summary>
		public List<Listing> Listings { get; set; }
        // todo sem dat odkaz na konverzace a zpravy?
        public List<Conversation> Conversations { get; set; }
        public List<Message> Messages { get; set; }
	}
}

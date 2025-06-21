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
        public string Nickname { get; set; }
        public DateTime LastLoggedIn { get; set; }
        /// <summary>
        /// One to many relation with listings
        /// </summary>
		public List<Listing> Listings { get; set; }
        public List<ConversationParticipant> ConversationParticipants { get; set; }
        public List<Message> Messages { get; set; }
	}
}

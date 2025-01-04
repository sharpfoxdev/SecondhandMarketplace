using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Defines manually many to many relationship beweeen Conversation and their participants. 
    /// I cannot use navigation properties on the Conversation, because the ApplicationUser resides
    /// in the Infrastructure and Conversation thus cannot see him, and it was not possible to
    /// run the migration with List<Guid> Participants in the Conversation code. 
    /// </summary>
    public class ConversationParticipant
    {
        // Composite key: (ConversationId, UserId)
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public Guid UserId { get; set; }
    }
}

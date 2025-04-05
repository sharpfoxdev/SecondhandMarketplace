using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Conversation : IEntity
    {
        public Guid Id { get; set; }
        public List<Message> Messages { get; set; } = new();
        public List<ConversationParticipant> ConversationParticipants { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

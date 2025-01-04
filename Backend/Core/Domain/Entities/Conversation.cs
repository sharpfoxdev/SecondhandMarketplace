using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Conversation : IEntity
    {
        public Guid Id { get; set; }
        public List<Guid> ParticipantIds { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}

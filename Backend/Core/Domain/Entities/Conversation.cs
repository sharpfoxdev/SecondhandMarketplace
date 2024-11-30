using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Conversation
    {
        public Guid Id { get; set; }
        public List<User> Participants { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}

using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Message : IEntity
    {

        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public Guid SenderId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}


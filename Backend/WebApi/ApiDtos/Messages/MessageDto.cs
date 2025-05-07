using WebApi.ApiDtos.Conversations;

namespace WebApi.ApiDtos.Messages
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public Guid SenderId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

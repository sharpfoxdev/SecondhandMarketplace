using Domain.Common;
using Domain.Entities;
using WebApi.ApiDtos.Messages;

namespace WebApi.ApiDtos.Conversations
{
    public class ConversationDto
    {
        public Guid Id { get; set; }
        public List<ConversationParticipantDto> ConversationParticipants { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    //public class ConversationDetailDto
    //{
    //    public Guid Id { get; set; }
    //    public List<MessageDto> Messages { get; set; }
    //    public List<ConversationParticipant> ConversationParticipants { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //}
    public class ConversationParticipantDto
    {
        public Guid ConversationId { get; set; }
        public Guid UserId { get; set; }
    }
}

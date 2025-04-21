using Domain.Common;
using Domain.Entities;
using WebApi.ApiDtos.Messages;

namespace WebApi.ApiDtos.Conversations
{
    public class ConversationDto
    {
        public Guid Id { get; set; }
        //public List<ConversationParticipant> ConversationParticipants { get; set; }
        // todo dodelat mapping pro usery
        public DateTime CreatedAt { get; set; }
    }
    public class ConversationDetailDto
    {
        public Guid Id { get; set; }
        public List<MessageDto> Messages { get; set; }
        //public List<ConversationParticipant> ConversationParticipants { get; set; }
        // todo dodelat mapping pro usery

        public DateTime CreatedAt { get; set; }
    }
}

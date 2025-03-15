using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using WebApi.ApiDtos.ListingProperties;

namespace WebApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageRepository messageRepository;
        private readonly IConversationRepository conversationRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor for ChatHub.
        /// </summary>
        /// <param name="messageRepository">Repository for interacting with messages.</param>
        /// <param name="conversationRepository">Repository for interacting with conversations in database.</param>
        /// <param name="mapper">AutoMapper for mapping between domain models and DTOs.</param>
        public ChatHub(IMessageRepository messageRepository, IConversationRepository conversationRepository, IMapper mapper)
        {
            this.messageRepository = messageRepository;
            this.conversationRepository = conversationRepository;
            this.mapper = mapper;
        }

        public async Task SendMessage(Guid conversationId, string message)
        {
            string senderIdString = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(senderIdString))
            {
                throw new HubException("User is not authenticated.");
            }
            Guid senderId = Guid.Parse(senderIdString);
            bool isParticipant = await conversationRepository.IsUserInConversationAsync(senderId, conversationId);
            if (!isParticipant)
        {
                throw new HubException("User is not a member of this conversation.");
            }
            var domain = new Message { Id = Guid.NewGuid(), ConversationId = conversationId, Content = message, SenderId = senderId, CreatedAt = DateTime.Now };
            domain = await messageRepository.CreateAsync(domain);
            await Clients.Group(conversationId.ToString()).SendAsync("ReceiveMessage", senderId, mapper.Map<ListingPropertyDto>(domain));
        }

        public async Task JoinConversation(Guid conversationId)
        {
            string userIdString = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                throw new HubException("User is not authenticated.");
            }
            Guid userId = Guid.Parse(userIdString);
            bool isParticipant = await conversationRepository.IsUserInConversationAsync(userId, conversationId);
            if (!isParticipant)
            {
                throw new HubException("User is not a member of this conversation.");
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
        }
    }
}

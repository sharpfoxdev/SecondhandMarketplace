using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;
using WebApi.ApiDtos.Categories;
using WebApi.ApiDtos.Conversations;
using WebApi.ApiDtos.Messages;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // todo pridat authorized very likely
    public class ConversationsController : ControllerBase
    {

        private readonly IConversationRepository conversationRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor for CategoriesController.
        /// </summary>
        /// <param name="repository">Repository for interacting with category data.</param>
        /// <param name="mapper">AutoMapper for mapping between domain models and DTOs.</param>
        public ConversationsController(IConversationRepository conversationRepository, IMessageRepository messageRepository, IMapper mapper)
        {
            this.conversationRepository = conversationRepository;
            this.messageRepository = messageRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Creates a new Conversation. If the conversation already exists, it returns the existing conversation, so that the 
        /// </summary>
        /// <param name="request">Request object containing category details.</param>
        /// <returns>The created category.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateConversationRequest request)
        {
            string senderIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid senderId = Guid.Parse(senderIdString);
            var existingConversation = await conversationRepository.ConversationExists(senderId, request.RecipientId);
            if (existingConversation != null)
            {
                var mappedExisting = mapper.Map<ConversationDto>(existingConversation);
                return Ok(mappedExisting);
            }
            // todo overit, ze ten druhy clovek existuje
            var conversationId = Guid.NewGuid();
            var participant1 = new ConversationParticipant { ConversationId = conversationId, UserId = senderId };
            var participant2 = new ConversationParticipant { ConversationId = conversationId, UserId = request.RecipientId };
            var conversation = new Conversation { Id = conversationId, ConversationParticipants = new() { participant1, participant2 }, CreatedAt = DateTime.Now};
           
            var domain = await conversationRepository.CreateAsync(conversation);
            var mapped = mapper.Map<ConversationDto>(domain);
            return Ok(mapped);
        }
        /// <summary>
        /// Retrieves messages of conversation by its ID.
        /// </summary>
        /// <param name="conversationId">The unique identifier of the conversation.</param>
        /// <returns>The requested messages, or a Forbidden response if user is not part of the conversation.</returns>
        [HttpGet]
        [Route("{conversationId:Guid}/messages")]
        public async Task<IActionResult> GetMessagesById(Guid conversationId)
        {
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = Guid.Parse(userIdString);
            var isParticipant = await conversationRepository.IsUserInConversationAsync(userId, conversationId);
            if (!isParticipant)
            {
                return Forbid(); // todo check, that this is correct return code
            }
            var domain = await messageRepository.GetByConversationIdAsync(conversationId);
            return Ok(mapper.Map<List<MessageDto>>(domain));
        }
        /// <summary>
        /// Retrieves conversation info by its ID.
        /// </summary>
        /// <param name="conversationId">The unique identifier of the conversation.</param>
        /// <returns>The requested conversation, or a Forbidden response if user is not part of the conversation.</returns>
        [HttpGet]
        [Route("{conversationId:Guid}")]
        public async Task<IActionResult> GetById(Guid conversationId)
        {
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = Guid.Parse(userIdString);
            var isParticipant = await conversationRepository.IsUserInConversationAsync(userId, conversationId);
            if (!isParticipant)
            {
                return Forbid(); // todo check, that this is correct return code
            }
            var domain = await conversationRepository.GetByIdAsync(conversationId);
            return Ok(mapper.Map<ConversationDto>(domain));
        }
    }
}

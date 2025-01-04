using Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {

        private readonly IConversationRepository conversationRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor for CategoriesController.
        /// </summary>
        /// <param name="repository">Repository for interacting with category data.</param>
        /// <param name="mapper">AutoMapper for mapping between domain models and DTOs.</param>
        public ConversationsController(IConversationRepository conversationRepository, IMessageRepository messageRepository, IMapper mapper)
        {
            this.conversationRepository = conversationRepository;
            this.mapper = mapper;
        }

        // todo create
        // todo get/convoId -> all messages
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IConversationRepository
    {
        Task<Conversation> GetByIdAsync(Guid id);
        Task<List<Conversation>> GetByUserIdAsync(Guid userId);
        Task<Conversation> CreateAsync(Conversation conversation);
        Task UpdateAsync(Conversation conversation);
        Task<bool> IsUserInConversationAsync(Guid userId, Guid conversationId);
        Task<Conversation?> ConversationExists(Guid userId1, Guid userId2);
    }
}

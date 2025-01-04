using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetByConversationIdAsync(Guid conversationId);
        Task<Message> CreateAsync(Message message);
    }
}

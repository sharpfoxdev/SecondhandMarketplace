using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MarketplaceDbContext dbContext;

        public MessageRepository(MarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Message>> GetByConversationIdAsync(Guid conversationId)
        {
            return await dbContext.Messages
                .Where(m => m.ConversationId == conversationId)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task<Message> CreateAsync(Message message)
        {
            dbContext.Messages.Add(message);
            await dbContext.SaveChangesAsync();
            return message;
        }
    }
}

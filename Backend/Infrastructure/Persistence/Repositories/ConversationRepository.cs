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
    public class ConversationRepository : IConversationRepository
    {
        private readonly MarketplaceDbContext dbContext;

        public ConversationRepository(MarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Conversation> CreateAsync(Conversation conversation)
        {
            dbContext.Conversations.Add(conversation);
            await dbContext.SaveChangesAsync();
            return conversation;
        }

        public async Task<Conversation> GetByIdAsync(Guid id)
        {
            return await dbContext.Conversations
                .Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Conversation>> GetByUserIdAsync(Guid userId)
        {
            return await dbContext.Conversations
                .Where(c => c.ParticipantIds.Any(id => id == userId))
                .ToListAsync();
        }

        public async Task UpdateAsync(Conversation conversation)
        {
            dbContext.Conversations.Update(conversation);
            await dbContext.SaveChangesAsync();
        }
    }
}

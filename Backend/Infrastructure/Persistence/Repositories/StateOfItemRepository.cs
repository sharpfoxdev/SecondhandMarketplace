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
    public class StateOfItemRepository : IStateOfItemRepository
    {
        private readonly MarketplaceDbContext dbContext;

        public StateOfItemRepository(MarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<StateOfItem>> GetAllAsync()
        {
            return await dbContext.StateOfItem.ToListAsync();
        }
    }
}

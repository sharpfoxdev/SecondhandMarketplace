using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly MarketplaceDbContext dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public CityRepository(MarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<City>> GetAllAsync(string? filter)
        {
            return await dbContext.Cities.FilterBySearch(filter).OrderBy(city => city.Name).Take(10).ToListAsync();
        }
    }
}

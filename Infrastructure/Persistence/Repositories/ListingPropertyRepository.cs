using Application.Interfaces.Repositories;
using Domain.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	internal class ListingPropertyRepository : IListingPropertyRepository {
		private readonly MarketplaceDbContext _dbContext;

		public ListingPropertyRepository(MarketplaceDbContext dbContext) {
			this._dbContext = dbContext;
		}
		public async Task<List<T>> GetAllAsync<T>() where T : class, IEntity {
			var query = _dbContext.Listings.OfType<T>();
			foreach (var navigationProperty in _dbContext.Model.FindEntityType(typeof(T)).GetNavigations()) {
				query = query.Include(navigationProperty.Name);
			}
			return await query.ToListAsync();
		}

		public async Task<T?> GetByIdAsync<T>(Guid id) where T : class, IEntity {
			var query = _dbContext.Listings.OfType<T>();
			foreach (var navigationProperty in _dbContext.Model.FindEntityType(typeof(T)).GetNavigations()) {
				query = query.Include(navigationProperty.Name);
			}
			return await query.FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}

using Application.Interfaces.Repositories;
using Domain.Entities.Listings;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	public class ListingRepository : IListingRepository {
		private readonly MarketplaceDbContext _dbContext;

		public ListingRepository(MarketplaceDbContext dbContext)
        {
			this._dbContext = dbContext;
		}

        public async Task<BaseListing> CreateAsync(BaseListing listing) {
			await _dbContext.Listings.AddAsync(listing);
			await _dbContext.SaveChangesAsync();
			return listing;
		}

		public async Task<BaseListing?> DeleteAsync(Guid id) {
			var existingListing = await _dbContext.Listings.FindAsync(id);
			if (existingListing == null) {
				return null;
			}

			_dbContext.Listings.Remove(existingListing);
			await _dbContext.SaveChangesAsync();
			return existingListing;
		}

		public async Task<List<BaseListing>> GetAllAsync() {
			return await _dbContext.Listings.ToListAsync();
		}
		

		public async Task<BaseListing?> GetByIdAsync(Guid id) {
			return await _dbContext.Listings.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<BaseListing?> UpdateAsync(BaseListing listing) {
			throw new NotImplementedException();
		}
	}
}

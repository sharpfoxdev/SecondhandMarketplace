using Application.Interfaces.Repositories;
using Domain.Common;
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

		public async Task<List<T>> GetAllAsync<T>() where T : BaseListing {
			// implement this correctly to retun the type of the list, that we specify
			// I think this might list all listings, not just a sub tree
			return (await _dbContext.Listings.OfType<T>().ToListAsync());//.Cast<T>().ToList();
		}
		

		public async Task<BaseListing?> GetByIdAsync(Guid id) {
			return await _dbContext.Listings.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<BaseListing?> UpdateAsync(Guid id, BaseListing listing) {
			// todo create update methods inside listings
			var existingListing = await _dbContext.Listings.FindAsync(listing.Id);
			if (existingListing == null) {
				return null;
			}
			existingListing.Update(listing);
			await _dbContext.SaveChangesAsync();
			return existingListing;
		}
	}
}

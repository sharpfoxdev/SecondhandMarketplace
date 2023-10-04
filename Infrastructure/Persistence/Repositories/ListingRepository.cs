using Application.Interfaces.Repositories;
using Domain.Common;
using Domain.Entities;
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

		public async Task<Listing> CreateAsync(Listing listing) {
			await _dbContext.Listings.AddAsync(listing);
			await _dbContext.SaveChangesAsync();
			return listing;
		}

		public async Task<Listing?> DeleteAsync(Guid id) {
			var existingListing = await _dbContext.Listings.FindAsync(id);
			if (existingListing == null) {
				return null;
			}

			_dbContext.Listings.Remove(existingListing);
			await _dbContext.SaveChangesAsync();
			return existingListing;
		}

		public async Task<List<Listing>> GetAllAsync() {
			// how to deal with navigation properties with generic types
			// https://github.com/dotnet/efcore/issues/3910#issuecomment-346149850
			/*var query = _dbContext.Listings.OfType<T>();
			foreach(var navigationProperty in _dbContext.Model.FindEntityType(typeof(T)).GetNavigations()) {
				query = query.Include(navigationProperty.Name);
			}
			return await query.ToListAsync();*/
			throw new NotImplementedException();
			//return (await _dbContext.Listings.OfType<T>().ToListAsync());//.Cast<T>().ToList();
		}
		

		public async Task<Listing?> GetByIdAsync(Guid id) {
			throw new NotImplementedException();
			/*var query = _dbContext.Listings.OfType<T>();
			foreach (var navigationProperty in _dbContext.Model.FindEntityType(typeof(T)).GetNavigations()) {
				query = query.Include(navigationProperty.Name);
			}
			return await query.FirstOrDefaultAsync(x => x.Id == id);*/
			//return await _dbContext.Listings.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Listing?> UpdateAsync(Guid id, Listing listing) {
			// todo create update methods inside listings
			var existingListing = await _dbContext.Listings.FindAsync(id);
			if (existingListing == null) {
				return null;
			}
			//existingListing.Update(listing);
			await _dbContext.SaveChangesAsync();
			return existingListing;
		}

	}
}

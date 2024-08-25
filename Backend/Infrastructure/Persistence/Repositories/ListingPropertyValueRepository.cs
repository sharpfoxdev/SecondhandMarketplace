using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Persistence.Repositories {
	internal class ListingPropertyValueRepository : IListingPropertyValueRepository {
		private readonly MarketplaceDbContext dbContext;

		public ListingPropertyValueRepository(MarketplaceDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<ListingPropertyValue> CreateAsync(ListingPropertyValue value) {
			await dbContext.ListingPropertyValues.AddAsync(value);
			await dbContext.SaveChangesAsync();
			return value;
		}

		public async Task<ListingPropertyValue?> DeleteAsync(Guid id) {
			var existing = await dbContext.ListingPropertyValues
				.Include(x => x.ListingProperty)
				.Include(x => x.Listings)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			dbContext.ListingPropertyValues.Remove(existing);
			await dbContext.SaveChangesAsync();
			return existing;
		}

		public async Task<List<ListingPropertyValue>> GetAllAsync() {
			return await dbContext.ListingPropertyValues
				.Include(x => x.ListingProperty)
				.Include(x => x.Listings)
				.ToListAsync();
		}
		public async Task<List<ListingPropertyValue>> GetAllByListingProperty(Guid id) {
			// list just the ones tied to a listing property. Kinda similar to ListingProperty.GetById(), so maybe redundant?
			throw new NotImplementedException();
		}
		public async Task<ListingPropertyValue?> GetByIdAsync(Guid id) {
			var existing = await dbContext.ListingPropertyValues
				.Include(x => x.ListingProperty)
				.Include(x => x.Listings)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			return existing;
		}

		public async Task<ListingPropertyValue?> UpdateAsync(Guid id, ListingPropertyValue updatedPropertyValue) {
			// TOCHECK will update just name? What about adding it to a different existing listing property? Possibly. 
			// Or create a new listring property all together? Probably not. 
			// For now we dont update the value listing property ids
			var existing = await dbContext.ListingPropertyValues
				.Include(x => x.ListingProperty)
				.Include(x => x.Listings)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				// didnt find what we want to update
				return null;
			}
			existing.Name = updatedPropertyValue.Name;
			//existing.ListingPropertyId = updatedPropertyValue.ListingPropertyId;
			await dbContext.SaveChangesAsync();
			return existing;
		}
	}
}

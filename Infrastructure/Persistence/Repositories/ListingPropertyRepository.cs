using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	internal class ListingPropertyRepository : IListingPropertyRepository {
		private readonly MarketplaceDbContext dbContext;

		public ListingPropertyRepository(MarketplaceDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

        public async Task<ListingProperty> CreateAsync(ListingProperty property) {
            // we can create with some ListingPropertyValues
            await dbContext.ListingProperties.AddAsync(property);
			await dbContext.SaveChangesAsync();
			return property;
		}

		public async Task<ListingProperty?> DeleteAsync(Guid id) {
			// when we delete property, we also want to delete all associated values
			var existing = await dbContext.ListingProperties
				.Include(x => x.ListingPropertyValues)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			dbContext.ListingProperties.Remove(existing);
			await dbContext.SaveChangesAsync();
			return existing;
		}

		public async Task<List<ListingProperty>> GetAllAsync() {
			return await dbContext.ListingProperties
				.Include(x => x.ListingPropertyValues)
				.Include(x => x.Categories)
				.ToListAsync();
		}

		public async Task<ListingProperty?> GetByIdAsync(Guid id) {
			var existing = await dbContext.ListingProperties
				.Include(x => x.ListingPropertyValues)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if(existing == null) {
				return null;
			}
			return existing;
		}
		public async Task<ListingProperty?> AddListingPropertyValueAsync(Guid id, List<ListingPropertyValue> values) {
			var group = await dbContext.ListingProperties
				.Include(x => x.ListingPropertyValues)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (group == null) {
				// didnt find property with this id
				return null;
			}
			// TODO - maybe check, that we are not adding already existing values
			group.ListingPropertyValues.AddRange(values);
			await dbContext.SaveChangesAsync();
			return group;
		}
		public async Task<ListingProperty?> UpdateAsync(Guid id, ListingProperty updatedProperty) {
			// we will not be updating values
			var existingProperty = await dbContext.ListingProperties
				.Include(x => x.ListingPropertyValues)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if(existingProperty == null) {
				// didnt find what we want to update
				return null;
			}
			existingProperty.Name = updatedProperty.Name;
			await dbContext.SaveChangesAsync();
			return existingProperty;
		}
	}
}

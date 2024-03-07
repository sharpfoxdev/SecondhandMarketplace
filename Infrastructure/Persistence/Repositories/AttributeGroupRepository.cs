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
	internal class AttributeGroupRepository : IAttributeGroupRepository {
		private readonly MarketplaceDbContext dbContext;

		public AttributeGroupRepository(MarketplaceDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

        public async Task<ListingProperty> CreateAsync(ListingProperty group) {
			// we can create with some attributes
			await dbContext.ListingProperties.AddAsync(group);
			await dbContext.SaveChangesAsync();
			return group;
		}

		public async Task<ListingProperty?> DeleteAsync(Guid id) {
			// when we delete group, we also want to delete all associated attributes
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
		public async Task<ListingProperty?> AddAttributesAsync(Guid id, List<ListingPropertyValue> attributes) {
			var group = await dbContext.ListingProperties
				.Include(x => x.ListingPropertyValues)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (group == null) {
				// didnt find group with this id
				return null;
			}
			// TODO - maybe check, that we are not adding already existing attributes
			group.ListingPropertyValues.AddRange(attributes);
			await dbContext.SaveChangesAsync();
			return group;
		}
		public async Task<ListingProperty?> UpdateAsync(Guid id, ListingProperty updatedGroup) {
			// we will not be updating attributes
			var existingGroup = await dbContext.ListingProperties
				.Include(x => x.ListingPropertyValues)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if(existingGroup == null) {
				// didnt find what we want to update
				return null;
			}
			existingGroup.Name = updatedGroup.Name;
			await dbContext.SaveChangesAsync();
			return existingGroup;
		}
	}
}

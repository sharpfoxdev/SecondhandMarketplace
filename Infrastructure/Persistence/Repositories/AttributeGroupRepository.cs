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

        public async Task<AttributeGroup> CreateAsync(AttributeGroup group) {
			// we can create with some attributes
			dbContext.AttributeGroups.Add(group);
			await dbContext.SaveChangesAsync();
			return group;
		}

		public async Task<AttributeGroup?> DeleteAsync(Guid id) {
			// when we delete group, we also want to delete all associated attributes
			var existing = await dbContext.AttributeGroups
				.Include(x => x.Attributes)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			dbContext.AttributeGroups.Remove(existing);
			await dbContext.SaveChangesAsync();
			return existing;
		}

		public async Task<List<AttributeGroup>> GetAllAsync() {
			return await dbContext.AttributeGroups
				.Include(x => x.Attributes)
				.Include(x => x.Categories)
				.ToListAsync();
		}

		public async Task<AttributeGroup?> GetByIdAsync(Guid id) {
			return await dbContext.AttributeGroups
				.Include(x => x.Attributes)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
		}
		public async Task<AttributeGroup?> AddAttributesAsync(Guid id, List<ListingAttribute> attributes) {
			var group = await dbContext.AttributeGroups
				.Include(x => x.Attributes)
				.Include(x => x.Categories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (group == null) {
				// didnt find group with this id
				return null;
			}
			group.Attributes.AddRange(attributes);
			await dbContext.SaveChangesAsync();
			return group;
		}
		public async Task<AttributeGroup?> UpdateAsync(Guid id, AttributeGroup updatedGroup) {
			// we will not be updating attributes
			var existingGroup = await dbContext.AttributeGroups
				.Include(x => x.Attributes)
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

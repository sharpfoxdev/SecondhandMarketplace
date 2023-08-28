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
	internal class ListingAttributeRepository : IListingAttributeRepository {
		private readonly MarketplaceDbContext dbContext;

		public ListingAttributeRepository(MarketplaceDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<ListingAttribute> CreateAsync(ListingAttribute attribute) {
			dbContext.Attributes.Add(attribute);
			await dbContext.SaveChangesAsync();
			return attribute;
		}

		public async Task<ListingAttribute?> DeleteAsync(Guid id) {
			var existing = await dbContext.Attributes
				.Include(x => x.AttributeGroup)
				.Include(x => x.Listings)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			dbContext.Attributes.Remove(existing);
			await dbContext.SaveChangesAsync();
			return existing;
		}

		public async Task<List<ListingAttribute>> GetAllAsync() {
			return await dbContext.Attributes
				.Include(x => x.AttributeGroup)
				.Include(x => x.Listings)
				.ToListAsync();
		}
		public async Task<List<ListingAttribute>> GetAllByAttributeGroup(Guid id) {
			// list just the ones tied to a group. Kinda similar to AttributeGroup.GetById(), so maybe redundant?
			throw new NotImplementedException();
		}
		public async Task<ListingAttribute?> GetByIdAsync(Guid id) {
			var existing = await dbContext.Attributes
				.Include(x => x.AttributeGroup)
				.Include(x => x.Listings)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			return existing;
		}

		public async Task<ListingAttribute?> UpdateAsync(Guid id, ListingAttribute updatedAttribute) {
			// will update just name? What about adding it to a different existing group? Possibly. 
			// Or create a new group all together? Probably not. 
			var existing = await dbContext.Attributes
				.Include(x => x.AttributeGroup)
				.Include(x => x.Listings)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				// didnt find what we want to update
				return null;
			}
			existing.Name = updatedAttribute.Name;
			existing.AttributeGroupId = updatedAttribute.AttributeGroupId;
			await dbContext.SaveChangesAsync();
			return existing;
		}
	}
}

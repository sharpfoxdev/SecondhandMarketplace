using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	internal class ListingAttributeRepository : IListingAttributeRepository {
		private readonly MarketplaceDbContext dbContext;

		public ListingAttributeRepository(MarketplaceDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public Task<ListingAttribute> CreateAsync(ListingAttribute listing) {
			// will create new one tied to the attribute group
			throw new NotImplementedException();
		}

		public Task<ListingAttribute?> DeleteAsync(Guid id) {
			// will delete, nothing weird
			throw new NotImplementedException();
		}

		public Task<List<ListingAttribute>> GetAllAsync() {
			throw new NotImplementedException();
		}
		public Task<List<ListingAttribute>> GetAllByAttributeGroup(Guid id) {
			// list just the ones tied to a group. Kinda similar to AttributeGroup.GetById(), so maybe redundant?
			throw new NotImplementedException();
		}
		public Task<ListingAttribute?> GetByIdAsync(Guid id) {
			throw new NotImplementedException();
		}

		public Task<ListingAttribute?> UpdateAsync(Guid id, ListingAttribute listing) {
			// will update just name? What about adding it to a different existing group? Possibly. 
			// Or create a new group all together? Probably not. 
			throw new NotImplementedException();
		}
	}
}

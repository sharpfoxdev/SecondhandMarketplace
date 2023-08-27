using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	internal class ListingAttributeRepository : IListingAttributeRepository {
		public Task<ListingAttribute> CreateAsync(ListingAttribute listing) {
			throw new NotImplementedException();
		}

		public Task<ListingAttribute?> DeleteAsync(Guid id) {
			throw new NotImplementedException();
		}

		public Task<List<ListingAttribute>> GetAllAsync() {
			throw new NotImplementedException();
		}

		public Task<ListingAttribute?> GetByIdAsync(Guid id) {
			throw new NotImplementedException();
		}

		public Task<ListingAttribute?> UpdateAsync(Guid id, ListingAttribute listing) {
			throw new NotImplementedException();
		}
	}
}

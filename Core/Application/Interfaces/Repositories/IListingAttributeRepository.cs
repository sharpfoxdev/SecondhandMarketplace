using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	public interface IListingAttributeRepository {
		public Task<List<ListingAttribute>> GetAllAsync();
		public Task<ListingAttribute?> GetByIdAsync(Guid id);
		public Task<ListingAttribute> CreateAsync(ListingAttribute listing);
		public Task<ListingAttribute?> UpdateAsync(Guid id, ListingAttribute listing);
		public Task<ListingAttribute?> DeleteAsync(Guid id);
	}
}

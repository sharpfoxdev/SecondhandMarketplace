using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	public interface IListingAttributeRepository {
		public Task<List<ListingPropertyValue>> GetAllAsync();
		public Task<ListingPropertyValue?> GetByIdAsync(Guid id);
		public Task<ListingPropertyValue> CreateAsync(ListingPropertyValue attribute);
		public Task<ListingPropertyValue?> UpdateAsync(Guid id, ListingPropertyValue attribute);
		public Task<ListingPropertyValue?> DeleteAsync(Guid id);
	}
}

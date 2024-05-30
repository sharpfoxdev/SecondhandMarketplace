using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	public interface IListingPropertyValueRepository {
		public Task<List<ListingPropertyValue>> GetAllAsync();
		public Task<ListingPropertyValue?> GetByIdAsync(Guid id);
		public Task<ListingPropertyValue> CreateAsync(ListingPropertyValue value);
		public Task<ListingPropertyValue?> UpdateAsync(Guid id, ListingPropertyValue value);
		public Task<ListingPropertyValue?> DeleteAsync(Guid id);
	}
}

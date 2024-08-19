using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	/// <summary>
	/// Interface defining what operations should we be able to do over ListingProperty objects.
	/// The implementation of these operations is in Infrastructure/Persistence layer, as it touches the database.
	/// </summary>
	public interface IListingPropertyRepository {
		public Task<List<ListingProperty>> GetAllAsync();
		public Task<ListingProperty?> GetByIdAsync(Guid id);
		public Task<ListingProperty> CreateAsync(ListingProperty property);
		public Task<ListingProperty?> UpdateAsync(Guid id, ListingProperty property);
		public Task<ListingProperty?> DeleteAsync(Guid id);
		public Task<ListingProperty?> AddListingPropertyValueAsync(Guid id, List<ListingPropertyValue> attributes);
	}
}

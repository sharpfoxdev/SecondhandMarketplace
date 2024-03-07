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
	public interface IAttributeGroupRepository {
		public Task<List<ListingProperty>> GetAllAsync();
		public Task<ListingProperty?> GetByIdAsync(Guid id);
		public Task<ListingProperty> CreateAsync(ListingProperty group);
		public Task<ListingProperty?> UpdateAsync(Guid id, ListingProperty group);
		public Task<ListingProperty?> DeleteAsync(Guid id);
		public Task<ListingProperty?> AddAttributesAsync(Guid id, List<ListingPropertyValue> attributes);
	}
}

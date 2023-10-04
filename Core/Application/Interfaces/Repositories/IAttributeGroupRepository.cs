using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	/// <summary>
	/// Interface defining what operations should we be able to do over AttributeGroup objects.
	/// The implementation of these operations is in Infrastructure/Persistence layer, as it touches the database.
	/// </summary>
	public interface IAttributeGroupRepository {
		public Task<List<AttributeGroup>> GetAllAsync();
		public Task<AttributeGroup?> GetByIdAsync(Guid id);
		public Task<AttributeGroup> CreateAsync(AttributeGroup group);
		public Task<AttributeGroup?> UpdateAsync(Guid id, AttributeGroup group);
		public Task<AttributeGroup?> DeleteAsync(Guid id);
		public Task<AttributeGroup?> AddAttributesAsync(Guid id, List<ListingAttribute> attributes);
	}
}

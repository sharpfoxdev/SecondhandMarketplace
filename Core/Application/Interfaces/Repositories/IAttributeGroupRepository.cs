using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	public interface IAttributeGroupRepository {
		public Task<List<AttributeGroup>> GetAllAsync();
		public Task<AttributeGroup?> GetByIdAsync(Guid id);
		public Task<AttributeGroup> CreateAsync(AttributeGroup listing);
		public Task<AttributeGroup?> UpdateAsync(Guid id, AttributeGroup listing);
		public Task<AttributeGroup?> DeleteAsync(Guid id);
		public Task<AttributeGroup?> AddAttributesAsync(Guid id, List<ListingAttribute> attributes);
	}
}

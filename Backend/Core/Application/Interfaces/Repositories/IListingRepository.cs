using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {

	public interface IListingRepository {
		public Task<List<Listing>> GetAllAsync();
		public Task<Listing?> GetByIdAsync(Guid id);
		public Task<Listing?> CreateAsync(Listing listing, List<IListingPropertyValueSelection> valueSelections);
		public Task<Listing?> UpdateAsync(Guid id, Listing listing);
		public Task<Listing?> DeleteAsync(Guid id);
	}
}

using Domain.Entities.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories {
	internal interface IListingRepository {
		Task<List<BaseListing>> GetAllAsync();
		Task<BaseListing?> GetAsync(Guid id);
		Task<BaseListing?> CreateAsync(BaseListing general);
		Task<BaseListing?> UpdateAsync(Guid id, BaseListing region);

		Task<BaseListing?> DeleteAsync(Guid id);
	}
}

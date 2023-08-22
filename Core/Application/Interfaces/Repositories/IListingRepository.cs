﻿using Domain.Common;
using Domain.Entities.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	/// <summary>
	/// Generic repository for crud operations
	/// </summary>
	public interface IListingRepository {
		public Task<List<T>> GetAllAsync<T>() where T: BaseListing;
		public Task<BaseListing?> GetByIdAsync(Guid id);
		public Task<BaseListing> CreateAsync(BaseListing listing);
		public Task<BaseListing?> UpdateAsync(Guid id, BaseListing listing);
		public Task<BaseListing?> DeleteAsync(Guid id);
	}
}
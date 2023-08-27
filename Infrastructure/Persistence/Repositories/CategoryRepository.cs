using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	public class CategoryRepository : ICategoryRepository {
		public Task<Category> CreateAsync(Category listing) {
			// todo - check, that there is no a listing with the given name - duplicate
			throw new NotImplementedException();
		}

		public Task<Category?> DeleteAsync(Guid id) {
			throw new NotImplementedException();
		}

		public Task<List<Category>> GetAllAsync() {
			throw new NotImplementedException();
		}

		public Task<Category?> GetByIdAsync(Guid id) {
			throw new NotImplementedException();
		}

		public Task<List<Listing>> GetListingsByCategoryNameAsync(string name) {
			throw new NotImplementedException();
		}

		public Task<Category?> UpdateAsync(Guid id, Category listing) {
			throw new NotImplementedException();
		}
	}
}

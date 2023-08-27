using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	public interface ICategoryRepository {
		public Task<List<Category>> GetAllAsync();
		public Task<Category?> GetByIdAsync(Guid id);
		public Task<List<Listing>> GetListingsByCategoryNameAsync(string name);
		public Task<Category> CreateAsync(Category listing);
		public Task<Category?> UpdateAsync(Guid id, Category listing);
		public Task<Category?> DeleteAsync(Guid id);
	}
}

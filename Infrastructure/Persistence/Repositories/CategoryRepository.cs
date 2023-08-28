using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	public class CategoryRepository : ICategoryRepository {
		private readonly MarketplaceDbContext dbContext;

		public CategoryRepository(MarketplaceDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

        public async Task<Category> CreateAsync(Category listing) {
			// todo - check, that there is no a listing with the given name - duplicate
			// can create with attribute groups
			throw new NotImplementedException();
		}

		public async Task<Category?> DeleteAsync(Guid id) {
			// will not delete attribute groups
			throw new NotImplementedException();
		}

		public async Task<List<Category>> GetAllAsync() {
			throw new NotImplementedException();
		}

		public async Task<Category?> GetByIdAsync(Guid id) {
			throw new NotImplementedException();
		}

		public async Task<List<Listing>> GetListingsByCategoryNameAsync(string name) {
			throw new NotImplementedException();
		}

		public async Task<Category?> UpdateAsync(Guid id, Category listing) {
			// will not touch attribute groups
			throw new NotImplementedException();
		}
		public async Task<Category> AddAttributeGroups(List<AttributeGroup> attributeGroups) {
			throw new NotImplementedException();
		}
		public async Task<Category> RemoveAttributeGroupFromCategory(Guid groupId) {
			throw new NotImplementedException();
		}
	}
}

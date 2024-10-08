﻿using Application.Filters;
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
		public Task<List<Listing>> GetListingsByCategoryNameAsync(string name, ListingFilter filter);
		public Task<Category?> GetByNameAsync(string name);
		public Task<Category> CreateAsync(Category category);
		public Task<Category?> UpdateAsync(Guid id, Category category);
		public Task<Category?> DeleteAsync(Guid id);
		public Task<Category?> AddListingPropertiesAsync(Guid categoryId, List<Guid> ListingPropertyIds);
		public Task<Category?> RemoveListingPropertyAsync(Guid categoryId, Guid groupId);
	}
}

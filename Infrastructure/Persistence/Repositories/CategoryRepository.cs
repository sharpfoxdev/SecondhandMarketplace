using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	/// <summary>
	/// Implementation of ICategoryRepository interface using EF Core.  
	/// </summary>
	public class CategoryRepository : ICategoryRepository {
		private readonly MarketplaceDbContext dbContext;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbContext"></param>
		public CategoryRepository(MarketplaceDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		/// <summary>
		/// Checks the database, whether there is a Category with such name. 
		/// </summary>
		/// <param name="categoryName">Category name to search for. </param>
		/// <returns>
		/// True if the category with given name exists, otherwise returns false. 
		/// </returns>
		private async Task<bool> IsExistingCategoryName(string categoryName) {
			var existing = await dbContext.Categories
				.FirstOrDefaultAsync(x => x.Name == categoryName);
			if (existing == null) {
				// no existing category with given name found
				return false;
			}
			return true;
		}
		/// <summary>
		/// Creates new category in the database via the dbContext. 
		/// </summary>
		/// <param name="category">Category to insert into the database. </param>
		/// <returns>
		/// Null if the category with the given name already exists.
		/// Otherwise returns created Category. 
		/// </returns>
        public async Task<Category?> CreateAsync(Category category) {
			// TODO getting attribute groups from the parent
			if (await IsExistingCategoryName(category.Name)) {
				return null;
			}
			dbContext.Categories.Add(category);
			await dbContext.SaveChangesAsync();
			return category;
		}

		/// <summary>
		/// Deletes the category, but doesn't delete the asociated attribute groups.
		/// As attribute groups can be tied to multiple categories (n to n relationship). 
		/// It should just delete entries in the joint table between attribute group and category
		/// in the database. 
		/// </summary>
		/// <param name="id">Id of Category to delete. </param>
		/// <returns>
		/// Null if the Category with the given id was not found.
		/// Otherwise returns the just deleted object. 
		/// </returns>
		public async Task<Category?> DeleteAsync(Guid id) {
			var existing = await dbContext.Categories
				.Include(x => x.Listings)
				.Include(x => x.ParentCategory)
				.Include(x => x.AttributeGroups)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			dbContext.Categories.Remove(existing);
			await dbContext.SaveChangesAsync();
			return existing;
		}
		/// <summary>
		/// Lists all existing categories. 
		/// </summary>
		/// <returns>
		/// List of all Categories. 
		/// </returns>
		public async Task<List<Category>> GetAllAsync() {
			return await dbContext.Categories
				.Include(x => x.Listings)
				.Include(x => x.ParentCategory)
				.Include(x => x.AttributeGroups)
				.ToListAsync();
		}
		/// <summary>
		/// Returns data about given Category by its id.  
		/// </summary>
		/// <param name="id">Id of Category to search for. </param>
		/// <returns>
		/// Returns null, if the Category with such id wasn't found. 
		/// Else returns the Category.
		/// </returns>
		public async Task<Category?> GetByIdAsync(Guid id) {
			var existing = await dbContext.Categories
				.Include(x => x.Listings)
				.Include(x => x.ParentCategory)
				.Include(x => x.AttributeGroups)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			return existing;
		}

		/// <summary>
		/// Used to get Listings by the name of the Category they are in. 
		/// </summary>
		/// <param name="name">Name of Category. </param>
		/// <returns>
		/// Null if a Category with the given name was not found.
		/// Otherwise returns a list of Listings in the given category. 
		/// </returns>
		public async Task<List<Listing>> GetListingsByCategoryNameAsync(string name) {
			// TODO THIS SHOULD ALSO ASK ALL THE SUBCATEGORIES AND LIST THEIR LISTINGS
			var existing = await dbContext.Categories
				.Include(x => x.Listings)
				.Include(x => x.ChildrenCategories)
				.FirstOrDefaultAsync(x => x.Name == name);
			if (existing == null) {
				return null;
			}
			return existing.Listings;
		}

		/// <summary>
		/// Updates the already existing Category. Does not touch AttributeGroups related
		/// to the Category, for that there are methods AddAttributeGroups() and
		/// RemoveAttributeGroupFromCategory(). Checks that we don't try to change the name
		/// of Category to the one that already exists within the database. 
		/// </summary>
		/// <param name="id">Id of Category to update. </param>
		/// <param name="category">Category of updated data. </param>
		/// <returns>
		/// Null if Category we want to update already exists or the name of category
		/// already exists in the database.
		/// Else returns the updated Category
		/// </returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<Category?> UpdateAsync(Guid id, Category category) {
			// will not touch attribute groups
			// gotta check again that we are not inserting already existing name
			// careful with the names, the name can already exist in the database, if it is the one
			// we want to change (ie not to change in this case)
			throw new NotImplementedException();
		}
		/// <summary>
		/// Adds the list of AttributeGroups to the already existing list of AttributeGroups. Adds it also to the whole
		/// subtree. 
		/// </summary>
		/// <param name="id">Id of Category to update. </param>
		/// <param name="attributeGroups">Groups to add. </param>
		/// <returns>
		/// Updated Category. 
		/// Null, if the category was not found. 
		/// </returns>
		public async Task<Category?> AddAttributeGroups(Guid categoryId, List<AttributeGroup> attributeGroups) {
			// TODO checks, that we dont add groups, that are already existing
			var existing = await dbContext.Categories
				.Include(x => x.AttributeGroups)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Id == categoryId);
			throw new NotImplementedException();

		}
		/// <summary>
		/// Gets the Category the highest in the hierarchy and removes the group from the whole subtree
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="groupId"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<Category?> RemoveAttributeGroupFromCategory(Guid categoryId, Guid groupId) {
			throw new NotImplementedException();
		}
	}
}

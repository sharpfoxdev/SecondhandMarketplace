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
		private async Task<bool> IsExistingCategoryNameAsync(string categoryName) {
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
			if (await IsExistingCategoryNameAsync(category.Name)) {
				return null;
			}
			if(category.ParentCategoryId == null) {
				// this is a root category
				await dbContext.Categories.AddAsync(category);
				await dbContext.SaveChangesAsync();
				return category;
			}
			// we dont have to add this category as a child to the parent, because
			// it is enough, when this category knows it's parent

			// add the listing properties from the parent category
			Category parentCategory = await dbContext.Categories.FindAsync(category.ParentCategoryId);
			var parentListingProperties = parentCategory.ListingProperties;
			if(parentListingProperties != null) {
				// can be null for root category
				category.ListingProperties.Concat(parentListingProperties);
			}
			await dbContext.Categories.AddAsync(category);
			await dbContext.SaveChangesAsync();
			return category;
		}

        /// <summary>
        /// Deletes the category, but doesn't delete the asociated ListingProperties.
        /// As ListingProperties can be tied to multiple categories (n to n relationship). 
        /// It should just delete entries in the joint table between ListingProperty and category
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
				.Include(x => x.ListingProperties)
				.Include(x => x.ChildrenCategories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}

			// remove recursively all subcategories
			var deleteTasks = existing.ChildrenCategories.Select(category => DeleteAsync(category.Id));
			await Task.WhenAll(deleteTasks);

			// TODO remove all listings

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
				.Include(x => x.ListingProperties)
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
			// TODO add recursive query for children categories listings
			var existing = await dbContext.Categories
				.Include(x => x.Listings)
				.Include(x => x.ParentCategory)
				.Include(x => x.ListingProperties)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			return existing;
		}

		/// <summary>
		/// Used to get by name
		/// </summary>
		/// <param name="name">Name of Category. </param>
		/// <returns>
		/// Null if a Category with the given name was not found.
		/// Otherwise returns the Category.
		/// </returns>
		public async Task<Category?> GetListingsByCategoryNameAsync(string name) {
			// TODO THIS SHOULD ALSO ASK ALL THE SUBCATEGORIES AND LIST THEIR LISTINGS
			var existing = await dbContext.Categories
				.Include(x => x.Listings)
				.Include(x => x.ParentCategory)
				.Include(x => x.ListingProperties)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Name == name);
			if (existing == null) {
				return null;
			}
			return existing;
		}

        /// <summary>
        /// Updates the already existing Category. Does not touch ListingProperties related
        /// to the Category, for that there are methods AddListingPropertiesAsync() and
        /// RemoveListingPropertyAsync(). Checks that we don't try to change the name
        /// of Category to the one that already exists within the database. 
        /// 
        /// It is also not currently possible to update the parent category of the category, as moving
        /// the category within the tree would mess up the listings, as they would not support
        /// the new parent categories ListingProperties. 
        /// TOCHECK - is this really an issue?
        /// </summary>
        /// <param name="id">Id of Category to update. </param>
        /// <param name="updatedCategory">Category of updated data. </param>
        /// <returns>
        /// Null if Category we want to update already exists or the name of category
        /// already exists in the database.
        /// Else returns the updated Category
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Category?> UpdateAsync(Guid id, Category updatedCategory) {
			var existing = await dbContext.Categories
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				// didnt find what we want to update
				return null;
			}

			// check for the same name in the database. It is ok, to use the same name, just if
			// it is the name of the category, we are updating (ie we are not changing the name
			// of the category and want to keep it the same)
			if(await IsExistingCategoryNameAsync(updatedCategory.Name) && updatedCategory.Name != existing.Name) {
				
				return null;
			}
			existing.Name = updatedCategory.Name;
			await dbContext.SaveChangesAsync();
			return existing;
		}
        /// <summary>
        /// Adds the list of ListingProperties to the already existing list of ListingProperties. Adds it also to the whole
        /// subtree. 
        /// </summary>
        /// <param name="categoryId">Id of Category to update. </param>
        /// <param name="listingPropertyIds">Properties to add. </param>
        /// <returns>
        /// Updated Category. 
        /// Null, if the category was not found. 
        /// </returns>
        public async Task<Category?> AddListingPropertiesAsync(Guid categoryId, List<Guid> listingPropertyIds) {
			var existing = await dbContext.Categories
				.Include(x => x.ListingProperties)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Id == categoryId);
			if (existing == null) {
				return null;
			}

			// Fetch the ListingProperties based on the provided IDs
			var listingProperties = await dbContext.ListingProperties
				.Where(ag => listingPropertyIds.Contains(ag.Id))
				.ToListAsync();

			// Add the ListingProperties to the Category
			foreach (var property in listingProperties) {
				if (existing.ListingProperties.Any(ag => ag.Id == property.Id)) {
					continue; // this ListingProperty already exists in the category
                }
				existing.ListingProperties.Add(property);
			}
            // recursivelly add new ListingProperties to the children categories
            var updateTasks = existing.ChildrenCategories.Select(category => AddListingPropertiesAsync(category.Id, listingPropertyIds));
			await Task.WhenAll(updateTasks);

			await dbContext.SaveChangesAsync();
			return existing;
		}
        /// <summary>
        /// Gets the Category the highest in the hierarchy, that has this ListingProperty
        /// and removes the ListingProperty from the whole subtree
        /// TODO, might need a bit of refactoring to make it clearer
        /// </summary>
        /// <param name="categoryId">Id of category anywhere in the tree</param>
        /// <param name="propertyId">Id of property to remove. </param>
        /// <returns></returns>
        public async Task<Category?> RemoveListingPropertyAsync(Guid categoryId, Guid propertyId) {
			var existingCategory = await dbContext.Categories
				.Include(x => x.ListingProperties)
				.Include(x => x.ParentCategory)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Id == categoryId);
			if (existingCategory == null) {
				return null;
			}

			var existingPropertyIndex = existingCategory.ListingProperties.FindIndex(ag => ag.Id == propertyId);
			if (existingPropertyIndex == -1) {
                // this also works as a base of recursion for traversing the children and parents
                // so that we dont end up in an infinite loop where we would traverse from the
                // parent to the child and back to the parent
                // we couldnt find a ListingProperty with this index
                return null;
			}
			// remove the property from the category
			existingCategory.ListingProperties.RemoveAt(existingPropertyIndex);

			// recursivelly remove the property from the children categories
			var updateTasksChildren = existingCategory.ChildrenCategories.Select(category => RemoveListingPropertyAsync(category.Id, propertyId));
			await Task.WhenAll(updateTasksChildren);

            // Update also parents, if they also have the same ListingProperties, as otherwise it wouldnt
            // be determinitstic, what hap
            if (existingCategory.ParentCategory != null) {
				var updateTasksParents = RemoveListingPropertyAsync(existingCategory.ParentCategory.Id, propertyId);
				await Task.WhenAll(updateTasksParents);
			}

			await dbContext.SaveChangesAsync();
			return existingCategory;
		}
	}
}

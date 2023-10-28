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
				dbContext.Categories.Add(category);
				await dbContext.SaveChangesAsync();
				return category;
			}
			// we dont have to add this category as a child to the parent, because
			// it is enough, when this category knows it's parent

			// add the attribute groups from the parent category
			Category parentCategory = dbContext.Categories.Find(category.ParentCategoryId);
			var parentAttributeGroups = parentCategory.AttributeGroups;
			if(parentAttributeGroups != null) {
				// can be null for root category
				category.AttributeGroups.Concat(parentAttributeGroups);
			}
			/*
				await dbContext.AttributeGroups
				.Include(x => x.Categories)
				.Where(x => x.Categories.Contains(parentCategory))
				.ToListAsync();*/
			/*foreach (var group in parentAttributeGroups) {
				category.AttributeGroups.Add(group);
			}*/
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
			// TODO add recursive query for children categories listings
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
				.Include(x => x.AttributeGroups)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Name == name);
			if (existing == null) {
				return null;
			}
			return existing;
		}

		/// <summary>
		/// Updates the already existing Category. Does not touch AttributeGroups related
		/// to the Category, for that there are methods AddAttributeGroups() and
		/// RemoveAttributeGroupFromCategory(). Checks that we don't try to change the name
		/// of Category to the one that already exists within the database. 
		/// 
		/// It is also not currently possible to update the parent category of the category, as moving
		/// the category within the tree would mess up the listings, as they would not support
		/// the new parent categories attribute groups. 
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
			//existing.AttributeGroupId = updatedAttribute.AttributeGroupId;
			await dbContext.SaveChangesAsync();
			return existing;
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
		public async Task<Category?> AddAttributeGroupsAsync(Guid categoryId, List<Guid> attributeGroupIds) {
			var existing = await dbContext.Categories
				.Include(x => x.AttributeGroups)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Id == categoryId);
			if (existing == null) {
				return null;
			}

			// Fetch the AttributeGroups based on the provided IDs
			var attributeGroups = await dbContext.AttributeGroups
				.Where(ag => attributeGroupIds.Contains(ag.Id))
				.ToListAsync();

			// Add the AttributeGroups to the Category
			foreach (var group in attributeGroups) {
				if (existing.AttributeGroups.Any(ag => ag.Id == group.Id)) {
					continue; // this attribute group already exists in the category
				}
				existing.AttributeGroups.Add(group);
			}
			// recursivelly add new attribute groups to the children categories
			var updateTasks = existing.ChildrenCategories.Select(category => AddAttributeGroupsAsync(category.Id, attributeGroupIds));
			await Task.WhenAll(updateTasks);

			await dbContext.SaveChangesAsync();
			return existing;
		}
		/// <summary>
		/// Gets the Category the highest in the hierarchy, that has this group
		/// and removes the group from the whole subtree
		/// TODO, might need a bit of refactoring to make it clearer
		/// </summary>
		/// <param name="categoryId">Id of category anywhere in the tree</param>
		/// <param name="groupId">Id of group to remove. </param>
		/// <returns></returns>
		public async Task<Category?> RemoveAttributeGroupAsync(Guid categoryId, Guid groupId) {
			var existingCategory = await dbContext.Categories
				.Include(x => x.AttributeGroups)
				.Include(x => x.ParentCategory)
				.Include(x => x.ChildrenCategories) // this might be dangerous, try it out
				.FirstOrDefaultAsync(x => x.Id == categoryId);
			if (existingCategory == null) {
				return null;
			}

			var existingGroupIndex = existingCategory.AttributeGroups.FindIndex(ag => ag.Id == groupId);
			if (existingGroupIndex == -1) {
				// this also works as a base of recursion for traversing the children and parents
				// so that we dont end up in an infinite loop where we would traverse from the
				// parent to the child and back to the parent
				// we couldnt find a group with this index
				return null;
			}
			// remove the group from the category
			existingCategory.AttributeGroups.RemoveAt(existingGroupIndex);

			// recursivelly remove the group from the children categories
			var updateTasksChildren = existingCategory.ChildrenCategories.Select(category => RemoveAttributeGroupAsync(category.Id, groupId));
			await Task.WhenAll(updateTasksChildren);

			// Update also parents, if they also have the same attribute groups, as otherwise it wouldnt
			// be determinitstic, what hap
			if(existingCategory.ParentCategory != null) {
				var updateTasksParents = RemoveAttributeGroupAsync(existingCategory.ParentCategory.Id, groupId);
				await Task.WhenAll(updateTasksParents);
			}

			await dbContext.SaveChangesAsync();
			return existingCategory;
		}
	}
}

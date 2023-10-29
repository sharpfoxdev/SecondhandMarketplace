using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories {
	public class ListingRepository : IListingRepository {
		private readonly MarketplaceDbContext dbContext;

		public ListingRepository(MarketplaceDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		private async Task<Listing?> ValidateAndAddAttributes(Listing listing, List<IAttributeSelection> attributeSelections, Category category) {
			listing.SelectedAttributes = new List<ListingAttribute>();
			// we have to have matching selection for each group in the category
			foreach (var group in category.AttributeGroups) {
				var selection = attributeSelections.Find(selection => selection.AttributeGroupId == group.Id);
				if (selection == null) {
					// matching selection wasnt provided
					return null;
				}
				// check, that the attribute is indeed a part of attribute group
				var attribute = await dbContext.Attributes
					.Include(x => x.AttributeGroup)
					.FirstOrDefaultAsync(x => x.Id == selection.SelectedAttributeId);
				if (attribute == null) {
					return null; // couldnt find such attribute
				}
				if (attribute.AttributeGroup.Id != group.Id) {
					return null; // the group of attribute is not matching required 
				}
				listing.SelectedAttributes.Add(attribute); // creats n to n relationship between listing and attribute
			}
			return listing;
		}
		public async Task<Listing?> CreateAsync(Listing listing, List<IAttributeSelection> attributeSelections) {

			// we get the category of listing we want to create
			var category = dbContext.Categories
				.Include(c => c.AttributeGroups)
				.FirstOrDefault(c => c.Id == listing.CategoryId);

			if (category == null) {
				return null; // couldnt find the category
			}

			Listing? listingWithAttributes = await ValidateAndAddAttributes(listing, attributeSelections, category);
			if(listingWithAttributes == null) {
				return null; // validation failed
			}
			await dbContext.Listings.AddAsync(listing);
			await dbContext.SaveChangesAsync();
			return listing;
		}

		public async Task<Listing?> DeleteAsync(Guid id) {
			var existingListing = await dbContext.Listings.FindAsync(id);
			if (existingListing == null) {
				return null;
			}

			dbContext.Listings.Remove(existingListing);
			await dbContext.SaveChangesAsync();
			return existingListing;
		}

		public async Task<List<Listing>> GetAllAsync() {
			return await dbContext.Listings
				.Include(x => x.Category)
				.Include(x => x.SelectedAttributes)
				.ToListAsync();
		}
		

		public async Task<Listing?> GetByIdAsync(Guid id) {
			var existing = await dbContext.Listings
				.Include(x => x.Category)
				.Include(x => x.SelectedAttributes)
				.FirstOrDefaultAsync(x => x.Id == id);
			if(existing == null) {
				return null; // couldnt find this listing
			}
			return existing;
		}

		public async Task<Listing?> UpdateAsync(Guid id, Listing updatedListing) {
			var existing = await dbContext.Listings.FindAsync(id);
			if (existing == null) {
				return null;
			}
			existing.IsSold = updatedListing.IsSold;
			existing.ListingImageUrl = updatedListing.ListingImageUrl;
			existing.Title = updatedListing.Title;
			existing.Price = updatedListing.Price;
			existing.Description = updatedListing.Description;
			existing.StateOfItemId = updatedListing.StateOfItemId;
			existing.ReasonOfSale = updatedListing.ReasonOfSale;
			await dbContext.SaveChangesAsync();
			return existing;
		}

	}
}

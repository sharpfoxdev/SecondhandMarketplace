using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Common;
using Domain.Entities;
using Infrastructure.FileStorage.Interfaces;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ListingRepository : IListingRepository {
		private readonly MarketplaceDbContext dbContext;
		private readonly IImageRepository imageRepository;

		public ListingRepository(MarketplaceDbContext dbContext, IImageRepository imageRepository)
		{
			this.dbContext = dbContext;
			this.imageRepository = imageRepository;
		}

		private async Task<Listing?> ValidateAndAddPropertyValue(Listing listing, List<IListingPropertyValueSelection> valueSelection, Category category) {
			listing.SelectedListingPropertyValues = new List<ListingPropertyValue>();
			// we have to have matching selection for each property in the category
			foreach (var property in category.ListingProperties) {
				var selection = valueSelection.Find(selection => selection.ListringPropertyId == property.Id);
				if (selection == null) {
					// matching selection wasnt provided
					return null;
				}
				// check, that the value is indeed a part of property
				var propertyValue = await dbContext.ListingPropertyValues
					.Include(x => x.ListingProperty)
					.FirstOrDefaultAsync(x => x.Id == selection.SelectedListingPropertyValueId);
				if (propertyValue == null) {
					return null; // couldnt find such propertyValue
				}
				if (propertyValue.ListingProperty.Id != property.Id) {
					return null; // the property of propertyValue is not matching required 
				}
				listing.SelectedListingPropertyValues.Add(propertyValue); // creats n to n relationship between listing and propertyValue
			}
			return listing;
		}
		public async Task<Listing?> CreateAsync(Listing listing, List<IListingPropertyValueSelection> valueSelections) {

			// we get the category of listing we want to create
			var category = await dbContext.Categories
				.Include(c => c.ListingProperties)
				.FirstOrDefaultAsync(c => c.Id == listing.CategoryId);

			if (category == null) {
				return null; // couldnt find the category
			}

			Listing? listingWithPropertyValues = await ValidateAndAddPropertyValue(listing, valueSelections, category);
			if(listingWithPropertyValues == null) {
				return null; // validation failed
			}
			await dbContext.Listings.AddAsync(listingWithPropertyValues);
			await dbContext.SaveChangesAsync();
			return listingWithPropertyValues;
		}

		public async Task<Listing?> DeleteAsync(Guid id) {
			var existingListing = await dbContext.Listings
				.Include(x => x.Images)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existingListing == null) {
				return null;
			}
			// delete images from the filesystem
			// (we dont have to delete them from the database, because of the cascade delete)
			foreach(Image image in existingListing.Images) {
				imageRepository.DeleteAsync(image.Id);
			}
			dbContext.Listings.Remove(existingListing);
			await dbContext.SaveChangesAsync();
			return existingListing;
		}

		public async Task<List<Listing>> GetAllAsync() {
			return await dbContext.Listings
				.Include(x => x.Category)
				.Include(x => x.SelectedListingPropertyValues)
				.Include(x => x.Images)
				.ToListAsync();
		}
		

		public async Task<Listing?> GetByIdAsync(Guid id) {
			var existing = await dbContext.Listings
				.Include(x => x.Category)
				.Include(x => x.SelectedListingPropertyValues)
					.ThenInclude(x => x.ListingProperty)
				.Include(x => x.Images)
				.Include(x => x.StateOfItem)
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

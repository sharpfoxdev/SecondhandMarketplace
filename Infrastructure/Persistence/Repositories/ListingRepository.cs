﻿using Application.Interfaces;
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

		private async Task<Listing?> ValidateAndAddAttributes(Listing listing, List<IListingPropertyValueSelection> attributeSelections, Category category) {
			listing.SelectedListingPropertyValues = new List<ListingPropertyValue>();
			// we have to have matching selection for each group in the category
			foreach (var group in category.ListingProperties) {
				var selection = attributeSelections.Find(selection => selection.ListringPropertyId == group.Id);
				if (selection == null) {
					// matching selection wasnt provided
					return null;
				}
				// check, that the attribute is indeed a part of attribute group
				var attribute = await dbContext.ListingPropertyValues
					.Include(x => x.ListingProperty)
					.FirstOrDefaultAsync(x => x.Id == selection.SelectedListingPropertyValueId);
				if (attribute == null) {
					return null; // couldnt find such attribute
				}
				if (attribute.ListingProperty.Id != group.Id) {
					return null; // the group of attribute is not matching required 
				}
				listing.SelectedListingPropertyValues.Add(attribute); // creats n to n relationship between listing and attribute
			}
			return listing;
		}
		public async Task<Listing?> CreateAsync(Listing listing, List<IListingPropertyValueSelection> attributeSelections) {

			// we get the category of listing we want to create
			var category = await dbContext.Categories
				.Include(c => c.ListingProperties)
				.FirstOrDefaultAsync(c => c.Id == listing.CategoryId);

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
				.Include(x => x.Images)
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

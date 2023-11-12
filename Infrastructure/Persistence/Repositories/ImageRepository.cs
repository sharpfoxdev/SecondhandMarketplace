using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.FileStorage.Interfaces;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ImageRepository : IImageRepository {
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly MarketplaceDbContext dbContext;

		public ImageRepository(IWebHostEnvironment webHostEnvironment,
			IHttpContextAccessor httpContextAccessor,
			MarketplaceDbContext dbContext) {
			// to get access to images folder on file system
			this.webHostEnvironment = webHostEnvironment;
			// to create URL to image we uploaded 
			// https://localhost:1234/images/image.jpg
			this.httpContextAccessor = httpContextAccessor;
			// db context to save changes to SQL database
			this.dbContext = dbContext;
		}

		public async Task SaveImageToFileSystem(Image image, IFormFile file) {
			var localFilePath = Path.Combine(
				webHostEnvironment.ContentRootPath,
				"Images",
				$"{image.FileName}{image.FileExtension}"
			);
			// uploading image
			using var stream = new FileStream(localFilePath, FileMode.Create);
			await file.CopyToAsync(stream);
		}
		public string CreateImageUrl(Image image) {
			// create url file path
			// https://localhost:1234/images/image.jpg
			string scheme = httpContextAccessor.HttpContext.Request.Scheme; //https
			string host = httpContextAccessor.HttpContext.Request.Host.ToString();//localhost:7192
			string pathBase = httpContextAccessor.HttpContext.Request.PathBase;//""
			var urlFilePath =
				$"{scheme}://{host}{pathBase}/Images/{image.FileName}{image.FileExtension}";
			return urlFilePath;
		}
		public async Task<Image?> UploadAsync(Guid listingId, IFormFile file) {

			// check, that listing to which we want to add image is existing
			var listing = await dbContext.Listings.FindAsync(listingId);
			if(listing == null) {
				// couldnt find the image
				return null;
			}
			var image = new Image {

				FileName = $@"{Guid.NewGuid()}",
				FileExtension = Path.GetExtension(file.FileName),
				FileSizeInBytes = file.Length,
				ListingId = listingId
			};

			await SaveImageToFileSystem(image, file);
			image.ImageUrl = CreateImageUrl(image);

			// Save to the database (Image table)
			await dbContext.Images.AddAsync(image);
			await dbContext.SaveChangesAsync();

			return image;
		}
		public void DeleteImageFromFileSystem(Image image) {
			// remove the image from the filesystem
			var localFilePath = Path.Combine(
				webHostEnvironment.ContentRootPath,
				"Images",
				$"{image.FileName}{image.FileExtension}"
			);
			File.Delete(localFilePath);
		}
		public async Task<Image?> DeleteAsync(Guid id) {
			var existing = await dbContext.Images
				.Include(x => x.Listing)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			DeleteImageFromFileSystem(existing);
			// delete from database
			dbContext.Images.Remove(existing);
			await dbContext.SaveChangesAsync();
			return existing;
		}

		public async Task<List<Image>> GetAllAsync() {
			return await dbContext.Images
				.Include(x => x.Listing)
				.ToListAsync();
		}

		public async Task<Image?> GetByIdAsync(Guid id) {
			var existing = await dbContext.Images
				.Include(x => x.Listing)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) {
				return null;
			}
			return existing;
		}
	}
}

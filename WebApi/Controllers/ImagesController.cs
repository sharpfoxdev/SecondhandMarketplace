using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApi.ApiDtos.Categories;
using WebApi.ApiDtos.Listings;

namespace WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase {
		private readonly IImageRepository repository;

		public ImagesController(IImageRepository repository) {
			this.repository = repository;
		}

		//POST: /api/Images/Upload
		[HttpPost]
		[Route("Upload")]
		public async Task<IActionResult> Upload([FromForm] AddImageRequest request) {
			ValidateFileUpload(request);
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var imageDomain = await repository.UploadAsync(request.ListingId, request.File);
			return Ok(imageDomain);
		}
		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(domain);
		}
		private void ValidateFileUpload(AddImageRequest imageUploadRequestDto) {
			var allowedExtensions = new string[] { ".jpg", "jpeg", ".png" };
			if (!allowedExtensions.Contains(Path.GetExtension(imageUploadRequestDto.File.FileName).ToLower())) {
				ModelState.AddModelError("file", "Invalid file extension");
			}
			long TEN_MB = 10 * 1024 * 1024;
			if (imageUploadRequestDto.File.Length > TEN_MB) {
				ModelState.AddModelError("file", "File size more than 10MB, upload smaller file");
			}
		}
	}
}

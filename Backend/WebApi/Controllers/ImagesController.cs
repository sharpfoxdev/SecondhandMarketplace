using AutoMapper;
using Domain.Entities;
using Infrastructure.FileStorage.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApi.ApiDtos.ListingProperties;
using WebApi.ApiDtos.Categories;
using WebApi.ApiDtos.Images;
using WebApi.ApiDtos.ListingPropertyValues;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase {
		private readonly IImageRepository repository;
		private readonly IMapper mapper;

		public ImagesController(IImageRepository repository, IMapper mapper) {
			this.repository = repository;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var domain = await repository.GetAllAsync();
			return Ok(mapper.Map<List<ImageDto>>(domain));
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetById(Guid id) {
			var domain = await repository.GetByIdAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ImageDto>(domain));
		}


		//POST: /api/Images/Upload
		[HttpPost]
		[Route("Upload")]
		public async Task<IActionResult> Upload([FromForm] AddImageRequest request) {
			ValidateFileUpload(request);
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var domain = await repository.UploadAsync(request.ListingId, request.File);
			return Ok(mapper.Map<ImageDto>(domain));
		}
		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id) {
			var domain = await repository.DeleteAsync(id);
			if (domain == null) {
				return NotFound();
			}
			return Ok(mapper.Map<ImageDto>(domain));
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

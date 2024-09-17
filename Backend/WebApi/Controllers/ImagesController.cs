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
    /// <summary>
    /// Controller for managing image operations such as retrieving, uploading, and deleting images.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of ImagesController
        /// </summary>
        /// <param name="repository">Repository to handle image-related operations.</param>
        /// <param name="mapper">Mapper to convert between domain models and DTOs.</param>
        public ImagesController(IImageRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieves all images.
        /// </summary>
        /// <returns>A list of all images.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await repository.GetAllAsync();
            return Ok(mapper.Map<List<ImageDto>>(domain));
        }

        /// <summary>
        /// Retrieves an image by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the image.</param>
        /// <returns>The requested image or NotFound if the image doesn't exist.</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var domain = await repository.GetByIdAsync(id);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ImageDto>(domain));
        }

        /// <summary>
        /// Uploads a new image.
        /// </summary>
        /// <param name="request">The request containing the listing ID and the file to upload.</param>
        /// <returns>The uploaded image or an error if the file is invalid.</returns>
        /// <remarks>
        /// This method checks file size and extension before uploading. It only allows .jpg, .jpeg, and .png files, and the file size must not exceed 10MB.
        /// </remarks>
        // POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] AddImageRequest request)
        {
            ValidateFileUpload(request);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domain = await repository.UploadAsync(request.ListingId, request.File);
            return Ok(mapper.Map<ImageDto>(domain));
        }

        /// <summary>
        /// Deletes an image by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the image to delete.</param>
        /// <returns>The deleted image or NotFound if the image doesn't exist.</returns>
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var domain = await repository.DeleteAsync(id);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ImageDto>(domain));
        }

        /// <summary>
        /// Validates the uploaded file.
        /// </summary>
        /// <param name="imageUploadRequestDto">The request object containing the file to validate.</param>
        /// <remarks>
        /// This method ensures that only allowed file extensions (.jpg, .jpeg, .png) are accepted, 
        /// and the file size is limited to 10MB.
        /// </remarks>
        private void ValidateFileUpload(AddImageRequest imageUploadRequestDto)
        {
            var allowedExtensions = new string[] { ".jpg", "jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(imageUploadRequestDto.File.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Invalid file extension");
            }
            long TEN_MB = 10 * 1024 * 1024;
            if (imageUploadRequestDto.File.Length > TEN_MB)
            {
                ModelState.AddModelError("file", "File size more than 10MB, upload smaller file");
            }
        }
    }
}

using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileStorage.Interfaces
{
    /// <summary>
    /// Repository for images. This interface is here, because I dont want to import package, in
    /// which the IFormFile is defined, to the Application project. 
    /// </summary>
    public interface IImageRepository
    {
        public Task<List<Image>> GetAllAsync();
        public Task<Image?> GetByIdAsync(Guid id);
        Task<Image?> UploadAsync(Guid listingId, IFormFile file);
        Task<Image?> DeleteAsync(Guid id);
    }
}

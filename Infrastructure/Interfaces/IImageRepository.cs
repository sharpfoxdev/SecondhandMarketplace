using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Repository for images. This interface is here, because I dont want to import package, in
    /// which the IFormFile is defined, to the Application project. 
    /// </summary>
    public interface IImageRepository
    {
        Task<Image?> UploadAsync(Guid listingId, IFormFile file);

    }
}

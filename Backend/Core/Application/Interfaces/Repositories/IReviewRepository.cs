using Application.Filters;
using Application.Pagination;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IReviewRepository
    {
        public Task<Page<Review>> GetAllByReviewerAsync(Guid id, int pageNumber = 1, int pageSize = 20);
        public Task<Page<Review>> GetAllByRevieweeAsync(Guid id, int pageNumber = 1, int pageSize = 20);
        public Task<Review?> CreateAsync(Review review);
    }
}

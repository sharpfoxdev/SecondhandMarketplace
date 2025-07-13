using Application.Interfaces.Repositories;
using Application.Pagination;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly MarketplaceDbContext dbContext;

        public ReviewRepository(MarketplaceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Review?> CreateAsync(Review review)
        {
            if (review.CreatedAt == default)
                review.CreatedAt = DateTime.Now;
            await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Page<Review>> GetAllByRevieweeAsync(Guid revieweeId, int pageNumber = 1, int pageSize = 20)
        {
            var query = dbContext.Reviews
                                 .Where(r => r.RevieweeId == revieweeId)
                                 .OrderByDescending(r => r.CreatedAt);

            var total = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Page<Review>(items, total, pageNumber, pageSize);
        }

        public async Task<Page<Review>> GetAllByReviewerAsync(Guid reviewerId, int pageNumber = 1, int pageSize = 20)
        {
            var query = dbContext.Reviews
                                 .Where(r => r.ReviewerId == reviewerId)
                                 .OrderByDescending(r => r.CreatedAt);

            var total = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new Page<Review>(items, total, pageNumber, pageSize);
        }
    }
}

using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Identity;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApi.ApiDtos;
using WebApi.ApiDtos.Listings;
using WebApi.ApiDtos.Reviews;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewsController(IReviewRepository reviewRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateReviewRequest request)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
                return Unauthorized();

            var domain = mapper.Map<Review>(request);
            domain.ReviewerId = userId;
            domain.CreatedAt = DateTime.Now;

            var created = await reviewRepository.CreateAsync(domain);
            if (created == null)
                return BadRequest("Unable to create review.");

            var dto = mapper.Map<ReviewDto>(created);
            dto.Reviewer = mapper.Map<UserDto>(await userManager.FindByIdAsync(userId.ToString()));
            return Ok(dto);
        }

        [HttpGet("byReviewee/{revieweeId}")]
        public async Task<IActionResult> GetByReviewee(Guid revieweeId, int pageNumber = 1, int pageSize = 20)
        {
            var page = await reviewRepository
                           .GetAllByRevieweeAsync(revieweeId, pageNumber, pageSize);
            var reviews = page.Items;

            var reviewerIds = reviews.Select(r => r.ReviewerId).Distinct().ToList();
            var users = await userManager.Users
                .Where(u => reviewerIds.Contains(u.Id))
                .ToListAsync();
            var userDtoMap = users
                .Select(u => mapper.Map<UserDto>(u))
                .ToDictionary(u => u.Id);

            var dtos = reviews.Select(r =>
            {
                var dto = mapper.Map<ReviewDto>(r);
                dto.Reviewer = userDtoMap[r.ReviewerId];
                return dto;
            }).ToList();

            var result = new PageDto<ReviewDto>
            {
                Items = dtos,
                TotalPages = page.TotalPages,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(result);
        }
    }
}

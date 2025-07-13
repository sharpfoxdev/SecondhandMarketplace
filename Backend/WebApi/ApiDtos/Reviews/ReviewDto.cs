namespace WebApi.ApiDtos.Reviews
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public UserDto Reviewer { get; set; }
        public Guid RevieweeId { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

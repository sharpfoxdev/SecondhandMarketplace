namespace WebApi.ApiDtos.Reviews
{
    public class CreateReviewRequest
    {
        public Guid RevieweeId { get; set; }
        public string ReviewText { get; set; }
    }
}

namespace WebApi.ApiDtos.Images
{
    public class AddImageRequest
    {
        public IFormFile File { get; set; }
        public Guid ListingId { get; set; }
    }
}

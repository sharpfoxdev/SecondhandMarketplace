namespace WebApi.ApiDtos.Image
{
    public class AddImageRequest
    {
        public IFormFile File { get; set; }
        public Guid ListingId { get; set; }
    }
}

namespace WebApi.ApiDtos.Cities
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
    }
}

using Domain.Entities.Listings.CommonProperties;

namespace Domain.Entities.Listings.Sleeping.Hammocks
{
    public class Hammock : Sleeping
    {
        public HammockBrand HammockBrand { get; set; }
        public Guid HammockBrandId { get; set; }
        public Color Color { get; set; }
        public Guid ColorId { get; set; }
    }
}

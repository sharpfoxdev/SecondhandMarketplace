using Marketplace.API.Models.Domain.Categories.CommonProperties;

namespace Marketplace.API.Models.Domain.Categories.Sleeping.Hammocks
{
    public class Hammock : Sleeping
    {
        public HammockBrand HammockBrand { get; set; }
        public Guid HammockBrandId { get; set; }
        public Color Color { get; set; }
        public Guid ColorId { get; set; }
    }
}

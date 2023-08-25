
namespace Domain.Entities.Listings
{
    public class Hammock : Sleeping
    {
        public HammockBrand HammockBrand { get; set; }
        public Guid HammockBrandId { get; set; }
        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            HammockBrandId = ((Hammock)updatedListing).HammockBrandId;
            ColorId = ((Hammock)updatedListing).ColorId;
        }
    }
}

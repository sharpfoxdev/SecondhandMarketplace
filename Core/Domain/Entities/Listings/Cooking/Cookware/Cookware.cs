
namespace Domain.Entities.Listings
{
    /// <summary>
    /// Anything, that you use to eat. 
    /// </summary>
    public class Cookware : Cooking
    {
        // brand
        public CookwareBrand CookwareBrand { get; set; }
        public Guid CookwareBrandId { get; set; }

        // type
        public CookwareType CookwareType { get; set; }
        public Guid CookwareTypeId { get; set; }

        // material
        public CookwareMaterial CookwareMaterial { get; set; }
        public Guid CookwareMaterialId { get; set; }

        // color
        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            CookwareBrandId = ((Cookware)updatedListing).CookwareBrandId;
            CookwareTypeId = ((Cookware)updatedListing).CookwareTypeId;
            CookwareMaterialId = ((Cookware)updatedListing).CookwareMaterialId;
            ColorId = ((Cookware)updatedListing).ColorId;
        }
    }
}

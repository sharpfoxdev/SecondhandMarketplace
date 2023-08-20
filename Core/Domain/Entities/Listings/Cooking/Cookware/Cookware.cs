using Domain.Entities.Listings.CommonProperties;

namespace Domain.Entities.Listings.Cooking.Cookware
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
    }
}

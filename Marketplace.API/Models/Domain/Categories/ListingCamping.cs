namespace Marketplace.API.Models.Domain.Categories
{
    /// <summary>
    /// Marketplace specific list of properties, that all listings
    /// in this specific marketplace (Camping) will have. 
    /// 
    /// A step in hierarchy between ListingGeneral, which has general
    /// properties regardless of the marketplace type, and the hierarchy
    /// of marketplace specific listings
    /// </summary>
    public class ListingCamping : ListingGeneral
    {
        public bool Ultralight { get; set; }
        public float? Weight { get; set; }
    }
}

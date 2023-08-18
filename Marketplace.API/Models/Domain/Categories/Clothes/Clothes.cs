using Marketplace.API.Models.Domain.Categories.CommonProperties;

namespace Marketplace.API.Models.Domain.Categories.Clothes
{

    /// <summary>
    /// Caregory of outdoor clothing
    /// </summary>
    public class Clothes : ListingCamping
    {

        // TODO maybe make some of the following properties lists,
        // because for example clothes may have multiple colors

        // size - S, M, L, XL, ...
        public ClothesSize ClothesSize { get; set; }
        public Guid ClothesSizeId { get; set; }

        // brand - nike, adidas, ...
        public ClothesBrand ClothesBrand { get; set; }
        public Guid ClothesBrandId { get; set; }

        // color
        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        // gender - male, female, ...
        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        // type - pants, shirt, etc.
        public ClothesType ClothesType { get; set; }
        public Guid ClothesTypeId { get; set; }

    }
}

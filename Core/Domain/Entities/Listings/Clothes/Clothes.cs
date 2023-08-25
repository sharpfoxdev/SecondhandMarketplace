namespace Domain.Entities.Listings
{

    /// <summary>
    /// Caregory of outdoor clothing
    /// </summary>
    public class Clothes : CampingListing
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
        public override void Update(BaseListing updatedListing)
        {
            base.Update(updatedListing);
            ClothesSizeId = ((Clothes)updatedListing).ClothesSizeId;
            ClothesBrandId = ((Clothes)updatedListing).ClothesBrandId;
            ColorId = ((Clothes)updatedListing).ColorId;
            GenderId = ((Clothes)updatedListing).GenderId;
            ClothesTypeId = ((Clothes)updatedListing).ClothesTypeId;
        }


    }
}

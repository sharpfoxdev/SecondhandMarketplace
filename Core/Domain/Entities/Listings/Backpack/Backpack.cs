using Domain.Entities.Listings.CommonProperties;

namespace Domain.Entities.Listings.Backpack {

	/// <summary>
	/// Catagory of outdoor backpacks. 
	/// </summary>
	public class Backpack : CampingListing {

		// backpack brand - Osprey, Deuter, Gregory, etc.
		public BackpackBrand BackpackBrand { get; set; }
		public Guid BackpackBrandId { get; set; }

		// backpack type - backpack, bag, pouch, etc.
		public BackpackType BackpackType { get; set; }
		public Guid BackpackTypeId { get; set; }

		// color - red, blue, green, etc.
		public Color Color { get; set; }
		public Guid ColorId { get; set; }

		// volume - size of the backpack - 45 litres 
		public float? Volume { get; set; }
		public override void Update(BaseListing updatedListing) {
			base.Update(updatedListing);
			BackpackBrandId = ((Backpack)updatedListing).BackpackBrandId;
			BackpackTypeId = ((Backpack)updatedListing).BackpackTypeId;
			ColorId = ((Backpack)updatedListing).ColorId;
			Volume = ((Backpack)updatedListing).Volume;
		}
	}
}

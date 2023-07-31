namespace Marketplace.API.Models.Domain {
	public enum ClothesSize {
		S,
		M,
		L,
		XL,
		XXL
	}
	public enum Gender {
		Male, 
		Female,
		Both
	}
	public class Clothes : GeneralListing {
		public ClothesSize Size { get; set; }
		public Gender Gender { get; set; }
		public string RandomProperty { get; set; }
	}
}

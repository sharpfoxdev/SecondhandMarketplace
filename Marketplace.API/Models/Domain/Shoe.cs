namespace Marketplace.API.Models.Domain {

	/// <summary>
	/// Category of outdoor shoes. 
	/// </summary>
	public class Shoe {
		// shoe brand - Nike, Adidas, etc.
		public ShoeBrand ShoeBrand { get; set; }
		public Guid ShoeBrandId { get; set; }

		// shoe type - high, mid, low, sandals, running, ... 
		public ShoeType ShoeType { get; set; }
		public Guid ShoeTypeId { get; set; }

		// shoe size - 39, 40, ...
		public ShoeSize ShoeSize { get; set; }
		public Guid ShoeSizeId { get; set; }

		// color - red, blue, green, etc.
		public Color Color { get; set; }
		public Guid ColorId { get; set; }

		// gender - unisex, men, women, children, ...
		public Gender Gender { get; set; }
		public Guid GenderId { get; set; }

	}
}

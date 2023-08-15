namespace Marketplace.API.Models.Domain {
	/// <summary>
	/// Shoe type - high, mid, low, sandals, running, ...
	/// 
	/// Just the czech mutation for now. 
	/// 
	/// Used instead making children further from Shoe.cs category, as there wouldn't
	/// be any new properties.
	/// </summary>
	public class ShoeType {
		public Guid Id { get; set; }
		public string CzechName { get; set; }
	}
}

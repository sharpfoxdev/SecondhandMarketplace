using Domain.Common;

namespace Domain.Entities.Listings.Backpack {
	/// <summary>
	/// Backpack brand - Osprey, Deuter, Gregory, etc.
	/// </summary>
	public class BackpackBrand : IEntity {
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}

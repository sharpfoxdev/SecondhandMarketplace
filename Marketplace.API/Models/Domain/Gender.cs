namespace Marketplace.API.Models.Domain {

	/// <summary>
	/// Male, female, unisex, kids, currently just the czech mutation
	/// </summary>
	public class Gender {
		public Guid Id { get; set; }
		public string CzechName { get; set; }
	}
}

namespace Marketplace.API.Models.Domain {
	/// <summary>
	/// This might change quite a bit, depending on how will the 
	/// auth database work. 
	/// </summary>
	public class UserProfile {
		public Guid Id { get; set; }
		public string Nickname { get; set; }
		public string Email { get; set; }
		//public string Password { get; set; }
		public City City { get; set; }
	}
}

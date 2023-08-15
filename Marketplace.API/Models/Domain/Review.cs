namespace Marketplace.API.Models.Domain {

	/// <summary>
	/// User rating one another after a transaction. Buyer rates the seller
	/// and the other way around as well. 
	/// </summary>
	public class Review {
		public Guid Id { get; set; }
		// TODO 1-5
		public int Rating { get; set; }
		public string? Description { get; set; }

		// Rater is the person doing the rating
		public UserProfile Rater { get; set; }
		public Guid RaterId { get; set; }

		// Ratee is the person being rated
		public UserProfile Ratee { get; set; }
		public Guid RateeId { get; set; }

	}
}

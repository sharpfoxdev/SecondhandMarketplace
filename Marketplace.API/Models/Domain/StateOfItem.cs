namespace Marketplace.API.Models.Domain {
	/// <summary>
	/// State of the item - new, used, good, ...
	/// 
	/// Columns for the czech mutation
	/// </summary>
	public class StateOfItem {
		public Guid Id { get; set; }
		public string CzechName { get; set; }
		// description, what does the state mean
		public string CzechDescription { get; set; }
	}
}

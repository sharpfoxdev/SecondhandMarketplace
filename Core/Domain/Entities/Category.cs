using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {

	/// <summary>
	/// Category of listings. For example "Clothes", "Electronics", "Tents" etc. Used for
	/// browsing the listings.
	/// </summary>
	public class Category : IEntity {
		public Guid Id { get; set; }
		public string Name { get; set; }
		/// <summary>
		/// 1 to many relationship with itself. Creates a tree of Categories.
		/// </summary>
		public Guid? ParentCategoryId { get; set; }

		/// <summary>
		/// Navigation property to the parent category.
		/// </summary>
		public Category? ParentCategory { get; set; }

		/// <summary>
		/// Navigation property to the children categories. 
		/// </summary>
		public List<Category> ChildrenCategories { get; set; }

		/// <summary>
		/// Has all the attribute groups that the parent categories have in the tree
		/// of categories as well as the attribute groups specific for this category. 
		/// Attribute groups are kind of fakely "inherited" from the parent categories
		/// upon the creation of the Category and this is also reflected all the operations, that are done
		/// over the Category. 
		/// </summary>
		public List<ListingProperty> ListingProperties { get; set; }

		/// <summary>
		/// All listings that are in this Category. One to many relationship, 
		/// listing can belong just to one category.
		/// </summary>
		public List<Listing> Listings { get; set; }
	}
}

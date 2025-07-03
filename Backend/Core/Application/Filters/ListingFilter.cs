using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Filters
{
    public enum Ordering { Price, CreatedAt }
    public enum OrderingDirection { Ascending, Descending }
    public class ListingFilter
    {
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public Guid? Seller { get; set; }
        public Guid? City { get; set; }
        public int? Radius { get; set; }
        public string Search {  get; set; }
        public Ordering Ordering { get; set; } = Ordering.CreatedAt;
        public OrderingDirection OrderingDirection { get; set; } = OrderingDirection.Descending;
        public List<Guid> StateOfItemIds { get; set; }
        public List<Guid> SelectedListingPropertyValueIds { get; set; }

        // todo smazat
        public IEnumerable<Listing> Filter(IEnumerable<Listing> listings, List<ListingProperty> categoryProperties)
        {
            var filtered = listings.Where(listing => IsInPriceRange(listing) && IsInStateOfItem(listing) && HasSelectedListingPropertyValues(listing, categoryProperties));
            //List<Listing> filtered = new List<Listing>();
            //foreach (var listing in listings) {
            //    if(IsInPriceRange(listing) && IsInStateOfItem(listing) && HasSelectedListingPropertyValues(listing, categoryProperties))
            //    {
            //        filtered.Add(listing);
            //    }
            //}
            return filtered;
        }
        private bool IsInPriceRange(Listing listing)
        {
            bool isBiggerThanPriceMin = true;
            bool isLessThanPriceMax = true;
            if(PriceMin != null)
            {
                if (PriceMin > listing.Price) { isBiggerThanPriceMin = false; }
            }
            if(PriceMax != null) { 
                if (PriceMax < listing.Price) { isLessThanPriceMax = false; } 
            }
            return isBiggerThanPriceMin && isLessThanPriceMax;
        }
        /// <summary>
        /// Listing has to have state of item, that matches one of the selected
        /// state of items (OR filter)
        /// </summary>
        /// <param name="listing"></param>
        /// <returns></returns>
        private bool IsInStateOfItem(Listing listing) {
            if (!StateOfItemIds.Any()) {
                // we didnt select any state of items, so we dont have anything to filter on
                return true; 
            }
            foreach(var id in StateOfItemIds)
            {
                if (listing.StateOfItemId == id) { return true; }
            }
            return false;
        }
        /// <summary>
        /// Properties are ANDed, property values are ORed. So if we have properties Size and Color in some
        /// category, we want to have separate matches in both of these properties. When we select Red and Green
        /// values in the Color property, we want the listing to have Red or Green color, not necessarily both of
        /// them at the same time. 
        /// </summary>
        /// <param name="listing"></param>
        /// <param name="categoryPropertyValues"></param>
        /// <returns></returns>
        private bool HasSelectedListingPropertyValues(Listing listing, List<ListingProperty> categoryProperties) {
            foreach(var property in categoryProperties)
            {
                var selectedPropertyValuesInFilter = property.ListingPropertyValues.Where(x => SelectedListingPropertyValueIds.Contains(x.Id));
                if (!selectedPropertyValuesInFilter.Any()) {
                    // we didnt select any values for this property in the filter, so we don't have anything to filter on
                    continue;
                }
                var matchedValues = 0;
                foreach(var propertyValue in selectedPropertyValuesInFilter)
                {
                    if (listing.SelectedListingPropertyValues.Contains(propertyValue)) {  matchedValues++; }
                }
                // did not get a match for this property, so the whole AND between properties evaluates to false
                if(matchedValues == 0)
                {
                    return false;
                }
            }
            // found matches in all properties
            return true;
        }
    }
}

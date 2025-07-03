using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Filters listings by price range
        /// </summary>
        public static IQueryable<Listing> FilterByPrice(this IQueryable<Listing> query, ListingFilter filter)
        {
            if (filter.PriceMin.HasValue)
            {
                query = query.Where(listing => listing.Price >= filter.PriceMin.Value);
            }
            if (filter.PriceMax.HasValue)
            {
                query = query.Where(listing => listing.Price <= filter.PriceMax.Value);
            }
            return query;
        }

        /// <summary>
        /// Filters listings by state of item (OR across selected states)
        /// </summary>
        public static IQueryable<Listing> FilterByStateOfItem(this IQueryable<Listing> query, ListingFilter filter)
        {
            if (filter.StateOfItemIds?.Any() == true)
            {
                query = query.Where(listing => filter.StateOfItemIds.Contains(listing.StateOfItemId));
            }
            return query;
        }

        /// <summary>
        /// Filters listings by selected listing property values,
        /// AND across properties, OR within each property values
        /// </summary>
        public static IQueryable<Listing> FilterByProperties(this IQueryable<Listing> query, ListingFilter filter, IEnumerable<ListingProperty> categoryProperties)
        {
            if (filter.SelectedListingPropertyValueIds?.Any() != true || categoryProperties == null)
                return query;

            var groups = categoryProperties
                .Select(property => new
                {
                    PropertyId = property.Id,
                    ValueIds = property.ListingPropertyValues
                        .Where(v => filter.SelectedListingPropertyValueIds.Contains(v.Id))
                        .Select(v => v.Id)
                })
                .Where(g => g.ValueIds.Any());

            foreach (var group in groups)
            {
                var propertyId = group.PropertyId;
                var valueIds = group.ValueIds;
                query = query.Where(listing =>
                    listing.SelectedListingPropertyValues
                     .Where(v => v.ListingPropertyId == propertyId)
                     .Any(v => valueIds.Contains(v.Id))
                );
            }

            return query;
        }

        /// <summary>
        /// Filters listings by seller.
        /// </summary>
        public static IQueryable<Listing> FilterBySeller(this IQueryable<Listing> query, ListingFilter filter)
        {
            if (filter.Seller.HasValue)
            {
                query = query.Where(l => l.SellerId == filter.Seller.Value);
            }
            return query;
        }



        /// <summary>
        /// Filters listings within a radius of the chosen city
        /// </summary>
        public static IQueryable<Listing> FilterByRadius(this IQueryable<Listing> query, ListingFilter filter, City? chosenCity)
        {
            if (filter.City.HasValue && filter.Radius.HasValue && chosenCity != null)
            {
                query = query.Where(listing =>
                    listing.CityId == chosenCity.Id ||
                    listing.City.Location.IsWithinDistance(chosenCity.Location, filter.Radius.Value));
            }
            return query;
        }

        /// <summary>
        /// Applies sorting by either CreatedAt or Price, in the specified direction.
        /// </summary>
        public static IQueryable<Listing> ApplyOrdering(this IQueryable<Listing> query, ListingFilter filter)
        {
            bool asc = filter.OrderingDirection == OrderingDirection.Ascending;
            return filter.Ordering switch
            {
                Ordering.Price => asc
                    ? query.OrderBy(l => l.Price)
                    : query.OrderByDescending(l => l.Price),
                _ => asc
                    ? query.OrderBy(l => l.CreatedAt)
                    : query.OrderByDescending(l => l.CreatedAt)
            };
        }

        /// <summary>
        /// Applies all configured filters (price, state, properties)
        /// </summary>
        public static IQueryable<Listing> ApplyFilters(this IQueryable<Listing> query,ListingFilter filter, IEnumerable<ListingProperty> categoryProperties, City? chosenCity = null)
        {
            return query
                .FilterByPrice(filter)
                .FilterByStateOfItem(filter)
                .FilterByProperties(filter, categoryProperties)
                .FilterByRadius(filter, chosenCity);
        }
    }
}

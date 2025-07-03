using Application.Filters;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Filters
{
    /// <summary>
    /// Performs a diacritics insensitive fulltext search on selected fields
    /// it uses MySQL accent-insensitive collation https://dev.mysql.com/doc/refman/8.4/en/charset-unicode-sets.html#charset-unicode-sets-general-versus-unicode
    /// </summary>
    public static class QueriableExtensionsMySQL
    {
        private const string collation = "utf8mb4_general_ci";

        public static IQueryable<Listing> FilterBySearch(this IQueryable<Listing> query, ListingFilter filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Search))
                return query;

            var term = filter.Search.Trim();
            var pattern = $"%{term}%";

            return query.Where(listing =>
                EF.Functions.Like(
                    EF.Functions.Collate(listing.Title, collation),
                    EF.Functions.Collate(pattern, collation))
                || EF.Functions.Like(
                    EF.Functions.Collate(listing.Description, collation),
                    EF.Functions.Collate(pattern, collation)));
        }
        public static IQueryable<City> FilterBySearch(this IQueryable<City> query, string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return query;

            var term = search.Trim();
            var pattern = $"%{term}%";

            return query.Where(city =>
                EF.Functions.Like(
                    EF.Functions.Collate(city.Name, collation),
                    EF.Functions.Collate(pattern, collation))
                || EF.Functions.Like(
                    EF.Functions.Collate(city.ZipCode, collation),
                    EF.Functions.Collate(pattern, collation)));
        }
        public static IQueryable<ApplicationUser> FilterBySearch(this IQueryable<ApplicationUser> query, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return query;

            var term = search.Trim();
            var pattern = $"%{term}%";

            return query.Where(user =>
                EF.Functions.Like(
                    EF.Functions.Collate(user.Nickname, collation),
                    EF.Functions.Collate(pattern, collation))
                || EF.Functions.Like(
                    EF.Functions.Collate(user.Email, collation),
                    EF.Functions.Collate(pattern, collation)));
        }
    }
}

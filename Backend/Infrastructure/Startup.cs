using Application.Interfaces.Repositories;
using Infrastructure.FileStorage.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{

    /// <summary>
    /// Setup of dependency injections, the methods are called from Program.cs in WebApi
    /// </summary>
    public static class Startup {
		public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            var host = Environment.GetEnvironmentVariable("MYSQL_HOST");
            //var port = Environment.GetEnvironmentVariable("MYSQL_PORT");
            var database = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
            var user = Environment.GetEnvironmentVariable("MYSQL_USER");
            var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
            var connectionString = $"server={host};user={user};database={database};password={password};";
			var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
			return services.AddDbContext<MarketplaceDbContext>(
				dbContextOptions => dbContextOptions
					.UseMySql(connectionString, serverVersion, options => options.UseNetTopologySuite())
					// The following three options help with debugging, but should
					// be changed or removed for production.
					.LogTo(Console.WriteLine, LogLevel.Information)
					.EnableSensitiveDataLogging()
					.EnableDetailedErrors()
			).AddScoped<IListingRepository, ListingRepository>()
			.AddScoped<IListingPropertyRepository, ListingPropertyRepository>()
			.AddScoped<ICategoryRepository, CategoryRepository>()
			.AddScoped<IListingPropertyValueRepository, ListingPropertyValueRepository>()
			.AddScoped<IImageRepository, ImageRepository>()
			.AddScoped<ITokenRepository, TokenRepository>()
			.AddHttpContextAccessor()
			.AddIdentity(); //possibly move elsewhere
		}
		public static IServiceCollection AddIdentity(this IServiceCollection services) {
			return services
				.AddIdentity<ApplicationUser, ApplicationRole>(options => {
						options.Password.RequireDigit = false;
						options.Password.RequireLowercase = false;
						options.Password.RequireNonAlphanumeric = false;
						options.Password.RequireUppercase = false;
						options.Password.RequiredLength = 6;
						options.Password.RequiredUniqueChars = 1;
						options.User.RequireUniqueEmail = true;
					})
				.AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("Marketplace")
				.AddEntityFrameworkStores<MarketplaceDbContext>()
				.AddDefaultTokenProviders().Services;
		}
	}
}

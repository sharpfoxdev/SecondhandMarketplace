﻿using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
			// TODO MOVE CONNECTION STRING
			var connectionString = "server=localhost;user=testUser;password=testPassword;database=marketplace;";
			var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
			// Replace 'YourDbContext' with the name of your own DbContext derived class.
			return services.AddDbContext<MarketplaceDbContext>(
				dbContextOptions => dbContextOptions
					.UseMySql(connectionString, serverVersion, options => options.UseNetTopologySuite())
					// The following three options help with debugging, but should
					// be changed or removed for production.
					.LogTo(Console.WriteLine, LogLevel.Information)
					.EnableSensitiveDataLogging()
					.EnableDetailedErrors()
			).AddScoped<IListingRepository, ListingRepository>();
		}
	}
}

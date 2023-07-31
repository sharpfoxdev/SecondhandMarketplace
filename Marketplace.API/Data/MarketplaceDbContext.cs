using Marketplace.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.API.Data {
	public class MarketplaceDbContext : DbContext {
		public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }

		public DbSet<Clothes> Clothes { get; set; }
		public DbSet<GeneralListing> GeneralListings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<GeneralListing>().HasDiscriminator<string>("Discriminator")
				.HasValue<Clothes>("Clothes");
			modelBuilder.Entity<Clothes>().HasBaseType<GeneralListing>();
			var generalListings = new List<GeneralListing>() {
				new GeneralListing { 
					Id = Guid.Parse("8ee116e1-24c8-4421-97ec-75d6904d33c7"), 
					Description = "Easy",
					ReasonOfSale = "I don't need it anymore",
					RandomIntProperty = 1
				}
			};
			modelBuilder.Entity<GeneralListing>().HasData(generalListings);
			var clothes = new List<Clothes>() {
				new Clothes {
					Id = Guid.Parse("cacdc277-499a-4232-95f5-a5e1f5767d1c"),
					Description = "A nice shirt",
					ReasonOfSale = "I don't need it anymore",
					RandomIntProperty = 2,
					Size = ClothesSize.S,
					Gender = Gender.Both,
					RandomProperty = "Random"
				}
			};
			modelBuilder.Entity<Clothes>().HasData(clothes);
		}
	}
}

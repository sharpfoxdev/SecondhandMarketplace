using Marketplace.API.Models.Domain.Categories;
using Marketplace.API.Models.Domain.Categories.Backpacks;
using Marketplace.API.Models.Domain.Categories.Clothes;
using Marketplace.API.Models.Domain.Categories.CommonProperties;
using Marketplace.API.Models.Domain.Categories.Cooking;
using Marketplace.API.Models.Domain.Categories.Cooking.Cookware;
using Marketplace.API.Models.Domain.Categories.Cooking.Stoves;
using Marketplace.API.Models.Domain.Categories.Gear;
using Marketplace.API.Models.Domain.Categories.Gear.Binoculars;
using Marketplace.API.Models.Domain.Categories.Gear.Electronics;
using Marketplace.API.Models.Domain.Categories.Gear.KnivesMultitools;
using Marketplace.API.Models.Domain.Categories.Gear.Lighting;
using Marketplace.API.Models.Domain.Categories.Gear.TrekkingPoles;
using Marketplace.API.Models.Domain.Categories.Shoes;
using Marketplace.API.Models.Domain.Categories.Sleeping;
using Marketplace.API.Models.Domain.Categories.Sleeping.Hammocks;
using Marketplace.API.Models.Domain.Categories.Sleeping.SleepAccessories;
using Marketplace.API.Models.Domain.Categories.Sleeping.SleepingBags;
using Marketplace.API.Models.Domain.Categories.Sleeping.SleepingPads;
using Marketplace.API.Models.Domain.Categories.Sleeping.Tarps;
using Marketplace.API.Models.Domain.Categories.Sleeping.Tents;
using Marketplace.API.Models.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.API.Data
{
    public class MarketplaceDbContext : DbContext {
		public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }

		//categories
		public DbSet<ListingGeneral> GeneralListings { get; set; }
		public DbSet<ListingCamping> ListingCampings { get; set; }

		// backpacks
		public DbSet<Backpack> Backpacks { get; set; }

		//clothes
		public DbSet<Clothes> Clothes { get; set; }
		
		// cooking
		public DbSet<Cooking> Cooking { get; set; }
		public DbSet<Cookware> Cookware { get; set; }
		public DbSet<Stove> Stoves { get; set; }
		public DbSet<OtherCooking> OtherCooking { get; set; }

		// gear
		public DbSet<Gear> Gear { get; set; }
		public DbSet<Binoculars> Binoculars { get; set; }
		public DbSet<Electronics> Electronics { get; set; }
		public DbSet<KnifeMultitool> KnifeMultitools { get; set; }
		public DbSet<Lighting> Lightings { get; set; }
		public DbSet<TrekkingPole> TrekkingPoles { get; set; }
		public DbSet<OtherGear> OtherGear { get; set; }

		// shoes
		public DbSet<Shoe> Shoes { get; set; }
		
		// sleeping
		public DbSet<Sleeping> Sleeping { get; set; }
		public DbSet<Hammock> Hammocks { get; set; }
		public DbSet<SleepAccessory> SleepAccessories { get; set; }
		public DbSet<SleepingBag> SleepingBags { get; set; } 
		public DbSet<SleepingPad> SleepingPads { get; set; }
		public DbSet<Tarp> Tarps { get; set; }
		public DbSet<Tent> Tents { get; set; }
		public DbSet<OtherSleeping> OtherSleeping { get; set; }

		// User
		public DbSet<UserProfile> UserProfiles { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			/*modelBuilder.Entity<ListingGeneral>().HasDiscriminator<string>("Discriminator")
				.HasValue<ListingCamping>("Camping")
				.HasValue<Backpack>("Backpack")
				.HasValue<Clothes>("Clothes")
				.HasValue<Cooking>("Cooking")
				.HasValue<Cookware>("Cookware")
				.HasValue<Stove>("Stove")
				.HasValue<OtherCooking>("OtherCooking")
				.HasValue<Gear>("Gear")
				.HasValue<Binoculars>("Binoculars")
				.HasValue<Electronics>("Electronics")
				.HasValue<KnifeMultitool>("KnifeMultitool")
				.HasValue<Lighting>("Lighting")
				.HasValue<TrekkingPole>("TrekkingPole")
				.HasValue<OtherGear>("OtherGear")
				.HasValue<Shoe>("Shoe")
				.HasValue<Sleeping>("Sleeping")
				.HasValue<Hammock>("Hammock")
				.HasValue<SleepAccessory>("SleepAccessory")
				.HasValue<SleepingBag>("SleepingBag")
				.HasValue<SleepingPad>("SleepingPad")
				.HasValue<Tarp>("Tarp")
				.HasValue<Tent>("Tent")
				.HasValue<OtherSleeping>("OtherSleeping");*/


			/*modelBuilder.Entity<GeneralListing>().HasDiscriminator<string>("Discriminator")
				.HasValue<Clothes>("Clothes");*/
			//modelBuilder.Entity<Clothes>().HasBaseType<ListingGeneral>();
			/*var generalListings = new List<ListingGeneral>() {
				new ListingGeneral { 
					Id = Guid.Parse("8ee116e1-24c8-4421-97ec-75d6904d33c7"), 
					Description = "Easy",
					ReasonOfSale = "I don't need it anymore",
				}
			};*/
			//modelBuilder.Entity<ListingGeneral>().HasData(generalListings);
			/*var clothes = new List<Clothes>() {
				new Clothes {
					Id = Guid.Parse("cacdc277-499a-4232-95f5-a5e1f5767d1c"),
					Description = "A nice shirt",
					ReasonOfSale = "I don't need it anymore",
					RandomIntProperty = 2,
					Size = ClothesSize.S,
					Gender = Gender.Both,
					RandomProperty = "Random"
				}
			};*/
			//modelBuilder.Entity<Clothes>().HasData(clothes);
		}
	}
}

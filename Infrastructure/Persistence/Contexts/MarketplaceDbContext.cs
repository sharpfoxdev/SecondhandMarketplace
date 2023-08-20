using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Listings;
using Domain.Entities.Listings.Backpack;
using Domain.Entities.Listings.Clothes;
using Domain.Entities.Listings.Cooking;
using Domain.Entities.Listings.Cooking.Cookware;
using Domain.Entities.Listings.Cooking.Stoves;
using Domain.Entities.Listings.Gear;
using Domain.Entities.Listings.Gear.Binoculars;
using Domain.Entities.Listings.Gear.Electronics;
using Domain.Entities.Listings.Gear.KnivesMultitools;
using Domain.Entities.Listings.Gear.Lighting;
using Domain.Entities.Listings.Gear.TrekkingPoles;
using Domain.Entities.Listings.Shoes;
using Domain.Entities.Listings.Sleeping;
using Domain.Entities.Listings.Sleeping.Hammocks;
using Domain.Entities.Listings.Sleeping.SleepAccessories;
using Domain.Entities.Listings.Sleeping.SleepingBags;
using Domain.Entities.Listings.Sleeping.SleepingPads;
using Domain.Entities.Listings.Sleeping.Tarps;
using Domain.Entities.Listings.Sleeping.Tents;

namespace Infrastructure.Persistence.Contexts
{
    public class MarketplaceDbContext : DbContext
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }

        //categories
        public DbSet<BaseListing> Listings { get; set; }
        public DbSet<CampingListing> CampingListing { get; set; }

        // backpacks
        public DbSet<Backpack> Backpack { get; set; }

        //clothes
        public DbSet<Clothes> Clothes { get; set; }

        // cooking
        public DbSet<Cooking> Cooking { get; set; }
        public DbSet<Cookware> Cookware { get; set; }
        public DbSet<Stove> Stove { get; set; }
        public DbSet<OtherCooking> OtherCooking { get; set; }

        // gear
        public DbSet<Gear> Gear { get; set; }
        public DbSet<Binoculars> Binoculars { get; set; }
        public DbSet<Electronics> Electronics { get; set; }
        public DbSet<KnifeMultitool> KnifeMultitool { get; set; }
        public DbSet<Lighting> Lighting { get; set; }
        public DbSet<TrekkingPole> TrekkingPole { get; set; }
        public DbSet<OtherGear> OtherGear { get; set; }

        // shoes
        public DbSet<Shoe> Shoes { get; set; }

        // sleeping
        public DbSet<Sleeping> Sleeping { get; set; }
        public DbSet<Hammock> Hammock { get; set; }
        public DbSet<SleepAccessory> SleepAccessory { get; set; }
        public DbSet<SleepingBag> SleepingBag { get; set; }
        public DbSet<SleepingPad> SleepingPad { get; set; }
        public DbSet<Tarp> Tarp { get; set; }
        public DbSet<Tent> Tent { get; set; }
        public DbSet<OtherSleeping> OtherSleeping { get; set; }
    }
}

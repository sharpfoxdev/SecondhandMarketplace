﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class MarketplaceDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }
        public DbSet<ListingAttribute> Attributes { get; set; }
        public DbSet<StateOfItem> StateOfItem { get; set; }
		public DbSet<Image> Images { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder) {

			// without this for some reason the EF couldnt determine
			// the relationship between Listing and Image
			modelBuilder.Entity<Image>()
				.HasOne(i => i.Listing)  // Image has one Listing
				.WithMany(l => l.Images) // Listing has many Images
				.HasForeignKey(i => i.ListingId); // Foreign key on Image

			// Additional configurations for your Listing entity (if needed)
			modelBuilder.Entity<Listing>()
				.HasMany(l => l.Images) // Listing has many Images
				.WithOne(i => i.Listing) // Images have one Listing
				.HasForeignKey(i => i.ListingId); // Foreign key on Image

			modelBuilder.Entity<Listing>()
				.HasOne<ApplicationUser>()  // Define the ApplicationUser relationship
				.WithMany()
				.HasForeignKey("SellerId");
			base.OnModelCreating(modelBuilder);

			var adminRoleId = "e8c9ac14-c7f6-4991-88aa-ad40bfe8f707";
			var userRoleId = "2d39b4e7-843e-410b-b6e4-ae30e38039f4";
			var devRoleId = "996f9a95-c46c-40fa-9bb6-144a05138cdc";
			var roles = new List<ApplicationRole> {
				new ApplicationRole {
					Id = new Guid(adminRoleId),
					ConcurrencyStamp = adminRoleId,
					Name = "Admin",
					NormalizedName = "Admin".ToUpper()
				},
				new ApplicationRole {
					Id = new Guid(userRoleId),
					ConcurrencyStamp = userRoleId,
					Name = "User",
					NormalizedName = "User".ToUpper()
				},
				new ApplicationRole {
					Id = new Guid(devRoleId),
					ConcurrencyStamp = devRoleId,
					Name = "Developer",
					NormalizedName = "Developer".ToUpper()
				}
			};
			modelBuilder.Entity<ApplicationRole>().HasData(roles);

			List<AttributeGroup> attributeGroups = new List<AttributeGroup>() {
                new AttributeGroup {
                    Id = Guid.Parse("9091889f-ed33-48a0-979e-875968b305fe"),
                    Name = "BackpackBrand"
				},
				new AttributeGroup {
					Id = Guid.Parse("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"),
					Name = "BackpackType"
				}, 
				new AttributeGroup {
					Id = Guid.Parse("72697394-56b3-4ed8-851f-b74e28454616"),
					Name = "BinocularsType"
				}
			};
			modelBuilder.Entity<AttributeGroup>().HasData(attributeGroups);

			List<ListingAttribute> attributes = new List<ListingAttribute> {
				new ListingAttribute {
					Id = Guid.Parse("b567cbd5-d49d-427d-a90f-1d94f8cd5c8e"),
					Name = "Monokulár",
					AttributeGroupId = Guid.Parse("72697394-56b3-4ed8-851f-b74e28454616")
				},
				new ListingAttribute {
					Id = Guid.Parse("c62d49f3-0294-4e9a-9411-5a392f719b76"),
					Name = "Binokulár",
					AttributeGroupId = Guid.Parse("72697394-56b3-4ed8-851f-b74e28454616")
				},
				new ListingAttribute {
					Id = Guid.Parse("8dd8cbb6-03a9-4220-b343-d4c5a283283b"),
					Name = "Batoh",
					AttributeGroupId = Guid.Parse("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3")
				},
				new ListingAttribute {
					Id = Guid.Parse("ba38e3c6-777c-4dbd-87bd-450206c7e49a"),
					Name = "Sumka",
					AttributeGroupId = Guid.Parse("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3")
				},
				new ListingAttribute {
					Id = Guid.Parse("d882ac03-d93e-41c6-8503-2d2fd47acac5"),
					Name = "Taška",
					AttributeGroupId = Guid.Parse("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3")
				},

				new ListingAttribute {
					Id = Guid.Parse("13b902a9-c0e4-4799-80d8-56206eb1acc8"),
					Name = "Patizon",
					AttributeGroupId = Guid.Parse("9091889f-ed33-48a0-979e-875968b305fe")
				},
				new ListingAttribute {
					Id = Guid.Parse("3f5fd110-e73f-46fe-bb92-3a8094e3cbcb"),
					Name = "Sir Joseph",
					AttributeGroupId = Guid.Parse("9091889f-ed33-48a0-979e-875968b305fe")
				},
				new ListingAttribute {
					Id = Guid.Parse("4f53489e-90b3-43ad-b51c-aa65f301b984"),
					Name = "Prima",
					AttributeGroupId = Guid.Parse("9091889f-ed33-48a0-979e-875968b305fe")
				}
			};
			modelBuilder.Entity<ListingAttribute>().HasData(attributes);
			List<Category> categories = new List<Category> {
				new Category {
					Id = Guid.Parse("c1b9b3a0-3b7e-4b6e-9e4a-3e9b8b3e8b9e"),
					Name = "Batohy",
					AttributeGroups = new List<AttributeGroup> {
						attributeGroups[0],
						attributeGroups[1]
					}
				},
				new Category {
					Id = Guid.Parse("c1b9b3a0-3b7e-4b6e-9e4a-3e9b8b3e8b9e"),
					Name = "Dalekohledy",
					AttributeGroups = new List<AttributeGroup> {
						attributeGroups[2],
					}
				},
			};
			//modelBuilder.Entity<Category>().HasData(categories);

		}


	}
}

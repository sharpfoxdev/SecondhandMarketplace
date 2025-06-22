using Microsoft.EntityFrameworkCore;
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
    public class MarketplaceDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ListingProperty> ListingProperties { get; set; }
        public DbSet<ListingPropertyValue> ListingPropertyValues { get; set; }
        public DbSet<StateOfItem> StateOfItem { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Conversation> Conversations { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<ConversationParticipant> ConversationParticipant { get; set; }
		public DbSet<City> Cities { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Listing>()
				.HasOne<ApplicationUser>()  // Define the ApplicationUser relationship
				.WithMany(u => u.Listings)
				.HasForeignKey("SellerId");

            modelBuilder.Entity<ConversationParticipant>()
                .HasKey(cp => new { cp.ConversationId, cp.UserId });

            modelBuilder.Entity<ConversationParticipant>()
                .HasOne(cp => cp.Conversation)
                .WithMany(c => c.ConversationParticipants)
                .HasForeignKey(cp => cp.ConversationId);

            modelBuilder.Entity<ConversationParticipant>()
                .HasOne<ApplicationUser>()
                .WithMany(u => u.ConversationParticipants)
                .HasForeignKey(cp => cp.UserId);
            modelBuilder.Entity<Message>()
                .HasOne<ApplicationUser>()
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.SenderId);
            modelBuilder.Entity<City>(builder =>
            {
                builder.Property(city => city.Location)
				.HasColumnType("POINT SRID 4326")
                .IsRequired();
            });


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

			List<ListingProperty> attributeGroups = new List<ListingProperty>() {
                new ListingProperty {
                    Id = Guid.Parse("9091889f-ed33-48a0-979e-875968b305fe"),
                    Name = "BackpackBrand"
				},
				new ListingProperty {
					Id = Guid.Parse("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"),
					Name = "BackpackType"
				}, 
				new ListingProperty {
					Id = Guid.Parse("72697394-56b3-4ed8-851f-b74e28454616"),
					Name = "BinocularsType"
				}
			};
			modelBuilder.Entity<ListingProperty>().HasData(attributeGroups);

			List<ListingPropertyValue> attributes = new List<ListingPropertyValue> {
				new ListingPropertyValue {
					Id = Guid.Parse("b567cbd5-d49d-427d-a90f-1d94f8cd5c8e"),
					Name = "Monokulár",
					ListingPropertyId = Guid.Parse("72697394-56b3-4ed8-851f-b74e28454616")
				},
				new ListingPropertyValue {
					Id = Guid.Parse("c62d49f3-0294-4e9a-9411-5a392f719b76"),
					Name = "Binokulár",
					ListingPropertyId = Guid.Parse("72697394-56b3-4ed8-851f-b74e28454616")
				},
				new ListingPropertyValue {
					Id = Guid.Parse("8dd8cbb6-03a9-4220-b343-d4c5a283283b"),
					Name = "Batoh",
					ListingPropertyId = Guid.Parse("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3")
				},
				new ListingPropertyValue {
					Id = Guid.Parse("ba38e3c6-777c-4dbd-87bd-450206c7e49a"),
					Name = "Sumka",
					ListingPropertyId = Guid.Parse("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3")
				},
				new ListingPropertyValue {
					Id = Guid.Parse("d882ac03-d93e-41c6-8503-2d2fd47acac5"),
					Name = "Taška",
					ListingPropertyId = Guid.Parse("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3")
				},

				new ListingPropertyValue {
					Id = Guid.Parse("13b902a9-c0e4-4799-80d8-56206eb1acc8"),
					Name = "Patizon",
					ListingPropertyId = Guid.Parse("9091889f-ed33-48a0-979e-875968b305fe")
				},
				new ListingPropertyValue {
					Id = Guid.Parse("3f5fd110-e73f-46fe-bb92-3a8094e3cbcb"),
					Name = "Sir Joseph",
					ListingPropertyId = Guid.Parse("9091889f-ed33-48a0-979e-875968b305fe")
				},
				new ListingPropertyValue {
					Id = Guid.Parse("4f53489e-90b3-43ad-b51c-aa65f301b984"),
					Name = "Prima",
					ListingPropertyId = Guid.Parse("9091889f-ed33-48a0-979e-875968b305fe")
				}
			};
			modelBuilder.Entity<ListingPropertyValue>().HasData(attributes);
			List<Category> categories = new List<Category> {
				new Category {
					Id = Guid.Parse("c1b9b3a0-3b7e-4b6e-9e4a-3e9b8b3e8b9e"),
					Name = "Batohy",
					ListingProperties = new List<ListingProperty> {
						attributeGroups[0],
						attributeGroups[1]
					}
				}
			};
			//modelBuilder.Entity<Category>().HasData(categories);
			List<StateOfItem> stateOfItems = new List<StateOfItem> {
				new StateOfItem {
					Id = Guid.Parse("2e0e5d47-2ff5-421e-945e-9fdc08cc762d"),
					Name = "Nový"
				}
			};
			modelBuilder.Entity<StateOfItem>().HasData(stateOfItems);

		}


	}
}

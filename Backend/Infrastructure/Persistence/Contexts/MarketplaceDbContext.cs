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
		public DbSet<Review> Reviews { get; set; }
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
			modelBuilder.Entity<Review>(builder =>
			{
                builder.HasKey(r => r.Id);
                builder.Property(r => r.ReviewText)
					.IsRequired();
				builder.HasOne<ApplicationUser>()
				 .WithMany(u => u.ReviewsGiven)
				 .HasForeignKey(r => r.ReviewerId);
				builder.HasOne<ApplicationUser>()
				 .WithMany(u => u.ReviewsReceived)
				 .HasForeignKey(r => r.RevieweeId);
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

		}
	}
}

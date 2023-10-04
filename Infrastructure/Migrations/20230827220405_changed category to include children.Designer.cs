﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MarketplaceDbContext))]
    [Migration("20230827220405_changed category to include children")]
    partial class changedcategorytoincludechildren
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AttributeGroupCategory", b =>
                {
                    b.Property<Guid>("AttributeGroupsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("char(36)");

                    b.HasKey("AttributeGroupsId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("AttributeGroupCategory");
                });

            modelBuilder.Entity("Domain.Entities.AttributeGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AttributeGroups");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9091889f-ed33-48a0-979e-875968b305fe"),
                            Name = "BackpackBrand"
                        },
                        new
                        {
                            Id = new Guid("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"),
                            Name = "BackpackType"
                        },
                        new
                        {
                            Id = new Guid("72697394-56b3-4ed8-851f-b74e28454616"),
                            Name = "BinocularsType"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Listing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsSold")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ListingImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ReasonOfSale")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StateOfItemId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StateOfItemId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("Domain.Entities.ListingAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AttributeGroupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AttributeGroupId");

                    b.ToTable("Attributes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b567cbd5-d49d-427d-a90f-1d94f8cd5c8e"),
                            AttributeGroupId = new Guid("72697394-56b3-4ed8-851f-b74e28454616"),
                            Name = "Monokulár"
                        },
                        new
                        {
                            Id = new Guid("c62d49f3-0294-4e9a-9411-5a392f719b76"),
                            AttributeGroupId = new Guid("72697394-56b3-4ed8-851f-b74e28454616"),
                            Name = "Binokulár"
                        },
                        new
                        {
                            Id = new Guid("8dd8cbb6-03a9-4220-b343-d4c5a283283b"),
                            AttributeGroupId = new Guid("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"),
                            Name = "Batoh"
                        },
                        new
                        {
                            Id = new Guid("ba38e3c6-777c-4dbd-87bd-450206c7e49a"),
                            AttributeGroupId = new Guid("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"),
                            Name = "Sumka"
                        },
                        new
                        {
                            Id = new Guid("d882ac03-d93e-41c6-8503-2d2fd47acac5"),
                            AttributeGroupId = new Guid("e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3"),
                            Name = "Taška"
                        },
                        new
                        {
                            Id = new Guid("13b902a9-c0e4-4799-80d8-56206eb1acc8"),
                            AttributeGroupId = new Guid("9091889f-ed33-48a0-979e-875968b305fe"),
                            Name = "Patizon"
                        },
                        new
                        {
                            Id = new Guid("3f5fd110-e73f-46fe-bb92-3a8094e3cbcb"),
                            AttributeGroupId = new Guid("9091889f-ed33-48a0-979e-875968b305fe"),
                            Name = "Sir Joseph"
                        },
                        new
                        {
                            Id = new Guid("4f53489e-90b3-43ad-b51c-aa65f301b984"),
                            AttributeGroupId = new Guid("9091889f-ed33-48a0-979e-875968b305fe"),
                            Name = "Prima"
                        });
                });

            modelBuilder.Entity("Domain.Entities.StateOfItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StateOfItem");
                });

            modelBuilder.Entity("ListingListingAttribute", b =>
                {
                    b.Property<Guid>("ListingsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SelectedAttributesId")
                        .HasColumnType("char(36)");

                    b.HasKey("ListingsId", "SelectedAttributesId");

                    b.HasIndex("SelectedAttributesId");

                    b.ToTable("ListingListingAttribute");
                });

            modelBuilder.Entity("AttributeGroupCategory", b =>
                {
                    b.HasOne("Domain.Entities.AttributeGroup", null)
                        .WithMany()
                        .HasForeignKey("AttributeGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.HasOne("Domain.Entities.Category", "ParentCategory")
                        .WithMany("ChildrenCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Domain.Entities.Listing", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Listings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.StateOfItem", "StateOfItem")
                        .WithMany()
                        .HasForeignKey("StateOfItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("StateOfItem");
                });

            modelBuilder.Entity("Domain.Entities.ListingAttribute", b =>
                {
                    b.HasOne("Domain.Entities.AttributeGroup", "AttributeGroup")
                        .WithMany("Attributes")
                        .HasForeignKey("AttributeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeGroup");
                });

            modelBuilder.Entity("ListingListingAttribute", b =>
                {
                    b.HasOne("Domain.Entities.Listing", null)
                        .WithMany()
                        .HasForeignKey("ListingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ListingAttribute", null)
                        .WithMany()
                        .HasForeignKey("SelectedAttributesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AttributeGroup", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("ChildrenCategories");

                    b.Navigation("Listings");
                });
#pragma warning restore 612, 618
        }
    }
}

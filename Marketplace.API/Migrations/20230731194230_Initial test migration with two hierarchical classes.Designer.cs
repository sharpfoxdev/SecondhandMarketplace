﻿// <auto-generated />
using System;
using Marketplace.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marketplace.API.Migrations
{
    [DbContext(typeof(MarketplaceDbContext))]
    [Migration("20230731194230_Initial test migration with two hierarchical classes")]
    partial class Initialtestmigrationwithtwohierarchicalclasses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Marketplace.API.Models.Domain.GeneralListing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneralListings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("GeneralListing");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Marketplace.API.Models.Domain.Clothes", b =>
                {
                    b.HasBaseType("Marketplace.API.Models.Domain.GeneralListing");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Clothes");
                });
#pragma warning restore 612, 618
        }
    }
}
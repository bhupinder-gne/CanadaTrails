﻿// <auto-generated />
using System;
using CanadaTrails.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CanadaTrails.Migrations
{
    [DbContext(typeof(CanadaTrailsDbContext))]
    [Migration("20240524155813_Created Seed Data")]
    partial class CreatedSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CanadaTrails.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("349cfa2e-07ad-4c20-adf9-1e73d1d41f53"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("11f2c8bc-4783-4f36-a97a-d7cf020d5503"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("ae27d1da-dd2b-4ffb-8042-92efc6b6c525"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("CanadaTrails.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5da48e5-758e-4476-b202-f2f3e5586858"),
                            Code = "WLK",
                            Name = "Walker",
                            RegionImageUrl = "walker.jpg"
                        },
                        new
                        {
                            Id = new Guid("227c67d9-7b35-4445-8ab2-7c9de5899b72"),
                            Code = "SMS",
                            Name = "Summer Side",
                            RegionImageUrl = "summerSide.jpg"
                        },
                        new
                        {
                            Id = new Guid("6bf45a00-d01d-4352-a84b-ded1341ce41c"),
                            Code = "AUR",
                            Name = "Aurora",
                            RegionImageUrl = "aurora.jpg"
                        });
                });

            modelBuilder.Entity("CanadaTrails.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("CanadaTrails.Models.Domain.Walk", b =>
                {
                    b.HasOne("CanadaTrails.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CanadaTrails.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
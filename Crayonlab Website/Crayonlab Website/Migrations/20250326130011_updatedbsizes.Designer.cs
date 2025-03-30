﻿// <auto-generated />
using Crayonlab.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250326130011_updatedbsizes")]
    partial class updatedbsizes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Crayonlab.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Crayonlab.Models.BasketballJersey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MenLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenMPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortsDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WomenLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenMPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("BasketballJerseys");
                });

            modelBuilder.Entity("Crayonlab.Models.Designs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MenLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenMPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortsDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WomenLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenMPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Designs");
                });

            modelBuilder.Entity("Crayonlab.Models.Longsleeve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MenLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenMPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortsDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WomenLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenMPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Longsleeves");
                });

            modelBuilder.Entity("Crayonlab.Models.Soccerjersey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MenLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenMPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MenXXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortsDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WomenLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenMPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXSPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WomenXXLPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Soccerjerseys");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Crayonlab.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Crayonlab.Models.NewsandUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewsandUpdate");
                });

            modelBuilder.Entity("Crayonlab.Models.Partners", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("Crayonlab.Models.ShirtDesign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FrontDesign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShirtTypeId")
                        .HasColumnType("int");

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

                    b.HasIndex("ShirtTypeId");

                    b.ToTable("ShirtDesigns");
                });

            modelBuilder.Entity("Crayonlab.Models.ShirtType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShirtTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Corporate shirts collection",
                            Name = "Corporate"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Basketball jerseys collection",
                            Name = "Basketball"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Soccer jerseys collection",
                            Name = "Soccer"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Long sleeve shirts collection",
                            Name = "LongSleeve"
                        });
                });

            modelBuilder.Entity("Crayonlab.Models.ShirtDesign", b =>
                {
                    b.HasOne("Crayonlab.Models.ShirtType", "ShirtType")
                        .WithMany("ShirtDesigns")
                        .HasForeignKey("ShirtTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ShirtType");
                });

            modelBuilder.Entity("Crayonlab.Models.ShirtType", b =>
                {
                    b.Navigation("ShirtDesigns");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThunderWings.Api.Data;

#nullable disable

namespace ThunderWings.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ThunderWings.Api.Models.Domain.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopSpeed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aircrafts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "United States of America",
                            Manufacturer = "Lockheed Martin",
                            Name = "F-22 Raptor",
                            Price = 150000000m,
                            Role = "Air superiority fighter",
                            TopSpeed = 1498
                        },
                        new
                        {
                            Id = 2,
                            Country = "United States of America",
                            Manufacturer = "Lockheed Martin",
                            Name = "F-22 Raptor",
                            Price = 150000000m,
                            Role = "Air superiority fighter",
                            TopSpeed = 1498
                        },
                        new
                        {
                            Id = 3,
                            Country = "Russia",
                            Manufacturer = "Sukhoi",
                            Name = "Su-57",
                            Price = 70000000m,
                            Role = "Air superiority fighter",
                            TopSpeed = 1520
                        },
                        new
                        {
                            Id = 4,
                            Country = "European consortium (Germany, Spain, Italy, and the United Kingdom)",
                            Manufacturer = "Airbus, BAE Systems, Leonardo, and others",
                            Name = "Eurofighter Typhoon",
                            Price = 100000000m,
                            Role = "Multirole fighter",
                            TopSpeed = 1550
                        },
                        new
                        {
                            Id = 5,
                            Country = "United States of America",
                            Manufacturer = "Boeing",
                            Name = "F-15 Eagle",
                            Price = 30000000m,
                            Role = "Air superiority fighter",
                            TopSpeed = 1650
                        },
                        new
                        {
                            Id = 6,
                            Country = "France",
                            Manufacturer = "Dassault Aviation",
                            Name = "Rafale",
                            Price = 80000000m,
                            Role = "Multirole fighter",
                            TopSpeed = 1912
                        },
                        new
                        {
                            Id = 7,
                            Country = "China",
                            Manufacturer = "Chengdu Aerospace Corporation",
                            Name = "J-20",
                            Price = 110000000m,
                            Role = "Air superiority fighter",
                            TopSpeed = 1305
                        },
                        new
                        {
                            Id = 8,
                            Country = "Sweden",
                            Manufacturer = "Saab",
                            Name = "Gripen E",
                            Price = 85000000m,
                            Role = "Multirole fighter",
                            TopSpeed = 1372
                        },
                        new
                        {
                            Id = 9,
                            Country = "Russia",
                            Manufacturer = "Mikoyan",
                            Name = "MiG-35",
                            Price = 40000000m,
                            Role = "Multirole fighter",
                            TopSpeed = 1491
                        },
                        new
                        {
                            Id = 10,
                            Country = "United States of America",
                            Manufacturer = "Boeing",
                            Name = "F/A-18 Super Hornet",
                            Price = 70000000m,
                            Role = "Multirole fighter",
                            TopSpeed = 1190
                        },
                        new
                        {
                            Id = 11,
                            Country = "India",
                            Manufacturer = "Hindustan Aeronautics Limited (HAL)",
                            Name = "HAL Tejas",
                            Price = 40000000m,
                            Role = "Multirole fighter",
                            TopSpeed = 1370
                        });
                });

            modelBuilder.Entity("ThunderWings.Api.Models.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            City = "Eros",
                            Name = "Customer001",
                            PostalCode = "123abc",
                            State = "Texas",
                            StreetAddress = "Test St"
                        },
                        new
                        {
                            Id = "2",
                            City = "Eros",
                            Name = "Customer002",
                            PostalCode = "123abc",
                            State = "Texas",
                            StreetAddress = "Test St"
                        });
                });

            modelBuilder.Entity("ThunderWings.Api.Models.Domain.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AircraftId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("OrderHeaderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ThunderWings.Api.Models.Domain.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("ThunderWings.Api.Models.Domain.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AircraftId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("ThunderWings.Api.Models.Domain.OrderDetail", b =>
                {
                    b.HasOne("ThunderWings.Api.Models.Domain.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThunderWings.Api.Models.Domain.OrderHeader", "OrderHeader")
                        .WithMany()
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("ThunderWings.Api.Models.Domain.OrderHeader", b =>
                {
                    b.HasOne("ThunderWings.Api.Models.Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("ThunderWings.Api.Models.Domain.ShoppingCart", b =>
                {
                    b.HasOne("ThunderWings.Api.Models.Domain.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThunderWings.Api.Models.Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("ApplicationUser");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using CarShowroom.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarShowroom.Dal.Migrations
{
    [DbContext(typeof(CarShowroomContext))]
    [Migration("20230208225354_AddedVAGEngineInitialData")]
    partial class AddedVAGEngineInitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarShowroom.Dal.Entities.Automobile", b =>
                {
                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int?>("BodyType")
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("Color")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VIN");

                    b.HasIndex("BrandId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ModelId");

                    b.ToTable("Automobiles");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "VAG",
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "VAG",
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 3,
                            CompanyName = "Daimler",
                            Name = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = 4,
                            CompanyName = "PSA Groupe",
                            Name = "Citroen"
                        },
                        new
                        {
                            Id = 5,
                            CompanyName = "PSA Groupe",
                            Name = "Peugeot"
                        });
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Company", b =>
                {
                    b.Property<string>("CompanyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CompanySite")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CompanyName");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyName = "VAG",
                            CompanySite = "vag.com"
                        },
                        new
                        {
                            CompanyName = "Daimler",
                            CompanySite = "daimler.com"
                        },
                        new
                        {
                            CompanyName = "PSA Groupe",
                            CompanySite = "psa.com"
                        });
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("EngineCapacity")
                        .HasColumnType("float");

                    b.Property<int?>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Power")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName");

                    b.ToTable("Engines");

                    b.HasCheckConstraint("CK_Engine_EngineCapacity", "EngineCapacity > -1 AND EngineCapacity < 1000000");

                    b.HasCheckConstraint("CK_Engine_Power", "Power > -1 AND Power < 2000000");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "VAG",
                            EngineCapacity = 2.0,
                            FuelType = 0,
                            Name = "CCZB",
                            Power = 210
                        });
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.HasIndex("ModelId");

                    b.ToTable("Equipments");

                    b.HasCheckConstraint("CK_Equipment_Price", "Price >= 0");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Automobile", b =>
                {
                    b.HasOne("CarShowroom.Dal.Entities.Brand", "Brand")
                        .WithMany("Automobiles")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarShowroom.Dal.Entities.Equipment", "Equipment")
                        .WithMany("Automobiles")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarShowroom.Dal.Entities.Model", "Model")
                        .WithMany("Automobiles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Equipment");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Brand", b =>
                {
                    b.HasOne("CarShowroom.Dal.Entities.Company", "Company")
                        .WithMany("Brands")
                        .HasForeignKey("CompanyName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Engine", b =>
                {
                    b.HasOne("CarShowroom.Dal.Entities.Company", "Company")
                        .WithMany("Engines")
                        .HasForeignKey("CompanyName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Equipment", b =>
                {
                    b.HasOne("CarShowroom.Dal.Entities.Engine", "Engine")
                        .WithMany("Equipments")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarShowroom.Dal.Entities.Model", "Model")
                        .WithMany("Equipments")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Engine");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Model", b =>
                {
                    b.HasOne("CarShowroom.Dal.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Brand", b =>
                {
                    b.Navigation("Automobiles");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Company", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("Engines");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Engine", b =>
                {
                    b.Navigation("Equipments");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Equipment", b =>
                {
                    b.Navigation("Automobiles");
                });

            modelBuilder.Entity("CarShowroom.Dal.Entities.Model", b =>
                {
                    b.Navigation("Automobiles");

                    b.Navigation("Equipments");
                });
#pragma warning restore 612, 618
        }
    }
}
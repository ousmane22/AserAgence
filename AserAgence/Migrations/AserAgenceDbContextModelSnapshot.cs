﻿// <auto-generated />
using System;
using AserAgence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AserAgence.Migrations
{
    [DbContext(typeof(AserAgenceDbContext))]
    partial class AserAgenceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AserAgence.Models.Commune", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CommuneName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Commune");
                });

            modelBuilder.Entity("AserAgence.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("AserAgence.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RegionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("AserAgence.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ElectrifiedHouseholdsSurveyed")
                        .HasColumnType("int");

                    b.Property<DateTime>("SurveyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillageID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VillageID");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("AserAgence.Models.Village", b =>
                {
                    b.Property<int>("VillageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VillageID"), 1L, 1);

                    b.Property<int>("CommuneID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("ElectrifiedHouseholds")
                        .HasColumnType("int");

                    b.Property<bool>("IsElelctrify")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("VillageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VillageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VillageID");

                    b.HasIndex("CommuneID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("RegionID");

                    b.ToTable("Village");
                });

            modelBuilder.Entity("AserAgence.Models.Survey", b =>
                {
                    b.HasOne("AserAgence.Models.Village", "Village")
                        .WithMany("Surveys")
                        .HasForeignKey("VillageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Village");
                });

            modelBuilder.Entity("AserAgence.Models.Village", b =>
                {
                    b.HasOne("AserAgence.Models.Commune", "Commune")
                        .WithMany("Villages")
                        .HasForeignKey("CommuneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AserAgence.Models.Department", "Department")
                        .WithMany("Villages")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AserAgence.Models.Region", "Region")
                        .WithMany("Villages")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commune");

                    b.Navigation("Department");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("AserAgence.Models.Commune", b =>
                {
                    b.Navigation("Villages");
                });

            modelBuilder.Entity("AserAgence.Models.Department", b =>
                {
                    b.Navigation("Villages");
                });

            modelBuilder.Entity("AserAgence.Models.Region", b =>
                {
                    b.Navigation("Villages");
                });

            modelBuilder.Entity("AserAgence.Models.Village", b =>
                {
                    b.Navigation("Surveys");
                });
#pragma warning restore 612, 618
        }
    }
}

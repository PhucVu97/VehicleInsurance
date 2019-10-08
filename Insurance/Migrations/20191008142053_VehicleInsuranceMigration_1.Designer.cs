﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleInsurance.Data;

namespace VehicleInsurance.Migrations
{
    [DbContext(typeof(InsuranceDbContext))]
    [Migration("20191008142053_VehicleInsuranceMigration_1")]
    partial class VehicleInsuranceMigration_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleInsurance.Models.Account", b =>
                {
                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<byte[]>("Salt");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Bill", b =>
                {
                    b.Property<int>("BillNo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int?>("ClaimPolicyNumber");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<int?>("VehicleId");

                    b.HasKey("BillNo");

                    b.HasIndex("ClaimPolicyNumber");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Claim", b =>
                {
                    b.Property<int>("PolicyNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ClaimableAmount");

                    b.Property<int?>("CustomerId");

                    b.Property<double>("InsuranceAmount");

                    b.Property<string>("PlaceOfAccident");

                    b.Property<DateTime>("PolicyEndDate");

                    b.Property<DateTime>("PolicyStartDate");

                    b.Property<int>("Status");

                    b.HasKey("PolicyNumber");

                    b.HasIndex("CustomerId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<string>("CustomerPhone")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Estimate", b =>
                {
                    b.Property<int>("EstimateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<long>("EstimateNumber");

                    b.Property<int>("PolicyType");

                    b.Property<int?>("VehicleId");

                    b.HasKey("EstimateId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Estimates");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Insurance", b =>
                {
                    b.Property<int>("InsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("PolicyDate");

                    b.Property<DateTime>("PolicyDuration");

                    b.Property<string>("PolicyNumber");

                    b.Property<int>("Status");

                    b.Property<int?>("VehicleId");

                    b.HasKey("InsuranceId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VehicleBodyNumber");

                    b.Property<string>("VehicleEngineNumber");

                    b.Property<string>("VehicleModel");

                    b.Property<int>("VehicleName");

                    b.Property<string>("VehicleNumber");

                    b.Property<string>("VehicleRate");

                    b.Property<float>("VehicleVersion");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Account", b =>
                {
                    b.HasOne("VehicleInsurance.Models.Customer", "Customer")
                        .WithOne("Account")
                        .HasForeignKey("VehicleInsurance.Models.Account", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VehicleInsurance.Models.Bill", b =>
                {
                    b.HasOne("VehicleInsurance.Models.Claim", "Claim")
                        .WithMany("Bills")
                        .HasForeignKey("ClaimPolicyNumber");

                    b.HasOne("VehicleInsurance.Models.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId");

                    b.HasOne("VehicleInsurance.Models.Vehicle", "Vehicle")
                        .WithMany("Bills")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Claim", b =>
                {
                    b.HasOne("VehicleInsurance.Models.Customer", "Customer")
                        .WithMany("Claims")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Estimate", b =>
                {
                    b.HasOne("VehicleInsurance.Models.Customer", "Customer")
                        .WithMany("Estimates")
                        .HasForeignKey("CustomerId");

                    b.HasOne("VehicleInsurance.Models.Vehicle", "Vehicle")
                        .WithMany("Estimates")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("VehicleInsurance.Models.Insurance", b =>
                {
                    b.HasOne("VehicleInsurance.Models.Customer", "Customer")
                        .WithMany("Insurances")
                        .HasForeignKey("CustomerId");

                    b.HasOne("VehicleInsurance.Models.Vehicle", "Vehicle")
                        .WithMany("Insurances")
                        .HasForeignKey("VehicleId");
                });
#pragma warning restore 612, 618
        }
    }
}
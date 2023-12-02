﻿// <auto-generated />
using System;
using BTMS.BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTMS.BlazorApp.Server.Migrations
{
    [DbContext(typeof(BusDbContext))]
    [Migration("20231129084809_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BTMS.BlazorApp.Shared.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"));

                    b.Property<int>("BusType")
                        .HasColumnType("int");

                    b.Property<int?>("Capacity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BTMS.BlazorApp.Shared.Models.BusRoute", b =>
                {
                    b.Property<int>("BusRouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusRouteId"));

                    b.Property<int?>("ApproximateDistance")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ApproximateJourneyHour")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("BusRouteId");

                    b.ToTable("BusRoutes");
                });

            modelBuilder.Entity("BTMS.BlazorApp.Shared.Models.BusSchedule", b =>
                {
                    b.Property<int>("BusScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusScheduleId"));

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int>("BusRouteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("Time")
                        .IsRequired()
                        .HasColumnType("time");

                    b.HasKey("BusScheduleId");

                    b.HasIndex("BusId");

                    b.HasIndex("BusRouteId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("BTMS.BlazorApp.Shared.Models.Fare", b =>
                {
                    b.Property<int>("FareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FareId"));

                    b.Property<int>("BusRouteId")
                        .HasColumnType("int");

                    b.Property<int>("BusType")
                        .HasColumnType("int");

                    b.Property<int>("FareType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("SeatFare")
                        .HasColumnType("money");

                    b.HasKey("FareId");

                    b.HasIndex("BusRouteId");

                    b.ToTable("Fares");
                });

            modelBuilder.Entity("BTMS.BlazorApp.Shared.Models.BusSchedule", b =>
                {
                    b.HasOne("BTMS.BlazorApp.Shared.Models.BusRoute", "BusRoute")
                        .WithMany("Schedules")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTMS.BlazorApp.Shared.Models.Bus", "Bus")
                        .WithMany("Schedules")
                        .HasForeignKey("BusRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("BusRoute");
                });

            modelBuilder.Entity("BTMS.BlazorApp.Shared.Models.Fare", b =>
                {
                    b.HasOne("BTMS.BlazorApp.Shared.Models.BusRoute", "BusRoute")
                        .WithMany("Fares")
                        .HasForeignKey("BusRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusRoute");
                });

            modelBuilder.Entity("BTMS.BlazorApp.Shared.Models.Bus", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("BTMS.BlazorApp.Shared.Models.BusRoute", b =>
                {
                    b.Navigation("Fares");

                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}

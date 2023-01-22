﻿// <auto-generated />
using System;
using FlightSimulator.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightSimulator.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230117161426_StartProject")]
    partial class StartProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightSimulator.Data.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<int?>("FlightQueuesId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsLanding")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PassangerCount")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FlightQueuesId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightSimulator.Data.Models.FlightQueues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("FlightsQueues");
                });

            modelBuilder.Entity("FlightSimulator.Data.Models.Logger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<DateTime>("In")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Out")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TerminalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("TerminalId");

                    b.ToTable("Loggers");
                });

            modelBuilder.Entity("FlightSimulator.Data.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("WaitTime")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("FlightSimulator.Data.Models.Flight", b =>
                {
                    b.HasOne("FlightSimulator.Data.Models.FlightQueues", null)
                        .WithMany("Flights")
                        .HasForeignKey("FlightQueuesId");
                });

            modelBuilder.Entity("FlightSimulator.Data.Models.Logger", b =>
                {
                    b.HasOne("FlightSimulator.Data.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightSimulator.Data.Models.Terminal", "Terminal")
                        .WithMany()
                        .HasForeignKey("TerminalId");

                    b.Navigation("Flight");

                    b.Navigation("Terminal");
                });

            modelBuilder.Entity("FlightSimulator.Data.Models.Terminal", b =>
                {
                    b.HasOne("FlightSimulator.Data.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlightSimulator.Data.Models.FlightQueues", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}

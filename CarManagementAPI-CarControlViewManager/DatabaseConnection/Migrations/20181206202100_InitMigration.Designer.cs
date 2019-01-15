﻿// <auto-generated />
using System;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseConnection.Migrations
{
    [DbContext(typeof(CarManagementContext))]
    [Migration("20181206202100_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseConnection.Entities.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("ActualBatteryLevel");

                    b.Property<float>("ActualBrakeFluidLevel");

                    b.Property<float>("ActualCoolantLevel");

                    b.Property<float>("ActualFrontLeftTyrePressure");

                    b.Property<float>("ActualFrontRightTyrePressure");

                    b.Property<float>("ActualMotorOilLevel");

                    b.Property<float>("ActualRearLeftTyrePressure");

                    b.Property<float>("ActualRearRightTyrePressure");

                    b.Property<float>("ActualWindscreenWasherLevel");

                    b.Property<bool>("AreDoorsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<bool>("AreFrontParkingLightsOn");

                    b.Property<float>("BlockedLocationX");

                    b.Property<float>("BlockedLocationY");

                    b.Property<float>("ClimaTemperature");

                    b.Property<int>("HotChairLevel");

                    b.Property<float>("InsideTemperature");

                    b.Property<bool>("IsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<bool>("IsClimaOn");

                    b.Property<bool>("IsFuelFillerOpen");

                    b.Property<bool>("IsHighBeamOn");

                    b.Property<bool>("IsHoodOpen");

                    b.Property<bool>("IsLowBeamOn");

                    b.Property<bool>("IsRoofOpen");

                    b.Property<bool>("IsTrunkOpen");

                    b.Property<float>("LocationX");

                    b.Property<float>("LocationY");

                    b.Property<float>("MaxBatteryLevel");

                    b.Property<float>("MaxBrakeFluidLevel");

                    b.Property<float>("MaxCoolantLevel");

                    b.Property<float>("MaxMotorOilLevel");

                    b.Property<float>("MaxTyrePressure");

                    b.Property<float>("MaxWindscreenWasherLevel");

                    b.Property<float>("MinBatteryLevel");

                    b.Property<float>("MinBrakeFluidLevel");

                    b.Property<float>("MinCoolantLevel");

                    b.Property<float>("MinMotorOilLevel");

                    b.Property<float>("MinWindscreenWasherLevel");

                    b.Property<float>("OutsideTemperature");

                    b.Property<DateTime>("PreviousServiceDate");

                    b.Property<int>("UserId");

                    b.HasKey("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DatabaseConnection.Entities.ErrorLog", b =>
                {
                    b.Property<int>("ErrorLogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<string>("CarInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfEvent");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId");

                    b.HasKey("ErrorLogId");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("DatabaseConnection.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<bool>("IsFirstLogIn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .HasColumnType("varchar(25)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Nick")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatabaseConnection.Entities.Car", b =>
                {
                    b.HasOne("DatabaseConnection.Entities.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DatabaseConnection.Entities.ErrorLog", b =>
                {
                    b.HasOne("DatabaseConnection.Entities.Car", "Car")
                        .WithMany("ErrorLogs")
                        .HasForeignKey("CarId");

                    b.HasOne("DatabaseConnection.Entities.User", "User")
                        .WithMany("ErrorLogs")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
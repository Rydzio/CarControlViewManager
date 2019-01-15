using System;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    public class CarManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        private const string ConnString =
            "Server=tcp:snackifyserver.database.windows.net,1433;Initial Catalog=carmanagementt;Persist Security Info=False;User ID=Anakinud;Password=n2uwysepyWy;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public CarManagementContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Nick).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.IsFirstLogIn).HasDefaultValue(true);

                entity.HasData(
                    new User() { UserId = 1, Email = "test1@gmail.com", IsFirstLogIn = false, Name = "test1", Nick = "testNick1", Password = "Password", Surname = "TestSurname" },
                    new User() { UserId = 2, Email = "test2@gmail.com", IsFirstLogIn = false, Name = "test2", Nick = "testNick2", Password = "Password", Surname = "TestSurname1" },
                    new User() { UserId = 3, Email = "test3@gmail.com", IsFirstLogIn = false, Name = "test3", Nick = "testNick3", Password = "Password", Surname = "TestSurname2" }
                );
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Cars)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.IsBlocked).HasDefaultValue(true);
                entity.Property(e => e.AreDoorsBlocked).HasDefaultValue(true);

                entity.HasData(CarSeedData());
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(u => u.ErrorLogs)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(e => e.Car)
                    .WithMany(c => c.ErrorLogs)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }

        private Car[] CarSeedData()
        {
            return new Car[] {
                new Car()
                    {
                        CarId = 1,
                        UserId = 1,
                        ActualBatteryLevel = 100,
                        ActualBrakeFluidLevel = 75,
                        ActualCoolantLevel = 15,
                        ActualFrontLeftTyrePressure = 3,
                        ActualFrontRightTyrePressure = 2.8f,
                        ActualMotorOilLevel = 13,
                        ActualRearLeftTyrePressure = 1.3f,
                        ActualRearRightTyrePressure = 1.4f,
                        ActualWindscreenWasherLevel = 12,
                        AreDoorsBlocked = true,
                        AreFrontParkingLightsOn = false,
                        BlockedLocationX = 67.00012f,
                        BlockedLocationY = 23.0001267f,
                        ClimaTemperature = 0,
                        HotChairLevel = HotChairLevel.Off,
                        InsideTemperature = 24,
                        IsBlocked = true,
                        IsClimaOn = false,
                        IsFuelFillerOpen = false,
                        IsHighBeamOn = false,
                        IsHoodOpen = false,
                        IsLowBeamOn = false,
                        IsRoofOpen = false,
                        IsTrunkOpen = false,
                        LocationX = 67.00012f,
                        LocationY = 23.0001267f,
                        MaxBatteryLevel = 100,
                        MaxBrakeFluidLevel = 75,
                        MaxCoolantLevel = 15,
                        MaxMotorOilLevel = 13,
                        MaxTyrePressure = 3.5f,
                        MaxWindscreenWasherLevel = 12,
                        MinBatteryLevel = 25,
                        MinBrakeFluidLevel = 15,
                        MinCoolantLevel = 5,
                        MinMotorOilLevel = 3,
                        MinWindscreenWasherLevel = 5,
                        OutsideTemperature = 26,
                        PreviousServiceDate = new DateTime(2017, 12, 6),
                    },
                new Car()
                    {
                        CarId = 2,
                        UserId = 1,
                        ActualBatteryLevel = 12,
                        ActualBrakeFluidLevel = 43,
                        ActualCoolantLevel = 6,
                        ActualFrontLeftTyrePressure = 1.5f,
                        ActualFrontRightTyrePressure = 1.5f,
                        ActualMotorOilLevel = 8,
                        ActualRearLeftTyrePressure = 1.5f,
                        ActualRearRightTyrePressure = 1.5f,
                        ActualWindscreenWasherLevel = 12,
                        AreDoorsBlocked = false,
                        AreFrontParkingLightsOn = false,
                        BlockedLocationX = 67.00012f,
                        BlockedLocationY = 23.0001267f,
                        ClimaTemperature = 0,
                        HotChairLevel = HotChairLevel.Off,
                        InsideTemperature = 24,
                        IsBlocked = true,
                        IsClimaOn = false,
                        IsFuelFillerOpen = false,
                        IsHighBeamOn = false,
                        IsHoodOpen = false,
                        IsLowBeamOn = true,
                        IsRoofOpen = false,
                        IsTrunkOpen = false,
                        LocationX = 67.00012f,
                        LocationY = 23.0001267f,
                        MaxBatteryLevel = 100,
                        MaxBrakeFluidLevel = 75,
                        MaxCoolantLevel = 15,
                        MaxMotorOilLevel = 13,
                        MaxTyrePressure = 2.5f,
                        MaxWindscreenWasherLevel = 12,
                        MinBatteryLevel = 25,
                        MinBrakeFluidLevel = 15,
                        MinCoolantLevel = 5,
                        MinMotorOilLevel = 3,
                        MinWindscreenWasherLevel = 5,
                        OutsideTemperature = 26,
                        PreviousServiceDate = new DateTime(2017, 12, 6),
                    },
                new Car()
                    {
                        CarId = 3,
                        UserId = 2,
                        ActualBatteryLevel = 100,
                        ActualBrakeFluidLevel = 75,
                        ActualCoolantLevel = 15,
                        ActualFrontLeftTyrePressure = 3,
                        ActualFrontRightTyrePressure = 2.8f,
                        ActualMotorOilLevel = 13,
                        ActualRearLeftTyrePressure = 1.3f,
                        ActualRearRightTyrePressure = 1.4f,
                        ActualWindscreenWasherLevel = 12,
                        AreDoorsBlocked = true,
                        AreFrontParkingLightsOn = false,
                        BlockedLocationX = 67.00012f,
                        BlockedLocationY = 23.0001267f,
                        ClimaTemperature = 0,
                        HotChairLevel = HotChairLevel.Off,
                        InsideTemperature = 24,
                        IsBlocked = true,
                        IsClimaOn = false,
                        IsFuelFillerOpen = false,
                        IsHighBeamOn = false,
                        IsHoodOpen = false,
                        IsLowBeamOn = false,
                        IsRoofOpen = false,
                        IsTrunkOpen = false,
                        LocationX = 67.00012f,
                        LocationY = 23.0001267f,
                        MaxBatteryLevel = 100,
                        MaxBrakeFluidLevel = 75,
                        MaxCoolantLevel = 15,
                        MaxMotorOilLevel = 13,
                        MaxTyrePressure = 2.5f,
                        MaxWindscreenWasherLevel = 12,
                        MinBatteryLevel = 25,
                        MinBrakeFluidLevel = 15,
                        MinCoolantLevel = 5,
                        MinMotorOilLevel = 3,
                        MinWindscreenWasherLevel = 5,
                        OutsideTemperature = 26,
                        PreviousServiceDate = new DateTime(2017, 12, 6),
                    },
                new Car()
                    {
                        CarId = 4,
                        UserId = 3,
                        ActualBatteryLevel = 100,
                        ActualBrakeFluidLevel = 75,
                        ActualCoolantLevel = 15,
                        ActualFrontLeftTyrePressure = 3,
                        ActualFrontRightTyrePressure = 2.8f,
                        ActualMotorOilLevel = 13,
                        ActualRearLeftTyrePressure = 1.3f,
                        ActualRearRightTyrePressure = 1.4f,
                        ActualWindscreenWasherLevel = 12,
                        AreDoorsBlocked = true,
                        AreFrontParkingLightsOn = false,
                        BlockedLocationX = 67.00012f,
                        BlockedLocationY = 23.0001267f,
                        ClimaTemperature = 0,
                        HotChairLevel = HotChairLevel.Off,
                        InsideTemperature = 24,
                        IsBlocked = true,
                        IsClimaOn = false,
                        IsFuelFillerOpen = false,
                        IsHighBeamOn = false,
                        IsHoodOpen = false,
                        IsLowBeamOn = false,
                        IsRoofOpen = false,
                        IsTrunkOpen = false,
                        LocationX = 67.00012f,
                        LocationY = 23.0001267f,
                        MaxBatteryLevel = 100,
                        MaxBrakeFluidLevel = 75,
                        MaxCoolantLevel = 15,
                        MaxMotorOilLevel = 13,
                        MaxTyrePressure = 2.5f,
                        MaxWindscreenWasherLevel = 12,
                        MinBatteryLevel = 25,
                        MinBrakeFluidLevel = 15,
                        MinCoolantLevel = 5,
                        MinMotorOilLevel = 3,
                        MinWindscreenWasherLevel = 5,
                        OutsideTemperature = 26,
                        PreviousServiceDate = new DateTime(2017, 12, 6),
                    },
            };
        }
    }
}
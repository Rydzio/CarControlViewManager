using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseConnection.Migrations
{
    public partial class DataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsFirstLogIn", "Name", "Nick", "Password", "Surname" },
                values: new object[] { 1, "test1@gmail.com", false, "test1", "testNick1", "Password", "TestSurname" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsFirstLogIn", "Name", "Nick", "Password", "Surname" },
                values: new object[] { 2, "test2@gmail.com", false, "test2", "testNick2", "Password", "TestSurname1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsFirstLogIn", "Name", "Nick", "Password", "Surname" },
                values: new object[] { 3, "test3@gmail.com", false, "test3", "testNick3", "Password", "TestSurname2" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "ActualBatteryLevel", "ActualBrakeFluidLevel", "ActualCoolantLevel", "ActualFrontLeftTyrePressure", "ActualFrontRightTyrePressure", "ActualMotorOilLevel", "ActualRearLeftTyrePressure", "ActualRearRightTyrePressure", "ActualWindscreenWasherLevel", "AreDoorsBlocked", "AreFrontParkingLightsOn", "BlockedLocationX", "BlockedLocationY", "ClimaTemperature", "HotChairLevel", "InsideTemperature", "IsBlocked", "IsClimaOn", "IsFuelFillerOpen", "IsHighBeamOn", "IsHoodOpen", "IsLowBeamOn", "IsRoofOpen", "IsTrunkOpen", "LocationX", "LocationY", "MaxBatteryLevel", "MaxBrakeFluidLevel", "MaxCoolantLevel", "MaxMotorOilLevel", "MaxTyrePressure", "MaxWindscreenWasherLevel", "MinBatteryLevel", "MinBrakeFluidLevel", "MinCoolantLevel", "MinMotorOilLevel", "MinWindscreenWasherLevel", "OutsideTemperature", "PreviousServiceDate", "UserId" },
                values: new object[,]
                {
                    { 1, 100f, 75f, 15f, 3f, 2.8f, 13f, 1.3f, 1.4f, 12f, true, false, 67.00012f, 23.00013f, 0f, 0, 24f, true, false, false, false, false, false, false, false, 67.00012f, 23.00013f, 100f, 75f, 15f, 13f, 2.5f, 12f, 25f, 15f, 5f, 3f, 5f, 26f, new DateTime(2017, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 12f, 43f, 6f, 1.5f, 1.5f, 8f, 1.5f, 1.5f, 12f, false, false, 67.00012f, 23.00013f, 0f, 0, 24f, true, false, false, false, false, true, false, false, 67.00012f, 23.00013f, 100f, 75f, 15f, 13f, 2.5f, 12f, 25f, 15f, 5f, 3f, 5f, 26f, new DateTime(2017, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 100f, 75f, 15f, 3f, 2.8f, 13f, 1.3f, 1.4f, 12f, true, false, 67.00012f, 23.00013f, 0f, 0, 24f, true, false, false, false, false, false, false, false, 67.00012f, 23.00013f, 100f, 75f, 15f, 13f, 2.5f, 12f, 25f, 15f, 5f, 3f, 5f, 26f, new DateTime(2017, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 100f, 75f, 15f, 3f, 2.8f, 13f, 1.3f, 1.4f, 12f, true, false, 67.00012f, 23.00013f, 0f, 0, 24f, true, false, false, false, false, false, false, false, 67.00012f, 23.00013f, 100f, 75f, 15f, 13f, 2.5f, 12f, 25f, 15f, 5f, 3f, 5f, 26f, new DateTime(2017, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}

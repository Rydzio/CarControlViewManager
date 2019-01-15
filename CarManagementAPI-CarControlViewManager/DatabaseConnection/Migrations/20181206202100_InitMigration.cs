using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseConnection.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nick = table.Column<string>(type: "varchar(25)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(25)", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", nullable: true),
                    Surname = table.Column<string>(type: "varchar(25)", nullable: true),
                    IsFirstLogIn = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsBlocked = table.Column<bool>(nullable: false, defaultValue: true),
                    AreDoorsBlocked = table.Column<bool>(nullable: false, defaultValue: true),
                    IsClimaOn = table.Column<bool>(nullable: false),
                    IsTrunkOpen = table.Column<bool>(nullable: false),
                    IsHoodOpen = table.Column<bool>(nullable: false),
                    IsRoofOpen = table.Column<bool>(nullable: false),
                    IsFuelFillerOpen = table.Column<bool>(nullable: false),
                    IsLowBeamOn = table.Column<bool>(nullable: false),
                    IsHighBeamOn = table.Column<bool>(nullable: false),
                    AreFrontParkingLightsOn = table.Column<bool>(nullable: false),
                    MinCoolantLevel = table.Column<float>(nullable: false),
                    ActualCoolantLevel = table.Column<float>(nullable: false),
                    MaxCoolantLevel = table.Column<float>(nullable: false),
                    MinBrakeFluidLevel = table.Column<float>(nullable: false),
                    ActualBrakeFluidLevel = table.Column<float>(nullable: false),
                    MaxBrakeFluidLevel = table.Column<float>(nullable: false),
                    MinMotorOilLevel = table.Column<float>(nullable: false),
                    ActualMotorOilLevel = table.Column<float>(nullable: false),
                    MaxMotorOilLevel = table.Column<float>(nullable: false),
                    MinWindscreenWasherLevel = table.Column<float>(nullable: false),
                    ActualWindscreenWasherLevel = table.Column<float>(nullable: false),
                    MaxWindscreenWasherLevel = table.Column<float>(nullable: false),
                    MinBatteryLevel = table.Column<float>(nullable: false),
                    ActualBatteryLevel = table.Column<float>(nullable: false),
                    MaxBatteryLevel = table.Column<float>(nullable: false),
                    MaxTyrePressure = table.Column<float>(nullable: false),
                    ActualFrontRightTyrePressure = table.Column<float>(nullable: false),
                    ActualFrontLeftTyrePressure = table.Column<float>(nullable: false),
                    ActualRearRightTyrePressure = table.Column<float>(nullable: false),
                    ActualRearLeftTyrePressure = table.Column<float>(nullable: false),
                    InsideTemperature = table.Column<float>(nullable: false),
                    OutsideTemperature = table.Column<float>(nullable: false),
                    ClimaTemperature = table.Column<float>(nullable: false),
                    PreviousServiceDate = table.Column<DateTime>(nullable: false),
                    HotChairLevel = table.Column<int>(nullable: false),
                    LocationX = table.Column<float>(nullable: false),
                    LocationY = table.Column<float>(nullable: false),
                    BlockedLocationY = table.Column<float>(nullable: false),
                    BlockedLocationX = table.Column<float>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    ErrorLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfEvent = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(type: "varchar(50)", nullable: false),
                    CarInfo = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.ErrorLogId);
                    table.ForeignKey(
                        name: "FK_ErrorLogs_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErrorLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorLogs_CarId",
                table: "ErrorLogs",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorLogs_UserId",
                table: "ErrorLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Nick",
                table: "Users",
                column: "Nick",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

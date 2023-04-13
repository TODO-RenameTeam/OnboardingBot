using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingBot.Server.Migrations
{
    /// <inheritdoc />
    public partial class OnboardingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeEnd",
                table: "UserOnboardings",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeStart",
                table: "UserOnboardings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Quizes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RoleOnboardingStepEntity",
                columns: table => new
                {
                    RoleOnboardingID = table.Column<Guid>(type: "uuid", nullable: false),
                    StepID = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOnboardingStepEntity", x => new { x.RoleOnboardingID, x.StepID, x.Position });
                    table.ForeignKey(
                        name: "FK_RoleOnboardingStepEntity_RoleOnboardings_RoleOnboardingID",
                        column: x => x.RoleOnboardingID,
                        principalTable: "RoleOnboardings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleOnboardingStepEntity_Steps_StepID",
                        column: x => x.StepID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleOnboardingStepEntity_StepID",
                table: "RoleOnboardingStepEntity",
                column: "StepID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleOnboardingStepEntity");

            migrationBuilder.DropColumn(
                name: "DateTimeEnd",
                table: "UserOnboardings");

            migrationBuilder.DropColumn(
                name: "DateTimeStart",
                table: "UserOnboardings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Quizes");
        }
    }
}

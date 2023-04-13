using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingBot.Server.Migrations
{
    /// <inheritdoc />
    public partial class NotificationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_MainUserID",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_MainUserID",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "MainUserID",
                table: "Positions");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Minutes = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: true),
                    Sending = table.Column<int>(type: "integer", nullable: true),
                    DateTimeStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PositionID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notifications_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PositionID",
                table: "Notifications",
                column: "PositionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "MainUserID",
                table: "Positions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_MainUserID",
                table: "Positions",
                column: "MainUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_MainUserID",
                table: "Positions",
                column: "MainUserID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}

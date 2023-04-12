using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingBot.Server.Migrations
{
    /// <inheritdoc />
    public partial class TextCommandButtonFixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buttons_TextCommands_TextCommandEntityID",
                table: "Buttons");

            migrationBuilder.DropIndex(
                name: "IX_Buttons_TextCommandEntityID",
                table: "Buttons");

            migrationBuilder.DropColumn(
                name: "TextCommandEntityID",
                table: "Buttons");

            migrationBuilder.CreateTable(
                name: "ButtonEntityTextCommandEntity",
                columns: table => new
                {
                    ButtonsID = table.Column<Guid>(type: "uuid", nullable: false),
                    TextCommandsID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonEntityTextCommandEntity", x => new { x.ButtonsID, x.TextCommandsID });
                    table.ForeignKey(
                        name: "FK_ButtonEntityTextCommandEntity_Buttons_ButtonsID",
                        column: x => x.ButtonsID,
                        principalTable: "Buttons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ButtonEntityTextCommandEntity_TextCommands_TextCommandsID",
                        column: x => x.TextCommandsID,
                        principalTable: "TextCommands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ButtonEntityTextCommandEntity_TextCommandsID",
                table: "ButtonEntityTextCommandEntity",
                column: "TextCommandsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ButtonEntityTextCommandEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "TextCommandEntityID",
                table: "Buttons",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buttons_TextCommandEntityID",
                table: "Buttons",
                column: "TextCommandEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Buttons_TextCommands_TextCommandEntityID",
                table: "Buttons",
                column: "TextCommandEntityID",
                principalTable: "TextCommands",
                principalColumn: "ID");
        }
    }
}

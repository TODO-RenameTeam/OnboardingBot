using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingBot.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserPositionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_MainUserID",
                table: "Positions");

            migrationBuilder.AddColumn<Guid>(
                name: "PositionID",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MainUserID",
                table: "Positions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "UserQuestions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    DateTimeQuestion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateTimeAnswering = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserQuestionID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserQuestions_Users_UserQuestionID",
                        column: x => x.UserQuestionID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionID",
                table: "Users",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_UserQuestionID",
                table: "UserQuestions",
                column: "UserQuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_MainUserID",
                table: "Positions",
                column: "MainUserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_PositionID",
                table: "Users",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_MainUserID",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_PositionID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Users_PositionID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PositionID",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "MainUserID",
                table: "Positions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_MainUserID",
                table: "Positions",
                column: "MainUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

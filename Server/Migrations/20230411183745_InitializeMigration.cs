using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingBot.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitializeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Options = table.Column<List<string>>(type: "text[]", nullable: false),
                    RightOptionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    TelegramID = table.Column<long>(type: "bigint", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MainUserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Positions_Users_MainUserID",
                        column: x => x.MainUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelegramCodes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTimeCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateTimeExist = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramCodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TelegramCodes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleOnboardings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionID = table.Column<Guid>(type: "uuid", nullable: false),
                    StepsCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOnboardings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleOnboardings_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Images = table.Column<string>(type: "text", nullable: true),
                    Urls = table.Column<string>(type: "text", nullable: true),
                    QuizesCount = table.Column<int>(type: "integer", nullable: false),
                    PositionID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Steps_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PositionID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tests_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TextCommands",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Template = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Images = table.Column<string>(type: "text", nullable: true),
                    Urls = table.Column<string>(type: "text", nullable: true),
                    QuizesCount = table.Column<int>(type: "integer", nullable: false),
                    PositionID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextCommands", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TextCommands_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "QuizEntityStepEntity",
                columns: table => new
                {
                    QuizesID = table.Column<Guid>(type: "uuid", nullable: false),
                    StepsID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizEntityStepEntity", x => new { x.QuizesID, x.StepsID });
                    table.ForeignKey(
                        name: "FK_QuizEntityStepEntity_Quizes_QuizesID",
                        column: x => x.QuizesID,
                        principalTable: "Quizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizEntityStepEntity_Steps_StepsID",
                        column: x => x.StepsID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOnboardings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleOnboardingID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserCurrentStepID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOnboardings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserOnboardings_RoleOnboardings_RoleOnboardingID",
                        column: x => x.RoleOnboardingID,
                        principalTable: "RoleOnboardings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOnboardings_Steps_UserCurrentStepID",
                        column: x => x.UserCurrentStepID,
                        principalTable: "Steps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOnboardings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AnswerDisplayingType = table.Column<int>(type: "integer", nullable: false),
                    TestEntityID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestEntityID",
                        column: x => x.TestEntityID,
                        principalTable: "Tests",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserTestAnswers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    TestID = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTimeStarting = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateTimeEnding = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestAnswers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserTestAnswers_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTestAnswers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buttons",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    TestEntityID = table.Column<Guid>(type: "uuid", nullable: true),
                    TextCommandEntityID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buttons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Buttons_Tests_TestEntityID",
                        column: x => x.TestEntityID,
                        principalTable: "Tests",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Buttons_TextCommands_TextCommandEntityID",
                        column: x => x.TextCommandEntityID,
                        principalTable: "TextCommands",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "QuizEntityTextCommandEntity",
                columns: table => new
                {
                    QuizesID = table.Column<Guid>(type: "uuid", nullable: false),
                    TextCommandsID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizEntityTextCommandEntity", x => new { x.QuizesID, x.TextCommandsID });
                    table.ForeignKey(
                        name: "FK_QuizEntityTextCommandEntity_Quizes_QuizesID",
                        column: x => x.QuizesID,
                        principalTable: "Quizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizEntityTextCommandEntity_TextCommands_TextCommandsID",
                        column: x => x.TextCommandsID,
                        principalTable: "TextCommands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerEntity",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: true),
                    Mark = table.Column<int>(type: "integer", nullable: true),
                    QuestionEntityID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnswerEntity_Questions_QuestionEntityID",
                        column: x => x.QuestionEntityID,
                        principalTable: "Questions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserAnswerEntity",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionID = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserTestAnswerEntityID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswerEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAnswerEntity_AnswerEntity_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "AnswerEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswerEntity_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswerEntity_UserTestAnswers_UserTestAnswerEntityID",
                        column: x => x.UserTestAnswerEntityID,
                        principalTable: "UserTestAnswers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserAnswerEntity_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerEntity_QuestionEntityID",
                table: "AnswerEntity",
                column: "QuestionEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Buttons_TestEntityID",
                table: "Buttons",
                column: "TestEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Buttons_TextCommandEntityID",
                table: "Buttons",
                column: "TextCommandEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_MainUserID",
                table: "Positions",
                column: "MainUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestEntityID",
                table: "Questions",
                column: "TestEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_QuizEntityStepEntity_StepsID",
                table: "QuizEntityStepEntity",
                column: "StepsID");

            migrationBuilder.CreateIndex(
                name: "IX_QuizEntityTextCommandEntity_TextCommandsID",
                table: "QuizEntityTextCommandEntity",
                column: "TextCommandsID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOnboardings_PositionID",
                table: "RoleOnboardings",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_PositionID",
                table: "Steps",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramCodes_UserID",
                table: "TelegramCodes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_PositionID",
                table: "Tests",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_TextCommands_PositionID",
                table: "TextCommands",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswerEntity_QuestionID",
                table: "UserAnswerEntity",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswerEntity_UserID",
                table: "UserAnswerEntity",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswerEntity_UserTestAnswerEntityID",
                table: "UserAnswerEntity",
                column: "UserTestAnswerEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOnboardings_RoleOnboardingID",
                table: "UserOnboardings",
                column: "RoleOnboardingID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOnboardings_UserCurrentStepID",
                table: "UserOnboardings",
                column: "UserCurrentStepID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOnboardings_UserID",
                table: "UserOnboardings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestAnswers_TestID",
                table: "UserTestAnswers",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestAnswers_UserID",
                table: "UserTestAnswers",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buttons");

            migrationBuilder.DropTable(
                name: "QuizEntityStepEntity");

            migrationBuilder.DropTable(
                name: "QuizEntityTextCommandEntity");

            migrationBuilder.DropTable(
                name: "TelegramCodes");

            migrationBuilder.DropTable(
                name: "UserAnswerEntity");

            migrationBuilder.DropTable(
                name: "UserOnboardings");

            migrationBuilder.DropTable(
                name: "Quizes");

            migrationBuilder.DropTable(
                name: "TextCommands");

            migrationBuilder.DropTable(
                name: "AnswerEntity");

            migrationBuilder.DropTable(
                name: "UserTestAnswers");

            migrationBuilder.DropTable(
                name: "RoleOnboardings");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

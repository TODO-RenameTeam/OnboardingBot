﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingBot.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserOnboardingTwoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOnboardings",
                table: "UserOnboardings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOnboardings",
                table: "UserOnboardings",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOnboardings",
                table: "UserOnboardings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOnboardings",
                table: "UserOnboardings",
                columns: new[] { "ID", "RoleOnboardingID", "UserCurrentStepID" });
        }
    }
}

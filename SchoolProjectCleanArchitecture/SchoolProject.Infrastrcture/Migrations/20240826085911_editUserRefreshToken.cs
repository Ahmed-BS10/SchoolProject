using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastrcture.Migrations
{
    /// <inheritdoc />
    public partial class editUserRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "JwtId",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRefreshTokens");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "UserRefreshTokens",
                newName: "ExpiresOn");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UserRefreshTokens",
                newName: "CreateOn");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UserRefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RevokedOn",
                table: "UserRefreshTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_ApplicationUserId",
                table: "UserRefreshTokens",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_ApplicationUserId",
                table: "UserRefreshTokens",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_ApplicationUserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRefreshTokens_ApplicationUserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "RevokedOn",
                table: "UserRefreshTokens");

            migrationBuilder.RenameColumn(
                name: "ExpiresOn",
                table: "UserRefreshTokens",
                newName: "ExpiryDate");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "UserRefreshTokens",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UserRefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "UserRefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "UserRefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JwtId",
                table: "UserRefreshTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "UserRefreshTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                table: "UserRefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

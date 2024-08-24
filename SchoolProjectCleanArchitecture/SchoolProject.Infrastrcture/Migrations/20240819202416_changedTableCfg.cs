using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastrcture.Migrations
{
    /// <inheritdoc />
    public partial class changedTableCfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsManager",
                table: "departments");

            migrationBuilder.AlterColumn<int>(
                name: "InsManager",
                table: "departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManager",
                table: "departments",
                column: "InsManager",
                unique: true,
                filter: "[InsManager] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments",
                column: "InsManager",
                principalTable: "Instructor",
                principalColumn: "InstId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsManager",
                table: "departments");

            migrationBuilder.AlterColumn<int>(
                name: "InsManager",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManager",
                table: "departments",
                column: "InsManager",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments",
                column: "InsManager",
                principalTable: "Instructor",
                principalColumn: "InstId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

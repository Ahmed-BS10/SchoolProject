using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastrcture.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Instructor_SupervisorId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectInsturctor_Instructor_InsId",
                table: "SubjectInsturctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructors",
                newName: "IX_Instructors_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_DID",
                table: "Instructors",
                newName: "IX_Instructors_DID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "InstId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructors_InsManager",
                table: "departments",
                column: "InsManager",
                principalTable: "Instructors",
                principalColumn: "InstId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Instructors_SupervisorId",
                table: "Instructors",
                column: "SupervisorId",
                principalTable: "Instructors",
                principalColumn: "InstId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_departments_DID",
                table: "Instructors",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectInsturctor_Instructors_InsId",
                table: "SubjectInsturctor",
                column: "InsId",
                principalTable: "Instructors",
                principalColumn: "InstId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructors_InsManager",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Instructors_SupervisorId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_departments_DID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectInsturctor_Instructors_InsId",
                table: "SubjectInsturctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_SupervisorId",
                table: "Instructor",
                newName: "IX_Instructor_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_DID",
                table: "Instructor",
                newName: "IX_Instructor_DID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "InstId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments",
                column: "InsManager",
                principalTable: "Instructor",
                principalColumn: "InstId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId",
                principalTable: "Instructor",
                principalColumn: "InstId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectInsturctor_Instructor_InsId",
                table: "SubjectInsturctor",
                column: "InsId",
                principalTable: "Instructor",
                principalColumn: "InstId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

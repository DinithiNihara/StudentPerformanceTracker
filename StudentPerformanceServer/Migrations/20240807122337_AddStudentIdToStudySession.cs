using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentPerformanceServer.Migrations
{
    public partial class AddStudentIdToStudySession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudySessions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudySessions");
        }
    }
}

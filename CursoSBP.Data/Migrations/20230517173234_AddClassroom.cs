using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoSBP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Classroom",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classroom",
                table: "Schedules");
        }
    }
}

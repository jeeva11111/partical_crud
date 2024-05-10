using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace partical_crud.Migrations
{
    /// <inheritdoc />
    public partial class addedImageToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "PlanningCourse",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "PlanningCourse",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "PlanningCourse");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "PlanningCourse");
        }
    }
}

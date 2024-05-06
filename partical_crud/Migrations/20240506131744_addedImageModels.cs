using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace partical_crud.Migrations
{
    /// <inheritdoc />
    public partial class addedImageModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserFileName",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFileName",
                table: "UserInfo");
        }
    }
}

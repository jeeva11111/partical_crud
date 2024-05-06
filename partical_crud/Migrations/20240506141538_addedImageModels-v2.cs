using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace partical_crud.Migrations
{
    /// <inheritdoc />
    public partial class addedImageModelsv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserInfo");

            migrationBuilder.RenameColumn(
                name: "Orgnaction",
                table: "UserInfo",
                newName: "Qualification");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SpeakingDate",
                table: "UserInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SpeakingTime",
                table: "UserInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    SpeakingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeakingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountInfo_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountInfo_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccountInfo_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_CityId",
                table: "UserInfo",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_CountryId",
                table: "UserInfo",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_StateId",
                table: "UserInfo",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfo_CityId",
                table: "AccountInfo",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfo_CountryId",
                table: "AccountInfo",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfo_StateId",
                table: "AccountInfo",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_City_CityId",
                table: "UserInfo",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Country_CountryId",
                table: "UserInfo",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_states_StateId",
                table: "UserInfo",
                column: "StateId",
                principalTable: "states",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_City_CityId",
                table: "UserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Country_CountryId",
                table: "UserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_states_StateId",
                table: "UserInfo");

            migrationBuilder.DropTable(
                name: "AccountInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_CityId",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_CountryId",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_StateId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "SpeakingDate",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "SpeakingTime",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "UserInfo");

            migrationBuilder.RenameColumn(
                name: "Qualification",
                table: "UserInfo",
                newName: "Orgnaction");

            migrationBuilder.AddColumn<string>(
                name: "BirthDay",
                table: "UserInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealtorCAify.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Resource = table.Column<string>(type: "TEXT", nullable: true),
                    Request = table.Column<string>(type: "TEXT", nullable: true),
                    Response = table.Column<string>(type: "TEXT", nullable: true),
                    ResponseContent = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: true),
                    AddressText = table.Column<string>(type: "TEXT", nullable: true),
                    MlsNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ResultDtoId = table.Column<string>(type: "TEXT", nullable: true),
                    BathroomTotal = table.Column<string>(type: "TEXT", nullable: true),
                    Bedrooms = table.Column<string>(type: "TEXT", nullable: true),
                    SizeInterior = table.Column<string>(type: "TEXT", nullable: true),
                    StoriesTotal = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Ammenities = table.Column<string>(type: "TEXT", nullable: true),
                    SizeTotal = table.Column<string>(type: "TEXT", nullable: true),
                    SizeFrontage = table.Column<string>(type: "TEXT", nullable: true),
                    AccessType = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    RealtorName = table.Column<string>(type: "TEXT", nullable: true),
                    PropertyDescription = table.Column<string>(type: "TEXT", nullable: true),
                    DetailsUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ParkingType = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoChangeDateUTC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiTransactions");

            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}

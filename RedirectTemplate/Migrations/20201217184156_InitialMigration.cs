using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedirectTemplate.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 8, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Alpha_2Code = table.Column<string>(maxLength: 2, nullable: false),
                    Alpha_3Code = table.Column<string>(maxLength: 3, nullable: false),
                    NumericCode = table.Column<int>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Company = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(maxLength: 256, nullable: false),
                    ComercialName = table.Column<string>(maxLength: 128, nullable: false),
                    Brand = table.Column<string>(maxLength: 128, nullable: false),
                    SapIdClient = table.Column<string>(maxLength: 128, nullable: false),
                    SapClientAlpha_2Code = table.Column<string>(maxLength: 2, nullable: false),
                    DateTimeSync = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "B", "Bestbrake" },
                    { 13, "X", "Fremax" },
                    { 12, "V", "Randon Veículos" },
                    { 10, "S", "Stop" },
                    { 9, "R", "Randon" },
                    { 8, "M", "Midland Friction" },
                    { 11, "T", "StradaR" },
                    { 6, "J", "Fras-le" },
                    { 5, "F", "Fras-le" },
                    { 4, "E", "Ferodo" },
                    { 3, "D", "Durbloc" },
                    { 2, "B", "Controil" },
                    { 7, "L", "Lonaflex" }
                });

            migrationBuilder.InsertData(
                table: "Contries",
                columns: new[] { "Id", "Alpha_2Code", "Alpha_3Code", "Latitude", "Longitude", "Name", "NumericCode" },
                values: new object[,]
                {
                    { 1, "AF", "AFG", 33f, 65f, "Afghanistan", 4 },
                    { 2, "AL", "ALB", 41f, 20f, "Albania", 8 },
                    { 3, "BR", "BRA", -10f, -55f, "Brazil", 76 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "ComercialName", "Company", "DateTimeSync", "SapClientAlpha_2Code", "SapIdClient", "Serie" },
                values: new object[,]
                {
                    { 4, "X", "BD0001", 2010, new DateTime(2020, 12, 17, 15, 41, 55, 505, DateTimeKind.Local).AddTicks(3642), "BR", "1000031413", "ABCDE123456789ABC15" },
                    { 1, "F", "PD/60", 2010, new DateTime(2020, 12, 17, 15, 41, 55, 503, DateTimeKind.Local).AddTicks(6395), "BR", "1000003450", "ABCDE123456789ABC12" },
                    { 2, "F", "P-60", 2010, new DateTime(2020, 12, 17, 15, 41, 55, 505, DateTimeKind.Local).AddTicks(3572), "BR", "1000049110", "ABCDE123456789ABC13" },
                    { 3, "F", "CA/33", 2010, new DateTime(2020, 12, 17, 15, 41, 55, 505, DateTimeKind.Local).AddTicks(3638), "BR", "1000018473", "ABCDE123456789ABC14" },
                    { 5, "C", "C-2000", 2010, new DateTime(2020, 12, 17, 15, 41, 55, 505, DateTimeKind.Local).AddTicks(3646), "BR", "1000031413", "ABCDE123456789ABC16" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Contries");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

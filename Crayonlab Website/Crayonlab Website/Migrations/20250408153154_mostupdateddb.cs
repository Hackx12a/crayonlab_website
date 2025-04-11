using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class mostupdateddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketballJerseys");

            migrationBuilder.DropTable(
                name: "Designs");

            migrationBuilder.DropTable(
                name: "Longsleeves");

            migrationBuilder.DropTable(
                name: "Soccerjerseys");

            migrationBuilder.CreateTable(
                name: "ShirtTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShirtTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShirtDesigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShirtTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortsDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShirtDesigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShirtDesigns_ShirtTypes_ShirtTypeId",
                        column: x => x.ShirtTypeId,
                        principalTable: "ShirtTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ShirtTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Corporate shirts collection", "Corporate" },
                    { 2, "Basketball jerseys collection", "Basketball" },
                    { 3, "Soccer jerseys collection", "Soccer" },
                    { 4, "Long sleeve shirts collection", "LongSleeve" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShirtDesigns_ShirtTypeId",
                table: "ShirtDesigns",
                column: "ShirtTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShirtDesigns");

            migrationBuilder.DropTable(
                name: "ShirtTypes");

            migrationBuilder.CreateTable(
                name: "BasketballJerseys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortsDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WomenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketballJerseys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortsDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WomenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Longsleeves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortsDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WomenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Longsleeves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soccerjerseys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortsDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WomenLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenMPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXSPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WomenXXLPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soccerjerseys", x => x.Id);
                });
        }
    }
}

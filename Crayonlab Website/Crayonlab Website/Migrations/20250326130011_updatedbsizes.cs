using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class updatedbsizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Soccerjerseys",
                newName: "WomenXXLPrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Longsleeves",
                newName: "WomenXXLPrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Designs",
                newName: "WomenXXLPrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "BasketballJerseys",
                newName: "WomenXXLPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "MenLPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenMPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenSPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXLPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXSPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXXLPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenLPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenMPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenSPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenXLPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenXSPrice",
                table: "Soccerjerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenLPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenMPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenSPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXLPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXSPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXXLPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenLPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenMPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenSPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenXLPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenXSPrice",
                table: "Longsleeves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenLPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenMPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenSPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXLPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXSPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXXLPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenLPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenMPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenSPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenXLPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenXSPrice",
                table: "Designs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenLPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenMPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenSPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXLPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXSPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MenXXLPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenLPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenMPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenSPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenXLPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WomenXSPrice",
                table: "BasketballJerseys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenLPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "MenMPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "MenSPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "MenXLPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "MenXSPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "MenXXLPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "WomenLPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "WomenMPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "WomenSPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "WomenXLPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "WomenXSPrice",
                table: "Soccerjerseys");

            migrationBuilder.DropColumn(
                name: "MenLPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "MenMPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "MenSPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "MenXLPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "MenXSPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "MenXXLPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "WomenLPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "WomenMPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "WomenSPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "WomenXLPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "WomenXSPrice",
                table: "Longsleeves");

            migrationBuilder.DropColumn(
                name: "MenLPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "MenMPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "MenSPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "MenXLPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "MenXSPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "MenXXLPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "WomenLPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "WomenMPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "WomenSPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "WomenXLPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "WomenXSPrice",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "MenLPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "MenMPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "MenSPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "MenXLPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "MenXSPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "MenXXLPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "WomenLPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "WomenMPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "WomenSPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "WomenXLPrice",
                table: "BasketballJerseys");

            migrationBuilder.DropColumn(
                name: "WomenXSPrice",
                table: "BasketballJerseys");

            migrationBuilder.RenameColumn(
                name: "WomenXXLPrice",
                table: "Soccerjerseys",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "WomenXXLPrice",
                table: "Longsleeves",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "WomenXXLPrice",
                table: "Designs",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "WomenXXLPrice",
                table: "BasketballJerseys",
                newName: "Price");
        }
    }
}

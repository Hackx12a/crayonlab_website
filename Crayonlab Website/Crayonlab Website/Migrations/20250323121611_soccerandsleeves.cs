using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class soccerandsleeves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Longsleeves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrontDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortsDesign = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    FrontDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortsDesign = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soccerjerseys", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Longsleeves");

            migrationBuilder.DropTable(
                name: "Soccerjerseys");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PROGETTOMATTEO.Migrations
{
    public partial class UniversityDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Continent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAbitanti = table.Column<long>(type: "bigint", nullable: false),
                    NPositivi = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Continent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "_Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAbitanti = table.Column<long>(type: "bigint", nullable: false),
                    NPositivi = table.Column<long>(type: "bigint", nullable: false),
                    ContinentId = table.Column<int>(type: "int", nullable: false),
                    ColorCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Country__Continent_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "_Continent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAbitanti = table.Column<long>(type: "bigint", nullable: false),
                    NPositivi = table.Column<long>(type: "bigint", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__City", x => x.ID);
                    table.ForeignKey(
                        name: "FK__City__Country_countryId",
                        column: x => x.countryId,
                        principalTable: "_Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__City_countryId",
                table: "_City",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX__Country_ContinentId",
                table: "_Country",
                column: "ContinentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_City");

            migrationBuilder.DropTable(
                name: "_Country");

            migrationBuilder.DropTable(
                name: "_Continent");
        }
    }
}

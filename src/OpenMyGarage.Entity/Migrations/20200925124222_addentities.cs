using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace OpenMyGarage.Entity.Migrations
{
    public partial class addentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryLogs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Plate = table.Column<string>(nullable: false),
                    EntryTime = table.Column<long>(type: "bigint", nullable: false),
                    PictureURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryLogs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StoredPlates",
                columns: table => new
                {
                    Plate = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(type: "varchar(256)", nullable: true, defaultValue: "HU"),
                    CarManufacturer = table.Column<string>(nullable: false),
                    AutoOpen = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredPlates", x => x.Plate);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryLogs");

            migrationBuilder.DropTable(
                name: "StoredPlates");
        }
    }
}

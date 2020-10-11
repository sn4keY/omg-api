using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace OpenMyGarage.Entity.Migrations
{
    public partial class entitiesrefact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredPlates",
                table: "StoredPlates");

            migrationBuilder.DropColumn(
                name: "PictureURL",
                table: "EntryLogs");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "StoredPlates",
                type: "varchar(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "StoredPlates",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredPlates",
                table: "StoredPlates",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "10bf108b-4152-48b9-af09-633a57a7349c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "45ef2843-8623-4e08-95d4-8b809d68b0d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2e5154d5-1ed1-4aa1-8fcb-f0d047676c07");

            migrationBuilder.CreateIndex(
                name: "IX_StoredPlates_Plate",
                table: "StoredPlates",
                column: "Plate",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredPlates",
                table: "StoredPlates");

            migrationBuilder.DropIndex(
                name: "IX_StoredPlates_Plate",
                table: "StoredPlates");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "StoredPlates");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "StoredPlates",
                type: "varchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureURL",
                table: "EntryLogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredPlates",
                table: "StoredPlates",
                column: "Plate");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a1368eab-ba8b-44fd-84d4-79c5cefc0aec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "126d9420-721d-4d76-a227-42d5430b4190");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "bc8f0607-b08c-4ffa-8808-0377ff0e2af2");
        }
    }
}

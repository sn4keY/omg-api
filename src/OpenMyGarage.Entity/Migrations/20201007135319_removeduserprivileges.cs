using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace OpenMyGarage.Entity.Migrations
{
    public partial class removeduserprivileges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPrivilege");

            migrationBuilder.DropTable(
                name: "Privilege");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Privilege",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserPrivilege = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivilege",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(767)", nullable: false),
                    PrivilegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivilege", x => new { x.UserId, x.PrivilegeId });
                    table.ForeignKey(
                        name: "FK_UserPrivilege_Privilege_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privilege",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrivilege_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5dd2c887-6036-4a81-8f14-b1f6a0752a0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "469e4da9-c917-4ccd-bcd9-204255c64ce9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "56c42977-0b76-4a19-887a-92c8ef9677b2");

            migrationBuilder.InsertData(
                table: "Privilege",
                columns: new[] { "ID", "UserPrivilege" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivilege_PrivilegeId",
                table: "UserPrivilege",
                column: "PrivilegeId");
        }
    }
}

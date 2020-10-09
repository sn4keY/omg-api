using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace OpenMyGarage.Entity.Migrations
{
    public partial class userprivileges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Privilege",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserPrivilege = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivilege",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PrivilegeId = table.Column<int>(nullable: false)
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

            migrationBuilder.InsertData(
                table: "Privilege",
                columns: new[] { "ID", "UserPrivilege" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "Privilege",
                columns: new[] { "ID", "UserPrivilege" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivilege_PrivilegeId",
                table: "UserPrivilege",
                column: "PrivilegeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPrivilege");

            migrationBuilder.DropTable(
                name: "Privilege");
        }
    }
}

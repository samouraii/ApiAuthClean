using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiAuthTest.Migrations
{
    public partial class permission2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RolesId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_RolesId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Permissions");

            migrationBuilder.CreateTable(
                name: "PermissionsRoles",
                columns: table => new
                {
                    permissionsId = table.Column<int>(type: "int", nullable: false),
                    rolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsRoles", x => new { x.permissionsId, x.rolesId });
                    table.ForeignKey(
                        name: "FK_PermissionsRoles_Permissions_permissionsId",
                        column: x => x.permissionsId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionsRoles_Roles_rolesId",
                        column: x => x.rolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsRoles_rolesId",
                table: "PermissionsRoles",
                column: "rolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionsRoles");

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Permissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RolesId",
                table: "Permissions",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RolesId",
                table: "Permissions",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}

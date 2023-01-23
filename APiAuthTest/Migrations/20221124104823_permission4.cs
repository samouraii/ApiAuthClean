using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiAuthTest.Migrations
{
    public partial class permission4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsRoles_Permissions_permissionsId",
                table: "PermissionsRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsUser_Permissions_permissionsId",
                table: "PermissionsUser");

            migrationBuilder.DropTable(
                name: "RolesUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsRoles_Permission_permissionsId",
                table: "PermissionsRoles",
                column: "permissionsId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsUser_Permission_permissionsId",
                table: "PermissionsUser",
                column: "permissionsId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsRoles_Permission_permissionsId",
                table: "PermissionsRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsUser_Permission_permissionsId",
                table: "PermissionsUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RolesUser",
                columns: table => new
                {
                    rolesId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUser", x => new { x.rolesId, x.usersId });
                    table.ForeignKey(
                        name: "FK_RolesUser_Roles_rolesId",
                        column: x => x.rolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUser_User_usersId",
                        column: x => x.usersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolesUser_usersId",
                table: "RolesUser",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsRoles_Permissions_permissionsId",
                table: "PermissionsRoles",
                column: "permissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsUser_Permissions_permissionsId",
                table: "PermissionsUser",
                column: "permissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

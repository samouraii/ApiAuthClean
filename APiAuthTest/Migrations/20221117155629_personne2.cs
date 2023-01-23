using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiAuthTest.Migrations
{
    public partial class personne2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Personne_personneIdPersonne",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "personneIdPersonne",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Personne_personneIdPersonne",
                table: "User",
                column: "personneIdPersonne",
                principalTable: "Personne",
                principalColumn: "IdPersonne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Personne_personneIdPersonne",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "personneIdPersonne",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Personne_personneIdPersonne",
                table: "User",
                column: "personneIdPersonne",
                principalTable: "Personne",
                principalColumn: "IdPersonne",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

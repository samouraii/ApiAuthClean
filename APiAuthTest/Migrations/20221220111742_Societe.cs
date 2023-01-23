using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiAuthTest.Migrations
{
    public partial class Societe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "societeIdSociete",
                table: "Contact",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "societe",
                columns: table => new
                {
                    IdSociete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTVA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_societe", x => x.IdSociete);
                });

            migrationBuilder.CreateTable(
                name: "Personnesociete",
                columns: table => new
                {
                    PersonnesIdPersonne = table.Column<int>(type: "int", nullable: false),
                    SocietesIdSociete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnesociete", x => new { x.PersonnesIdPersonne, x.SocietesIdSociete });
                    table.ForeignKey(
                        name: "FK_Personnesociete_Personne_PersonnesIdPersonne",
                        column: x => x.PersonnesIdPersonne,
                        principalTable: "Personne",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnesociete_societe_SocietesIdSociete",
                        column: x => x.SocietesIdSociete,
                        principalTable: "societe",
                        principalColumn: "IdSociete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_societeIdSociete",
                table: "Contact",
                column: "societeIdSociete");

            migrationBuilder.CreateIndex(
                name: "IX_Personnesociete_SocietesIdSociete",
                table: "Personnesociete",
                column: "SocietesIdSociete");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_societe_societeIdSociete",
                table: "Contact",
                column: "societeIdSociete",
                principalTable: "societe",
                principalColumn: "IdSociete",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_societe_societeIdSociete",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "Personnesociete");

            migrationBuilder.DropTable(
                name: "societe");

            migrationBuilder.DropIndex(
                name: "IX_Contact_societeIdSociete",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "societeIdSociete",
                table: "Contact");
        }
    }
}

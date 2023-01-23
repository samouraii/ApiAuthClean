using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiAuthTest.Migrations
{
    public partial class Moyendeconcate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoyenDeConctact",
                columns: table => new
                {
                    IdMoyenContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameContact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoyenDeConctact", x => x.IdMoyenContact);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    IdContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personneIdPersonne = table.Column<int>(type: "int", nullable: false),
                    typeContactIdMoyenContact = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.IdContact);
                    table.ForeignKey(
                        name: "FK_Contact_MoyenDeConctact_typeContactIdMoyenContact",
                        column: x => x.typeContactIdMoyenContact,
                        principalTable: "MoyenDeConctact",
                        principalColumn: "IdMoyenContact",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_Personne_personneIdPersonne",
                        column: x => x.personneIdPersonne,
                        principalTable: "Personne",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_personneIdPersonne",
                table: "Contact",
                column: "personneIdPersonne");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_typeContactIdMoyenContact",
                table: "Contact",
                column: "typeContactIdMoyenContact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "MoyenDeConctact");
        }
    }
}

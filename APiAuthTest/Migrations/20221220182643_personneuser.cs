using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiAuthTest.Migrations
{
    public partial class personneuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_MoyenDeConctact_typeContactIdMoyenContact",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Personne_personneIdPersonne",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_societe_societeIdSociete",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Personne_personneIdPersonne",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_personneIdPersonne",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoyenDeConctact",
                table: "MoyenDeConctact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "MoyenDeConctact",
                newName: "MoyenDeConctacts");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "contacts");

            migrationBuilder.RenameColumn(
                name: "personneIdPersonne",
                table: "User",
                newName: "Personne");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_typeContactIdMoyenContact",
                table: "contacts",
                newName: "IX_contacts_typeContactIdMoyenContact");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_societeIdSociete",
                table: "contacts",
                newName: "IX_contacts_societeIdSociete");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_personneIdPersonne",
                table: "contacts",
                newName: "IX_contacts_personneIdPersonne");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoyenDeConctacts",
                table: "MoyenDeConctacts",
                column: "IdMoyenContact");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                table: "contacts",
                column: "IdContact");

            migrationBuilder.CreateIndex(
                name: "IX_User_Personne",
                table: "User",
                column: "Personne",
                unique: true,
                filter: "[Personne] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_MoyenDeConctacts_typeContactIdMoyenContact",
                table: "contacts",
                column: "typeContactIdMoyenContact",
                principalTable: "MoyenDeConctacts",
                principalColumn: "IdMoyenContact",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_Personne_personneIdPersonne",
                table: "contacts",
                column: "personneIdPersonne",
                principalTable: "Personne",
                principalColumn: "IdPersonne",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_societe_societeIdSociete",
                table: "contacts",
                column: "societeIdSociete",
                principalTable: "societe",
                principalColumn: "IdSociete",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Personne_Personne",
                table: "User",
                column: "Personne",
                principalTable: "Personne",
                principalColumn: "IdPersonne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_MoyenDeConctacts_typeContactIdMoyenContact",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_Personne_personneIdPersonne",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_societe_societeIdSociete",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Personne_Personne",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Personne",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoyenDeConctacts",
                table: "MoyenDeConctacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "MoyenDeConctacts",
                newName: "MoyenDeConctact");

            migrationBuilder.RenameTable(
                name: "contacts",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "Personne",
                table: "User",
                newName: "personneIdPersonne");

            migrationBuilder.RenameIndex(
                name: "IX_contacts_typeContactIdMoyenContact",
                table: "Contact",
                newName: "IX_Contact_typeContactIdMoyenContact");

            migrationBuilder.RenameIndex(
                name: "IX_contacts_societeIdSociete",
                table: "Contact",
                newName: "IX_Contact_societeIdSociete");

            migrationBuilder.RenameIndex(
                name: "IX_contacts_personneIdPersonne",
                table: "Contact",
                newName: "IX_Contact_personneIdPersonne");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoyenDeConctact",
                table: "MoyenDeConctact",
                column: "IdMoyenContact");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "IdContact");

            migrationBuilder.CreateIndex(
                name: "IX_User_personneIdPersonne",
                table: "User",
                column: "personneIdPersonne");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_MoyenDeConctact_typeContactIdMoyenContact",
                table: "Contact",
                column: "typeContactIdMoyenContact",
                principalTable: "MoyenDeConctact",
                principalColumn: "IdMoyenContact",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Personne_personneIdPersonne",
                table: "Contact",
                column: "personneIdPersonne",
                principalTable: "Personne",
                principalColumn: "IdPersonne",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_societe_societeIdSociete",
                table: "Contact",
                column: "societeIdSociete",
                principalTable: "societe",
                principalColumn: "IdSociete",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Personne_personneIdPersonne",
                table: "User",
                column: "personneIdPersonne",
                principalTable: "Personne",
                principalColumn: "IdPersonne");
        }
    }
}

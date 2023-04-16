using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiAuthTest.Migrations
{
    /// <inheritdoc />
    public partial class caisse2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoyenDeConctacts",
                columns: table => new
                {
                    IdMoyenContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameContact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoyenDeConctacts", x => x.IdMoyenContact);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    IdPersonne = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.IdPersonne);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Personne = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Personne_Personne",
                        column: x => x.Personne,
                        principalTable: "Personne",
                        principalColumn: "IdPersonne");
                });

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
                        name: "FK_PermissionsRoles_Permission_permissionsId",
                        column: x => x.permissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionsRoles_Roles_rolesId",
                        column: x => x.rolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    IdContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personneIdPersonne = table.Column<int>(type: "int", nullable: false),
                    typeContactIdMoyenContact = table.Column<int>(type: "int", nullable: false),
                    societeIdSociete = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.IdContact);
                    table.ForeignKey(
                        name: "FK_contacts_MoyenDeConctacts_typeContactIdMoyenContact",
                        column: x => x.typeContactIdMoyenContact,
                        principalTable: "MoyenDeConctacts",
                        principalColumn: "IdMoyenContact",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contacts_Personne_personneIdPersonne",
                        column: x => x.personneIdPersonne,
                        principalTable: "Personne",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contacts_societe_societeIdSociete",
                        column: x => x.societeIdSociete,
                        principalTable: "societe",
                        principalColumn: "IdSociete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonneSociete",
                columns: table => new
                {
                    PersonnesIdPersonne = table.Column<int>(type: "int", nullable: false),
                    SocietesIdSociete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneSociete", x => new { x.PersonnesIdPersonne, x.SocietesIdSociete });
                    table.ForeignKey(
                        name: "FK_PersonneSociete_Personne_PersonnesIdPersonne",
                        column: x => x.PersonnesIdPersonne,
                        principalTable: "Personne",
                        principalColumn: "IdPersonne",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonneSociete_societe_SocietesIdSociete",
                        column: x => x.SocietesIdSociete,
                        principalTable: "societe",
                        principalColumn: "IdSociete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gestionCaisses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCaisse = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Billet500 = table.Column<int>(type: "int", nullable: false),
                    Billet100 = table.Column<int>(type: "int", nullable: false),
                    Billet050 = table.Column<int>(type: "int", nullable: false),
                    Billet020 = table.Column<int>(type: "int", nullable: false),
                    Billet010 = table.Column<int>(type: "int", nullable: false),
                    Billet005 = table.Column<int>(type: "int", nullable: false),
                    Billet002 = table.Column<int>(type: "int", nullable: false),
                    Billet001 = table.Column<int>(type: "int", nullable: false),
                    Piece50 = table.Column<int>(type: "int", nullable: false),
                    Piece20 = table.Column<int>(type: "int", nullable: false),
                    Piece10 = table.Column<int>(type: "int", nullable: false),
                    Piece05 = table.Column<int>(type: "int", nullable: false),
                    TotalBancontact = table.Column<decimal>(type: "money", nullable: false),
                    TotalRetrait = table.Column<decimal>(type: "money", nullable: false),
                    NbBiere = table.Column<int>(type: "int", nullable: false),
                    Societe = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gestionCaisses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gestionCaisses_User_User",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gestionCaisses_societe_Societe",
                        column: x => x.Societe,
                        principalTable: "societe",
                        principalColumn: "IdSociete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionsUser",
                columns: table => new
                {
                    permissionsId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsUser", x => new { x.permissionsId, x.usersId });
                    table.ForeignKey(
                        name: "FK_PermissionsUser_Permission_permissionsId",
                        column: x => x.permissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionsUser_User_usersId",
                        column: x => x.usersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_personneIdPersonne",
                table: "contacts",
                column: "personneIdPersonne");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_societeIdSociete",
                table: "contacts",
                column: "societeIdSociete");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_typeContactIdMoyenContact",
                table: "contacts",
                column: "typeContactIdMoyenContact");

            migrationBuilder.CreateIndex(
                name: "IX_gestionCaisses_Societe",
                table: "gestionCaisses",
                column: "Societe");

            migrationBuilder.CreateIndex(
                name: "IX_gestionCaisses_User",
                table: "gestionCaisses",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsRoles_rolesId",
                table: "PermissionsRoles",
                column: "rolesId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsUser_usersId",
                table: "PermissionsUser",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonneSociete_SocietesIdSociete",
                table: "PersonneSociete",
                column: "SocietesIdSociete");

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserId",
                table: "Token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Personne",
                table: "User",
                column: "Personne",
                unique: true,
                filter: "[Personne] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "gestionCaisses");

            migrationBuilder.DropTable(
                name: "PermissionsRoles");

            migrationBuilder.DropTable(
                name: "PermissionsUser");

            migrationBuilder.DropTable(
                name: "PersonneSociete");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "MoyenDeConctacts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "societe");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}

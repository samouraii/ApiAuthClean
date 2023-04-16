﻿// <auto-generated />
using System;
using APiAuthTest.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APiAuthTest.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APiAuthTest.Model.ApplicationClient.GestionCaisse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Billet001")
                        .HasColumnType("int");

                    b.Property<int>("Billet002")
                        .HasColumnType("int");

                    b.Property<int>("Billet005")
                        .HasColumnType("int");

                    b.Property<int>("Billet010")
                        .HasColumnType("int");

                    b.Property<int>("Billet020")
                        .HasColumnType("int");

                    b.Property<int>("Billet050")
                        .HasColumnType("int");

                    b.Property<int>("Billet100")
                        .HasColumnType("int");

                    b.Property<int>("Billet500")
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCaisse")
                        .HasColumnType("datetime2");

                    b.Property<int>("NbBiere")
                        .HasColumnType("int");

                    b.Property<int>("Piece05")
                        .HasColumnType("int");

                    b.Property<int>("Piece10")
                        .HasColumnType("int");

                    b.Property<int>("Piece20")
                        .HasColumnType("int");

                    b.Property<int>("Piece50")
                        .HasColumnType("int");

                    b.Property<int>("Societe")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalBancontact")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalRetrait")
                        .HasColumnType("money");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Societe");

                    b.HasIndex("User");

                    b.ToTable("gestionCaisses");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Contact", b =>
                {
                    b.Property<int>("IdContact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContact"));

                    b.Property<int>("personneIdPersonne")
                        .HasColumnType("int");

                    b.Property<int>("societeIdSociete")
                        .HasColumnType("int");

                    b.Property<int>("typeContactIdMoyenContact")
                        .HasColumnType("int");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContact");

                    b.HasIndex("personneIdPersonne");

                    b.HasIndex("societeIdSociete");

                    b.HasIndex("typeContactIdMoyenContact");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.MoyenDeConctact", b =>
                {
                    b.Property<int>("IdMoyenContact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMoyenContact"));

                    b.Property<string>("NameContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMoyenContact");

                    b.ToTable("MoyenDeConctacts");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Personne", b =>
                {
                    b.Property<int>("IdPersonne")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonne"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersonne");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Societe", b =>
                {
                    b.Property<int>("IdSociete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSociete"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTVA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSociete");

                    b.ToTable("societe");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Token", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("Personne")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Personne")
                        .IsUnique()
                        .HasFilter("[Personne] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PermissionsRoles", b =>
                {
                    b.Property<int>("permissionsId")
                        .HasColumnType("int");

                    b.Property<int>("rolesId")
                        .HasColumnType("int");

                    b.HasKey("permissionsId", "rolesId");

                    b.HasIndex("rolesId");

                    b.ToTable("PermissionsRoles");
                });

            modelBuilder.Entity("PermissionsUser", b =>
                {
                    b.Property<int>("permissionsId")
                        .HasColumnType("int");

                    b.Property<int>("usersId")
                        .HasColumnType("int");

                    b.HasKey("permissionsId", "usersId");

                    b.HasIndex("usersId");

                    b.ToTable("PermissionsUser");
                });

            modelBuilder.Entity("PersonneSociete", b =>
                {
                    b.Property<int>("PersonnesIdPersonne")
                        .HasColumnType("int");

                    b.Property<int>("SocietesIdSociete")
                        .HasColumnType("int");

                    b.HasKey("PersonnesIdPersonne", "SocietesIdSociete");

                    b.HasIndex("SocietesIdSociete");

                    b.ToTable("PersonneSociete");
                });

            modelBuilder.Entity("APiAuthTest.Model.ApplicationClient.GestionCaisse", b =>
                {
                    b.HasOne("APiAuthTest.Model.UserModel.Societe", "societe")
                        .WithMany("caisse")
                        .HasForeignKey("Societe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APiAuthTest.Model.UserModel.User", "EncoderPar")
                        .WithMany("CaisseEncoder")
                        .HasForeignKey("User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EncoderPar");

                    b.Navigation("societe");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Contact", b =>
                {
                    b.HasOne("APiAuthTest.Model.UserModel.Personne", "personne")
                        .WithMany("Contacts")
                        .HasForeignKey("personneIdPersonne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APiAuthTest.Model.UserModel.Societe", "societe")
                        .WithMany()
                        .HasForeignKey("societeIdSociete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APiAuthTest.Model.UserModel.MoyenDeConctact", "typeContact")
                        .WithMany("Contacts")
                        .HasForeignKey("typeContactIdMoyenContact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("personne");

                    b.Navigation("societe");

                    b.Navigation("typeContact");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Token", b =>
                {
                    b.HasOne("APiAuthTest.Model.UserModel.User", null)
                        .WithMany("token")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.User", b =>
                {
                    b.HasOne("APiAuthTest.Model.UserModel.Personne", "personne")
                        .WithOne("user")
                        .HasForeignKey("APiAuthTest.Model.UserModel.User", "Personne");

                    b.Navigation("personne");
                });

            modelBuilder.Entity("PermissionsRoles", b =>
                {
                    b.HasOne("APiAuthTest.Model.UserModel.Permissions", null)
                        .WithMany()
                        .HasForeignKey("permissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APiAuthTest.Model.UserModel.Roles", null)
                        .WithMany()
                        .HasForeignKey("rolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PermissionsUser", b =>
                {
                    b.HasOne("APiAuthTest.Model.UserModel.Permissions", null)
                        .WithMany()
                        .HasForeignKey("permissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APiAuthTest.Model.UserModel.User", null)
                        .WithMany()
                        .HasForeignKey("usersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonneSociete", b =>
                {
                    b.HasOne("APiAuthTest.Model.UserModel.Personne", null)
                        .WithMany()
                        .HasForeignKey("PersonnesIdPersonne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APiAuthTest.Model.UserModel.Societe", null)
                        .WithMany()
                        .HasForeignKey("SocietesIdSociete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.MoyenDeConctact", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Personne", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("user");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Societe", b =>
                {
                    b.Navigation("caisse");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.User", b =>
                {
                    b.Navigation("CaisseEncoder");

                    b.Navigation("token");
                });
#pragma warning restore 612, 618
        }
    }
}

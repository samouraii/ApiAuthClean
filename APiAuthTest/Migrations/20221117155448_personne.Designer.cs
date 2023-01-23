﻿// <auto-generated />
using System;
using APiAuthTest.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APiAuthTest.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20221117155448_personne")]
    partial class personne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APiAuthTest.Model.UserModel.Personne", b =>
                {
                    b.Property<int>("IdPersonne")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonne"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersonne");

                    b.ToTable("Personne");
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("personneIdPersonne")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("personneIdPersonne");

                    b.ToTable("User");
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
                        .WithMany()
                        .HasForeignKey("personneIdPersonne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("personne");
                });

            modelBuilder.Entity("APiAuthTest.Model.UserModel.User", b =>
                {
                    b.Navigation("token");
                });
#pragma warning restore 612, 618
        }
    }
}
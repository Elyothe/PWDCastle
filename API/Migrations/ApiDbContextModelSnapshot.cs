﻿// <auto-generated />
using System;
using API.ApiDbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("API.Models.challenge", b =>
                {
                    b.Property<int>("idChal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("idChal"));

                    b.Property<string>("c_Desc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("c_NbPoint")
                        .HasColumnType("int");

                    b.Property<int>("c_Status")
                        .HasColumnType("int");

                    b.Property<string>("c_libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("c_step")
                        .HasColumnType("int");

                    b.HasKey("idChal");

                    b.HasIndex("c_Status");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("API.Models.challenge_Done", b =>
                {
                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<int>("idChal")
                        .HasColumnType("int");

                    b.Property<bool>("cd_done")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("cd_step")
                        .HasColumnType("int");

                    b.Property<int>("idImgChal")
                        .HasColumnType("int");

                    b.HasKey("idUser", "idChal");

                    b.HasIndex("idChal");

                    b.ToTable("Challenge_Done");
                });

            modelBuilder.Entity("API.Models.etablissement", b =>
                {
                    b.Property<int>("idetab")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("idetab"));

                    b.Property<string>("e_Nom")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("idetab");

                    b.ToTable("Etablissements");
                });

            modelBuilder.Entity("API.Models.imageChallenge", b =>
                {
                    b.Property<int>("id_ic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id_ic"));

                    b.Property<string>("ic_desc")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ic_image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("idUser_catch")
                        .HasColumnType("int");

                    b.HasKey("id_ic");

                    b.HasIndex("idUser_catch");

                    b.ToTable("ImageChallenges");
                });

            modelBuilder.Entity("API.Models.question", b =>
                {
                    b.Property<int>("idQuestion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("idQuestion"));

                    b.Property<int>("idChal")
                        .HasColumnType("int");

                    b.Property<int>("q_point")
                        .HasColumnType("int");

                    b.Property<string>("q_question")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("q_reponse")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("idQuestion");

                    b.HasIndex("idChal");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("API.Models.status", b =>
                {
                    b.Property<int>("idStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("idStatus"));

                    b.Property<string>("s_Nom")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("idStatus");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("API.Models.users", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("idUser"));

                    b.Property<int>("idgroupe")
                        .HasColumnType("int");

                    b.Property<string>("u_Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("u_NbPoint")
                        .HasColumnType("int");

                    b.Property<string>("u_Nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("u_Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("u_idEtab")
                        .HasColumnType("int");

                    b.HasKey("idUser");

                    b.HasIndex("idgroupe");

                    b.HasIndex("u_idEtab");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.challenge", b =>
                {
                    b.HasOne("API.Models.status", "status")
                        .WithMany("Challenges")
                        .HasForeignKey("c_Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("status");
                });

            modelBuilder.Entity("API.Models.challenge_Done", b =>
                {
                    b.HasOne("API.Models.challenge", "challenge")
                        .WithMany("challenge_Done")
                        .HasForeignKey("idChal")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.users", "user")
                        .WithMany("challenge_Done")
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("challenge");

                    b.Navigation("user");
                });

            modelBuilder.Entity("API.Models.imageChallenge", b =>
                {
                    b.HasOne("API.Models.users", "userCatch")
                        .WithMany("imageChallenges")
                        .HasForeignKey("idUser_catch")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("userCatch");
                });

            modelBuilder.Entity("API.Models.question", b =>
                {
                    b.HasOne("API.Models.challenge", "challenge")
                        .WithMany("questions")
                        .HasForeignKey("idChal")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("challenge");
                });

            modelBuilder.Entity("API.Models.users", b =>
                {
                    b.HasOne("API.Models.status", "status")
                        .WithMany("Users")
                        .HasForeignKey("idgroupe")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.etablissement", "etablissement")
                        .WithMany("users")
                        .HasForeignKey("u_idEtab")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("etablissement");

                    b.Navigation("status");
                });

            modelBuilder.Entity("API.Models.challenge", b =>
                {
                    b.Navigation("challenge_Done");

                    b.Navigation("questions");
                });

            modelBuilder.Entity("API.Models.etablissement", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("API.Models.status", b =>
                {
                    b.Navigation("Challenges");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("API.Models.users", b =>
                {
                    b.Navigation("challenge_Done");

                    b.Navigation("imageChallenges");
                });
#pragma warning restore 612, 618
        }
    }
}

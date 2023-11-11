﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RéservationApp.Data;

#nullable disable

namespace RéservationApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231028081236_CreateTable")]
    partial class CreateTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RéservationApp.Models.Aeroport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("AeroportCodeIATA")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AeroportCodeOACI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AeroportContact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AeroportLocalisation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AeroportNom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CompagnieID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CompagnieID");

                    b.ToTable("Aeroports");
                });

            modelBuilder.Entity("RéservationApp.Models.Agent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("AgentAdresse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgentContact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgentFonction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgentGenre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgentMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgentMotPasse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgentNom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AgentPrenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("RéservationApp.Models.AvionCargo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<double>("AvionCapacite")
                        .HasColumnType("double precision");

                    b.Property<string>("AvionModele")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("AvionCargos");
                });

            modelBuilder.Entity("RéservationApp.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ClientAdresse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientContact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientMotPasse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientNom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientPrenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ClientMail")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RéservationApp.Models.Compagnie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("CompagnieNom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Compagnies");
                });

            modelBuilder.Entity("RéservationApp.Models.CoutFret", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("AgentID")
                        .HasColumnType("integer");

                    b.Property<double>("Cout")
                        .HasColumnType("double precision");

                    b.Property<double>("CoutPoidsMax")
                        .HasColumnType("double precision");

                    b.Property<double>("CoutPoidsMin")
                        .HasColumnType("double precision");

                    b.HasKey("ID");

                    b.HasIndex("AgentID");

                    b.ToTable("CoutFrets");
                });

            modelBuilder.Entity("RéservationApp.Models.Escale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("EscaleNumero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EscaleVille")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VolCargoID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("VolCargoID");

                    b.ToTable("Escales");
                });

            modelBuilder.Entity("RéservationApp.Models.Exemple", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("cal1")
                        .HasColumnType("integer");

                    b.Property<int>("cal2")
                        .HasColumnType("integer");

                    b.Property<int>("chiffre")
                        .HasColumnType("integer");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Exemples");
                });

            modelBuilder.Entity("RéservationApp.Models.Itineraire", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ItineraireArrive")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItineraireDepart")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Itineraires");
                });

            modelBuilder.Entity("RéservationApp.Models.LTA", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("LTADateEmission")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LTANumero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VenteID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("VenteID");

                    b.ToTable("LTAs");
                });

            modelBuilder.Entity("RéservationApp.Models.Marchandise", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("MarchandiseDesignation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MarchandiseNombre")
                        .HasColumnType("integer");

                    b.Property<double>("MarchandisePoids")
                        .HasColumnType("double precision");

                    b.Property<double>("MarchandiseVolume")
                        .HasColumnType("double precision");

                    b.Property<int>("Nature_MarchandiseID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("Nature_MarchandiseID");

                    b.ToTable("Marchandises");
                });

            modelBuilder.Entity("RéservationApp.Models.ModèleLogin.TblMenu", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LinkName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("tbl_menu", (string)null);
                });

            modelBuilder.Entity("RéservationApp.Models.ModèleLogin.TblPermission", b =>
                {
                    b.Property<string>("RoleId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("MenuId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.HasKey("RoleId", "MenuId");

                    b.ToTable("tbl_permission", (string)null);
                });

            modelBuilder.Entity("RéservationApp.Models.ModèleLogin.TblRefreshtoken", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TokenId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserId");

                    b.ToTable("tbl_refreshtoken", (string)null);
                });

            modelBuilder.Entity("RéservationApp.Models.ModèleLogin.TblRole", b =>
                {
                    b.Property<string>("Roleid")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("roleid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Roleid");

                    b.ToTable("tbl_role", (string)null);
                });

            modelBuilder.Entity("RéservationApp.Models.ModèleLogin.TblUser", b =>
                {
                    b.Property<string>("Userid")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("userid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Userid");

                    b.ToTable("tbl_user", (string)null);
                });

            modelBuilder.Entity("RéservationApp.Models.Nature_Marchandise", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("NatureMarchandiseLibelle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeTarifID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("TypeTarifID");

                    b.ToTable("Nature_Marchandises");
                });

            modelBuilder.Entity("RéservationApp.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateExpeditionSouhaite")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ItineraireID")
                        .HasColumnType("integer");

                    b.Property<int>("MarchandiseID")
                        .HasColumnType("integer");

                    b.Property<string>("NomDestinaire")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReservationEtat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReservationExigences")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VolCargoID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ItineraireID");

                    b.HasIndex("MarchandiseID");

                    b.HasIndex("VolCargoID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RéservationApp.Models.TypeTarif", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<double>("TarifAnnexe")
                        .HasColumnType("double precision");

                    b.Property<double>("TarifFraisAssurance")
                        .HasColumnType("double precision");

                    b.Property<string>("TarifLibelle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("TarifValeur")
                        .HasColumnType("double precision");

                    b.HasKey("ID");

                    b.ToTable("TypeTarifs");
                });

            modelBuilder.Entity("RéservationApp.Models.Vente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("AgentID")
                        .HasColumnType("integer");

                    b.Property<int>("ReservationID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VenteDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("AgentID");

                    b.HasIndex("ReservationID");

                    b.ToTable("Ventes");
                });

            modelBuilder.Entity("RéservationApp.Models.VolCargo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("AeroportID")
                        .HasColumnType("integer");

                    b.Property<int>("AvionCargoID")
                        .HasColumnType("integer");

                    b.Property<int>("ItineraireID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VolDateHeureArrivee")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("VolDateHeureDepart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("VolNumero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VolStatut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AeroportID");

                    b.HasIndex("AvionCargoID");

                    b.HasIndex("ItineraireID");

                    b.ToTable("VolCargos");
                });

            modelBuilder.Entity("RéservationApp.Models.Aeroport", b =>
                {
                    b.HasOne("RéservationApp.Models.Compagnie", "Compagnie")
                        .WithMany("Aeroports")
                        .HasForeignKey("CompagnieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compagnie");
                });

            modelBuilder.Entity("RéservationApp.Models.CoutFret", b =>
                {
                    b.HasOne("RéservationApp.Models.Agent", "Agent")
                        .WithMany("CoutFrets")
                        .HasForeignKey("AgentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("RéservationApp.Models.Escale", b =>
                {
                    b.HasOne("RéservationApp.Models.VolCargo", "VolCargo")
                        .WithMany("Escales")
                        .HasForeignKey("VolCargoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VolCargo");
                });

            modelBuilder.Entity("RéservationApp.Models.LTA", b =>
                {
                    b.HasOne("RéservationApp.Models.Vente", "Vente")
                        .WithMany("LTAs")
                        .HasForeignKey("VenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vente");
                });

            modelBuilder.Entity("RéservationApp.Models.Marchandise", b =>
                {
                    b.HasOne("RéservationApp.Models.Nature_Marchandise", "Nature_Marchandise")
                        .WithMany("Marchandises")
                        .HasForeignKey("Nature_MarchandiseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nature_Marchandise");
                });

            modelBuilder.Entity("RéservationApp.Models.Nature_Marchandise", b =>
                {
                    b.HasOne("RéservationApp.Models.TypeTarif", "TypeTarif")
                        .WithMany("Nature_Marchandises")
                        .HasForeignKey("TypeTarifID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeTarif");
                });

            modelBuilder.Entity("RéservationApp.Models.Reservation", b =>
                {
                    b.HasOne("RéservationApp.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.Itineraire", "Itineraire")
                        .WithMany("Reservations")
                        .HasForeignKey("ItineraireID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.Marchandise", "Marchandise")
                        .WithMany("Reservations")
                        .HasForeignKey("MarchandiseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.VolCargo", "VolCargo")
                        .WithMany("Reservations")
                        .HasForeignKey("VolCargoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Itineraire");

                    b.Navigation("Marchandise");

                    b.Navigation("VolCargo");
                });

            modelBuilder.Entity("RéservationApp.Models.Vente", b =>
                {
                    b.HasOne("RéservationApp.Models.Agent", "Agent")
                        .WithMany("Ventes")
                        .HasForeignKey("AgentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.Reservation", "Reservation")
                        .WithMany("Ventes")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RéservationApp.Models.VolCargo", b =>
                {
                    b.HasOne("RéservationApp.Models.Aeroport", "Aeroport")
                        .WithMany("VolCargos")
                        .HasForeignKey("AeroportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.AvionCargo", "AvionCargo")
                        .WithMany("VolCargos")
                        .HasForeignKey("AvionCargoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.Itineraire", "Itineraire")
                        .WithMany("VolCargos")
                        .HasForeignKey("ItineraireID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeroport");

                    b.Navigation("AvionCargo");

                    b.Navigation("Itineraire");
                });

            modelBuilder.Entity("RéservationApp.Models.Aeroport", b =>
                {
                    b.Navigation("VolCargos");
                });

            modelBuilder.Entity("RéservationApp.Models.Agent", b =>
                {
                    b.Navigation("CoutFrets");

                    b.Navigation("Ventes");
                });

            modelBuilder.Entity("RéservationApp.Models.AvionCargo", b =>
                {
                    b.Navigation("VolCargos");
                });

            modelBuilder.Entity("RéservationApp.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RéservationApp.Models.Compagnie", b =>
                {
                    b.Navigation("Aeroports");
                });

            modelBuilder.Entity("RéservationApp.Models.Itineraire", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("VolCargos");
                });

            modelBuilder.Entity("RéservationApp.Models.Marchandise", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RéservationApp.Models.Nature_Marchandise", b =>
                {
                    b.Navigation("Marchandises");
                });

            modelBuilder.Entity("RéservationApp.Models.Reservation", b =>
                {
                    b.Navigation("Ventes");
                });

            modelBuilder.Entity("RéservationApp.Models.TypeTarif", b =>
                {
                    b.Navigation("Nature_Marchandises");
                });

            modelBuilder.Entity("RéservationApp.Models.Vente", b =>
                {
                    b.Navigation("LTAs");
                });

            modelBuilder.Entity("RéservationApp.Models.VolCargo", b =>
                {
                    b.Navigation("Escales");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}

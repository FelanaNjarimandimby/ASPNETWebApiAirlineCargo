﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RéservationApp.Data;

#nullable disable

namespace RéservationApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RéservationApp.Models.Client", b =>
                {
                    b.Property<int>("IDClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDClient"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomClient")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IDClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RéservationApp.Models.LTA", b =>
                {
                    b.Property<int>("RefReservation")
                        .HasColumnType("integer");

                    b.Property<int>("IDTarif")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateLTA")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumLTA")
                        .HasColumnType("integer");

                    b.HasKey("RefReservation", "IDTarif");

                    b.HasIndex("IDTarif");

                    b.ToTable("LTAs");
                });

            modelBuilder.Entity("RéservationApp.Models.Marchandise", b =>
                {
                    b.Property<int>("IDMarchandise")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDMarchandise"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Dimension")
                        .HasColumnType("double precision");

                    b.Property<int>("Nature_MarchandiseIDNatureMarchandise")
                        .HasColumnType("integer");

                    b.Property<int>("NombreColis")
                        .HasColumnType("integer");

                    b.Property<double>("Poids")
                        .HasColumnType("double precision");

                    b.Property<string>("Volume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IDMarchandise");

                    b.HasIndex("Nature_MarchandiseIDNatureMarchandise");

                    b.ToTable("Marchandises");
                });

            modelBuilder.Entity("RéservationApp.Models.Nature_Marchandise", b =>
                {
                    b.Property<int>("IDNatureMarchandise")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDNatureMarchandise"));

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IDNatureMarchandise");

                    b.ToTable("Nature_Marchandises");
                });

            modelBuilder.Entity("RéservationApp.Models.Reservation", b =>
                {
                    b.Property<int>("RefReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RefReservation"));

                    b.Property<string>("AeroportDepart")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AeroportDestination")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClientIDClient")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateExpeditionSouhaite")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EtatReservation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExigencesSpeciales")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MarchandiseIDMarchandise")
                        .HasColumnType("integer");

                    b.Property<string>("NomDestinaire")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VolNumVol")
                        .HasColumnType("integer");

                    b.HasKey("RefReservation");

                    b.HasIndex("ClientIDClient");

                    b.HasIndex("MarchandiseIDMarchandise");

                    b.HasIndex("VolNumVol");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RéservationApp.Models.Tarif", b =>
                {
                    b.Property<int>("IDTarif")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDTarif"));

                    b.Property<int>("Montant")
                        .HasColumnType("integer");

                    b.HasKey("IDTarif");

                    b.ToTable("Tarifs");
                });

            modelBuilder.Entity("RéservationApp.Models.Utilisateur", b =>
                {
                    b.Property<int>("IDUtilisaeur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDUtilisaeur"));

                    b.Property<string>("MotPasse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomUtilisateur")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IDUtilisaeur");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("RéservationApp.Models.Vente", b =>
                {
                    b.Property<int>("IDVente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDVente"));

                    b.Property<DateTime>("DateVente")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LTAIDTarif")
                        .HasColumnType("integer");

                    b.Property<int>("LTARefReservation")
                        .HasColumnType("integer");

                    b.HasKey("IDVente");

                    b.HasIndex("LTARefReservation", "LTAIDTarif");

                    b.ToTable("Ventes");
                });

            modelBuilder.Entity("RéservationApp.Models.Vol", b =>
                {
                    b.Property<int>("NumVol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NumVol"));

                    b.Property<string>("CapaciteChargement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateArrivee")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateDepart")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("NumVol");

                    b.ToTable("Vols");
                });

            modelBuilder.Entity("RéservationApp.Models.LTA", b =>
                {
                    b.HasOne("RéservationApp.Models.Tarif", "Tarif")
                        .WithMany("LTAs")
                        .HasForeignKey("IDTarif")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.Reservation", "Reservation")
                        .WithMany("LTAs")
                        .HasForeignKey("RefReservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Tarif");
                });

            modelBuilder.Entity("RéservationApp.Models.Marchandise", b =>
                {
                    b.HasOne("RéservationApp.Models.Nature_Marchandise", "Nature_Marchandise")
                        .WithMany("Marchandises")
                        .HasForeignKey("Nature_MarchandiseIDNatureMarchandise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nature_Marchandise");
                });

            modelBuilder.Entity("RéservationApp.Models.Reservation", b =>
                {
                    b.HasOne("RéservationApp.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientIDClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.Marchandise", "Marchandise")
                        .WithMany("Reservations")
                        .HasForeignKey("MarchandiseIDMarchandise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RéservationApp.Models.Vol", "Vol")
                        .WithMany("Reservations")
                        .HasForeignKey("VolNumVol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Marchandise");

                    b.Navigation("Vol");
                });

            modelBuilder.Entity("RéservationApp.Models.Vente", b =>
                {
                    b.HasOne("RéservationApp.Models.LTA", "LTA")
                        .WithMany("Ventes")
                        .HasForeignKey("LTARefReservation", "LTAIDTarif")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LTA");
                });

            modelBuilder.Entity("RéservationApp.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RéservationApp.Models.LTA", b =>
                {
                    b.Navigation("Ventes");
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
                    b.Navigation("LTAs");
                });

            modelBuilder.Entity("RéservationApp.Models.Tarif", b =>
                {
                    b.Navigation("LTAs");
                });

            modelBuilder.Entity("RéservationApp.Models.Vol", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}

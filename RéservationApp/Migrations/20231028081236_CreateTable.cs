using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RéservationApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentNom = table.Column<string>(type: "text", nullable: false),
                    AgentPrenom = table.Column<string>(type: "text", nullable: false),
                    AgentGenre = table.Column<string>(type: "text", nullable: false),
                    AgentAdresse = table.Column<string>(type: "text", nullable: false),
                    AgentContact = table.Column<string>(type: "text", nullable: false),
                    AgentFonction = table.Column<string>(type: "text", nullable: false),
                    AgentMail = table.Column<string>(type: "text", nullable: false),
                    AgentMotPasse = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AvionCargos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AvionModele = table.Column<string>(type: "text", nullable: false),
                    AvionCapacite = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvionCargos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientNom = table.Column<string>(type: "text", nullable: false),
                    ClientPrenom = table.Column<string>(type: "text", nullable: false),
                    ClientAdresse = table.Column<string>(type: "text", nullable: false),
                    ClientMail = table.Column<string>(type: "text", nullable: false),
                    ClientContact = table.Column<string>(type: "text", nullable: false),
                    ClientMotPasse = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Compagnies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompagnieNom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compagnies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Itineraires",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItineraireDepart = table.Column<string>(type: "text", nullable: false),
                    ItineraireArrive = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraires", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeTarifs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TarifLibelle = table.Column<string>(type: "text", nullable: false),
                    TarifValeur = table.Column<double>(type: "double precision", nullable: false),
                    TarifFraisAssurance = table.Column<double>(type: "double precision", nullable: false),
                    TarifAnnexe = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTarifs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CoutFrets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CoutPoidsMin = table.Column<double>(type: "double precision", nullable: false),
                    CoutPoidsMax = table.Column<double>(type: "double precision", nullable: false),
                    Cout = table.Column<double>(type: "double precision", nullable: false),
                    AgentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoutFrets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoutFrets_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aeroports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AeroportCodeIATA = table.Column<string>(type: "text", nullable: false),
                    AeroportCodeOACI = table.Column<string>(type: "text", nullable: false),
                    AeroportNom = table.Column<string>(type: "text", nullable: false),
                    AeroportContact = table.Column<string>(type: "text", nullable: false),
                    AeroportLocalisation = table.Column<string>(type: "text", nullable: false),
                    CompagnieID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aeroports_Compagnies_CompagnieID",
                        column: x => x.CompagnieID,
                        principalTable: "Compagnies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nature_Marchandises",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NatureMarchandiseLibelle = table.Column<string>(type: "text", nullable: false),
                    TypeTarifID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nature_Marchandises", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nature_Marchandises_TypeTarifs_TypeTarifID",
                        column: x => x.TypeTarifID,
                        principalTable: "TypeTarifs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolCargos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VolNumero = table.Column<string>(type: "text", nullable: false),
                    VolStatut = table.Column<string>(type: "text", nullable: false),
                    VolDateHeureDepart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VolDateHeureArrivee = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AvionCargoID = table.Column<int>(type: "integer", nullable: false),
                    AeroportID = table.Column<int>(type: "integer", nullable: false),
                    ItineraireID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolCargos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VolCargos_Aeroports_AeroportID",
                        column: x => x.AeroportID,
                        principalTable: "Aeroports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolCargos_AvionCargos_AvionCargoID",
                        column: x => x.AvionCargoID,
                        principalTable: "AvionCargos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolCargos_Itineraires_ItineraireID",
                        column: x => x.ItineraireID,
                        principalTable: "Itineraires",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marchandises",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MarchandiseDesignation = table.Column<string>(type: "text", nullable: false),
                    MarchandiseNombre = table.Column<int>(type: "integer", nullable: false),
                    MarchandisePoids = table.Column<double>(type: "double precision", nullable: false),
                    MarchandiseVolume = table.Column<double>(type: "double precision", nullable: false),
                    Nature_MarchandiseID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marchandises", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Marchandises_Nature_Marchandises_Nature_MarchandiseID",
                        column: x => x.Nature_MarchandiseID,
                        principalTable: "Nature_Marchandises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Escales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EscaleNumero = table.Column<string>(type: "text", nullable: false),
                    EscaleVille = table.Column<string>(type: "text", nullable: false),
                    VolCargoID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Escales_VolCargos_VolCargoID",
                        column: x => x.VolCargoID,
                        principalTable: "VolCargos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomDestinaire = table.Column<string>(type: "text", nullable: false),
                    DateExpeditionSouhaite = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReservationExigences = table.Column<string>(type: "text", nullable: false),
                    ReservationEtat = table.Column<string>(type: "text", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: false),
                    MarchandiseID = table.Column<int>(type: "integer", nullable: false),
                    VolCargoID = table.Column<int>(type: "integer", nullable: false),
                    ItineraireID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Itineraires_ItineraireID",
                        column: x => x.ItineraireID,
                        principalTable: "Itineraires",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Marchandises_MarchandiseID",
                        column: x => x.MarchandiseID,
                        principalTable: "Marchandises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_VolCargos_VolCargoID",
                        column: x => x.VolCargoID,
                        principalTable: "VolCargos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VenteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReservationID = table.Column<int>(type: "integer", nullable: false),
                    AgentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ventes_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventes_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LTAs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LTANumero = table.Column<string>(type: "text", nullable: false),
                    LTADateEmission = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VenteID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LTAs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LTAs_Ventes_VenteID",
                        column: x => x.VenteID,
                        principalTable: "Ventes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aeroports_CompagnieID",
                table: "Aeroports",
                column: "CompagnieID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientMail",
                table: "Clients",
                column: "ClientMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoutFrets_AgentID",
                table: "CoutFrets",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Escales_VolCargoID",
                table: "Escales",
                column: "VolCargoID");

            migrationBuilder.CreateIndex(
                name: "IX_LTAs_VenteID",
                table: "LTAs",
                column: "VenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Marchandises_Nature_MarchandiseID",
                table: "Marchandises",
                column: "Nature_MarchandiseID");

            migrationBuilder.CreateIndex(
                name: "IX_Nature_Marchandises_TypeTarifID",
                table: "Nature_Marchandises",
                column: "TypeTarifID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientID",
                table: "Reservations",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ItineraireID",
                table: "Reservations",
                column: "ItineraireID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MarchandiseID",
                table: "Reservations",
                column: "MarchandiseID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VolCargoID",
                table: "Reservations",
                column: "VolCargoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventes_AgentID",
                table: "Ventes",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventes_ReservationID",
                table: "Ventes",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_VolCargos_AeroportID",
                table: "VolCargos",
                column: "AeroportID");

            migrationBuilder.CreateIndex(
                name: "IX_VolCargos_AvionCargoID",
                table: "VolCargos",
                column: "AvionCargoID");

            migrationBuilder.CreateIndex(
                name: "IX_VolCargos_ItineraireID",
                table: "VolCargos",
                column: "ItineraireID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoutFrets");

            migrationBuilder.DropTable(
                name: "Escales");

            migrationBuilder.DropTable(
                name: "LTAs");

            migrationBuilder.DropTable(
                name: "Ventes");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Marchandises");

            migrationBuilder.DropTable(
                name: "VolCargos");

            migrationBuilder.DropTable(
                name: "Nature_Marchandises");

            migrationBuilder.DropTable(
                name: "Aeroports");

            migrationBuilder.DropTable(
                name: "AvionCargos");

            migrationBuilder.DropTable(
                name: "Itineraires");

            migrationBuilder.DropTable(
                name: "TypeTarifs");

            migrationBuilder.DropTable(
                name: "Compagnies");
        }
    }
}

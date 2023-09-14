using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RéservationApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IDClient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomClient = table.Column<string>(type: "text", nullable: false),
                    Adresse = table.Column<string>(type: "text", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IDClient);
                });

            migrationBuilder.CreateTable(
                name: "Nature_Marchandises",
                columns: table => new
                {
                    IDNatureMarchandise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Libelle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nature_Marchandises", x => x.IDNatureMarchandise);
                });

            migrationBuilder.CreateTable(
                name: "Tarifs",
                columns: table => new
                {
                    IDTarif = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifs", x => x.IDTarif);
                });

            migrationBuilder.CreateTable(
                name: "Vols",
                columns: table => new
                {
                    NumVol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateDepart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateArrivee = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CapaciteChargement = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.NumVol);
                });

            migrationBuilder.CreateTable(
                name: "Marchandises",
                columns: table => new
                {
                    IDMarchandise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    NombreColis = table.Column<int>(type: "integer", nullable: false),
                    Poids = table.Column<double>(type: "double precision", nullable: false),
                    Dimension = table.Column<double>(type: "double precision", nullable: false),
                    Volume = table.Column<string>(type: "text", nullable: false),
                    Nature_MarchandiseIDNatureMarchandise = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marchandises", x => x.IDMarchandise);
                    table.ForeignKey(
                        name: "FK_Marchandises_Nature_Marchandises_Nature_MarchandiseIDNature~",
                        column: x => x.Nature_MarchandiseIDNatureMarchandise,
                        principalTable: "Nature_Marchandises",
                        principalColumn: "IDNatureMarchandise",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    RefReservation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomDestinaire = table.Column<string>(type: "text", nullable: false),
                    AeroportDepart = table.Column<string>(type: "text", nullable: false),
                    AeroportDestination = table.Column<string>(type: "text", nullable: false),
                    DateExpeditionSouhaite = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExigencesSpeciales = table.Column<string>(type: "text", nullable: false),
                    EtatReservation = table.Column<string>(type: "text", nullable: false),
                    ClientIDClient = table.Column<int>(type: "integer", nullable: false),
                    MarchandiseIDMarchandise = table.Column<int>(type: "integer", nullable: false),
                    VolNumVol = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.RefReservation);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientIDClient",
                        column: x => x.ClientIDClient,
                        principalTable: "Clients",
                        principalColumn: "IDClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Marchandises_MarchandiseIDMarchandise",
                        column: x => x.MarchandiseIDMarchandise,
                        principalTable: "Marchandises",
                        principalColumn: "IDMarchandise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Vols_VolNumVol",
                        column: x => x.VolNumVol,
                        principalTable: "Vols",
                        principalColumn: "NumVol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LTAs",
                columns: table => new
                {
                    RefReservation = table.Column<int>(type: "integer", nullable: false),
                    IDTarif = table.Column<int>(type: "integer", nullable: false),
                    NumLTA = table.Column<int>(type: "integer", nullable: false),
                    DateLTA = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LTAs", x => new { x.RefReservation, x.IDTarif });
                    table.ForeignKey(
                        name: "FK_LTAs_Reservations_RefReservation",
                        column: x => x.RefReservation,
                        principalTable: "Reservations",
                        principalColumn: "RefReservation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LTAs_Tarifs_IDTarif",
                        column: x => x.IDTarif,
                        principalTable: "Tarifs",
                        principalColumn: "IDTarif",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventes",
                columns: table => new
                {
                    IDVente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateVente = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LTARefReservation = table.Column<int>(type: "integer", nullable: false),
                    LTAIDTarif = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventes", x => x.IDVente);
                    table.ForeignKey(
                        name: "FK_Ventes_LTAs_LTARefReservation_LTAIDTarif",
                        columns: x => new { x.LTARefReservation, x.LTAIDTarif },
                        principalTable: "LTAs",
                        principalColumns: new[] { "RefReservation", "IDTarif" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LTAs_IDTarif",
                table: "LTAs",
                column: "IDTarif");

            migrationBuilder.CreateIndex(
                name: "IX_Marchandises_Nature_MarchandiseIDNatureMarchandise",
                table: "Marchandises",
                column: "Nature_MarchandiseIDNatureMarchandise");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientIDClient",
                table: "Reservations",
                column: "ClientIDClient");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MarchandiseIDMarchandise",
                table: "Reservations",
                column: "MarchandiseIDMarchandise");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VolNumVol",
                table: "Reservations",
                column: "VolNumVol");

            migrationBuilder.CreateIndex(
                name: "IX_Ventes_LTARefReservation_LTAIDTarif",
                table: "Ventes",
                columns: new[] { "LTARefReservation", "LTAIDTarif" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventes");

            migrationBuilder.DropTable(
                name: "LTAs");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tarifs");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Marchandises");

            migrationBuilder.DropTable(
                name: "Vols");

            migrationBuilder.DropTable(
                name: "Nature_Marchandises");
        }
    }
}

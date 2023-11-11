using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RéservationApp.Migrations
{
    /// <inheritdoc />
    public partial class misAjour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeroports_Compagnies_CompagnieID",
                table: "Aeroports");

            migrationBuilder.DropForeignKey(
                name: "FK_CoutFrets_Agents_AgentID",
                table: "CoutFrets");

            migrationBuilder.DropForeignKey(
                name: "FK_Escales_VolCargos_VolCargoID",
                table: "Escales");

            migrationBuilder.DropForeignKey(
                name: "FK_LTAs_Ventes_VenteID",
                table: "LTAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Marchandises_Nature_Marchandises_Nature_MarchandiseID",
                table: "Marchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_Nature_Marchandises_TypeTarifs_TypeTarifID",
                table: "Nature_Marchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Itineraires_ItineraireID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Marchandises_MarchandiseID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_VolCargos_VolCargoID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Agents_AgentID",
                table: "Ventes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Reservations_ReservationID",
                table: "Ventes");

            migrationBuilder.DropForeignKey(
                name: "FK_VolCargos_Aeroports_AeroportID",
                table: "VolCargos");

            migrationBuilder.DropForeignKey(
                name: "FK_VolCargos_AvionCargos_AvionCargoID",
                table: "VolCargos");

            migrationBuilder.DropForeignKey(
                name: "FK_VolCargos_Itineraires_ItineraireID",
                table: "VolCargos");

            migrationBuilder.RenameColumn(
                name: "ItineraireID",
                table: "VolCargos",
                newName: "Itineraireid");

            migrationBuilder.RenameColumn(
                name: "AvionCargoID",
                table: "VolCargos",
                newName: "AvionCargoid");

            migrationBuilder.RenameColumn(
                name: "AeroportID",
                table: "VolCargos",
                newName: "Aeroportid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "VolCargos",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_VolCargos_ItineraireID",
                table: "VolCargos",
                newName: "IX_VolCargos_Itineraireid");

            migrationBuilder.RenameIndex(
                name: "IX_VolCargos_AvionCargoID",
                table: "VolCargos",
                newName: "IX_VolCargos_AvionCargoid");

            migrationBuilder.RenameIndex(
                name: "IX_VolCargos_AeroportID",
                table: "VolCargos",
                newName: "IX_VolCargos_Aeroportid");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Ventes",
                newName: "Reservationid");

            migrationBuilder.RenameColumn(
                name: "AgentID",
                table: "Ventes",
                newName: "Agentid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Ventes",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Ventes_ReservationID",
                table: "Ventes",
                newName: "IX_Ventes_Reservationid");

            migrationBuilder.RenameIndex(
                name: "IX_Ventes_AgentID",
                table: "Ventes",
                newName: "IX_Ventes_Agentid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TypeTarifs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VolCargoID",
                table: "Reservations",
                newName: "VolCargoid");

            migrationBuilder.RenameColumn(
                name: "MarchandiseID",
                table: "Reservations",
                newName: "Marchandiseid");

            migrationBuilder.RenameColumn(
                name: "ItineraireID",
                table: "Reservations",
                newName: "Itineraireid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reservations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NomDestinaire",
                table: "Reservations",
                newName: "NomDestinataire");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_VolCargoID",
                table: "Reservations",
                newName: "IX_Reservations_VolCargoid");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MarchandiseID",
                table: "Reservations",
                newName: "IX_Reservations_Marchandiseid");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ItineraireID",
                table: "Reservations",
                newName: "IX_Reservations_Itineraireid");

            migrationBuilder.RenameColumn(
                name: "TypeTarifID",
                table: "Nature_Marchandises",
                newName: "TypeTarifid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Nature_Marchandises",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Nature_Marchandises_TypeTarifID",
                table: "Nature_Marchandises",
                newName: "IX_Nature_Marchandises_TypeTarifid");

            migrationBuilder.RenameColumn(
                name: "Nature_MarchandiseID",
                table: "Marchandises",
                newName: "Nature_Marchandiseid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Marchandises",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Marchandises_Nature_MarchandiseID",
                table: "Marchandises",
                newName: "IX_Marchandises_Nature_Marchandiseid");

            migrationBuilder.RenameColumn(
                name: "VenteID",
                table: "LTAs",
                newName: "Venteid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LTAs",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_LTAs_VenteID",
                table: "LTAs",
                newName: "IX_LTAs_Venteid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Itineraires",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VolCargoID",
                table: "Escales",
                newName: "VolCargoid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Escales",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Escales_VolCargoID",
                table: "Escales",
                newName: "IX_Escales_VolCargoid");

            migrationBuilder.RenameColumn(
                name: "AgentID",
                table: "CoutFrets",
                newName: "Agentid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CoutFrets",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_CoutFrets_AgentID",
                table: "CoutFrets",
                newName: "IX_CoutFrets_Agentid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Compagnies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AvionCargos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Agents",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CompagnieID",
                table: "Aeroports",
                newName: "Compagnieid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Aeroports",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Aeroports_CompagnieID",
                table: "Aeroports",
                newName: "IX_Aeroports_Compagnieid");

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroports_Compagnies_Compagnieid",
                table: "Aeroports",
                column: "Compagnieid",
                principalTable: "Compagnies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoutFrets_Agents_Agentid",
                table: "CoutFrets",
                column: "Agentid",
                principalTable: "Agents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Escales_VolCargos_VolCargoid",
                table: "Escales",
                column: "VolCargoid",
                principalTable: "VolCargos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LTAs_Ventes_Venteid",
                table: "LTAs",
                column: "Venteid",
                principalTable: "Ventes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marchandises_Nature_Marchandises_Nature_Marchandiseid",
                table: "Marchandises",
                column: "Nature_Marchandiseid",
                principalTable: "Nature_Marchandises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nature_Marchandises_TypeTarifs_TypeTarifid",
                table: "Nature_Marchandises",
                column: "TypeTarifid",
                principalTable: "TypeTarifs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Itineraires_Itineraireid",
                table: "Reservations",
                column: "Itineraireid",
                principalTable: "Itineraires",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Marchandises_Marchandiseid",
                table: "Reservations",
                column: "Marchandiseid",
                principalTable: "Marchandises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_VolCargos_VolCargoid",
                table: "Reservations",
                column: "VolCargoid",
                principalTable: "VolCargos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Agents_Agentid",
                table: "Ventes",
                column: "Agentid",
                principalTable: "Agents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Reservations_Reservationid",
                table: "Ventes",
                column: "Reservationid",
                principalTable: "Reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolCargos_Aeroports_Aeroportid",
                table: "VolCargos",
                column: "Aeroportid",
                principalTable: "Aeroports",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolCargos_AvionCargos_AvionCargoid",
                table: "VolCargos",
                column: "AvionCargoid",
                principalTable: "AvionCargos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolCargos_Itineraires_Itineraireid",
                table: "VolCargos",
                column: "Itineraireid",
                principalTable: "Itineraires",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeroports_Compagnies_Compagnieid",
                table: "Aeroports");

            migrationBuilder.DropForeignKey(
                name: "FK_CoutFrets_Agents_Agentid",
                table: "CoutFrets");

            migrationBuilder.DropForeignKey(
                name: "FK_Escales_VolCargos_VolCargoid",
                table: "Escales");

            migrationBuilder.DropForeignKey(
                name: "FK_LTAs_Ventes_Venteid",
                table: "LTAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Marchandises_Nature_Marchandises_Nature_Marchandiseid",
                table: "Marchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_Nature_Marchandises_TypeTarifs_TypeTarifid",
                table: "Nature_Marchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Itineraires_Itineraireid",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Marchandises_Marchandiseid",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_VolCargos_VolCargoid",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Agents_Agentid",
                table: "Ventes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Reservations_Reservationid",
                table: "Ventes");

            migrationBuilder.DropForeignKey(
                name: "FK_VolCargos_Aeroports_Aeroportid",
                table: "VolCargos");

            migrationBuilder.DropForeignKey(
                name: "FK_VolCargos_AvionCargos_AvionCargoid",
                table: "VolCargos");

            migrationBuilder.DropForeignKey(
                name: "FK_VolCargos_Itineraires_Itineraireid",
                table: "VolCargos");

            migrationBuilder.RenameColumn(
                name: "Itineraireid",
                table: "VolCargos",
                newName: "ItineraireID");

            migrationBuilder.RenameColumn(
                name: "AvionCargoid",
                table: "VolCargos",
                newName: "AvionCargoID");

            migrationBuilder.RenameColumn(
                name: "Aeroportid",
                table: "VolCargos",
                newName: "AeroportID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "VolCargos",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_VolCargos_Itineraireid",
                table: "VolCargos",
                newName: "IX_VolCargos_ItineraireID");

            migrationBuilder.RenameIndex(
                name: "IX_VolCargos_AvionCargoid",
                table: "VolCargos",
                newName: "IX_VolCargos_AvionCargoID");

            migrationBuilder.RenameIndex(
                name: "IX_VolCargos_Aeroportid",
                table: "VolCargos",
                newName: "IX_VolCargos_AeroportID");

            migrationBuilder.RenameColumn(
                name: "Reservationid",
                table: "Ventes",
                newName: "ReservationID");

            migrationBuilder.RenameColumn(
                name: "Agentid",
                table: "Ventes",
                newName: "AgentID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Ventes",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Ventes_Reservationid",
                table: "Ventes",
                newName: "IX_Ventes_ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Ventes_Agentid",
                table: "Ventes",
                newName: "IX_Ventes_AgentID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TypeTarifs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "VolCargoid",
                table: "Reservations",
                newName: "VolCargoID");

            migrationBuilder.RenameColumn(
                name: "Marchandiseid",
                table: "Reservations",
                newName: "MarchandiseID");

            migrationBuilder.RenameColumn(
                name: "Itineraireid",
                table: "Reservations",
                newName: "ItineraireID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reservations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "NomDestinataire",
                table: "Reservations",
                newName: "NomDestinaire");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_VolCargoid",
                table: "Reservations",
                newName: "IX_Reservations_VolCargoID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_Marchandiseid",
                table: "Reservations",
                newName: "IX_Reservations_MarchandiseID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_Itineraireid",
                table: "Reservations",
                newName: "IX_Reservations_ItineraireID");

            migrationBuilder.RenameColumn(
                name: "TypeTarifid",
                table: "Nature_Marchandises",
                newName: "TypeTarifID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Nature_Marchandises",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Nature_Marchandises_TypeTarifid",
                table: "Nature_Marchandises",
                newName: "IX_Nature_Marchandises_TypeTarifID");

            migrationBuilder.RenameColumn(
                name: "Nature_Marchandiseid",
                table: "Marchandises",
                newName: "Nature_MarchandiseID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Marchandises",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Marchandises_Nature_Marchandiseid",
                table: "Marchandises",
                newName: "IX_Marchandises_Nature_MarchandiseID");

            migrationBuilder.RenameColumn(
                name: "Venteid",
                table: "LTAs",
                newName: "VenteID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LTAs",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_LTAs_Venteid",
                table: "LTAs",
                newName: "IX_LTAs_VenteID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Itineraires",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "VolCargoid",
                table: "Escales",
                newName: "VolCargoID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Escales",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Escales_VolCargoid",
                table: "Escales",
                newName: "IX_Escales_VolCargoID");

            migrationBuilder.RenameColumn(
                name: "Agentid",
                table: "CoutFrets",
                newName: "AgentID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CoutFrets",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CoutFrets_Agentid",
                table: "CoutFrets",
                newName: "IX_CoutFrets_AgentID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Compagnies",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AvionCargos",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Agents",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Compagnieid",
                table: "Aeroports",
                newName: "CompagnieID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Aeroports",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Aeroports_Compagnieid",
                table: "Aeroports",
                newName: "IX_Aeroports_CompagnieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroports_Compagnies_CompagnieID",
                table: "Aeroports",
                column: "CompagnieID",
                principalTable: "Compagnies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoutFrets_Agents_AgentID",
                table: "CoutFrets",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Escales_VolCargos_VolCargoID",
                table: "Escales",
                column: "VolCargoID",
                principalTable: "VolCargos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LTAs_Ventes_VenteID",
                table: "LTAs",
                column: "VenteID",
                principalTable: "Ventes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marchandises_Nature_Marchandises_Nature_MarchandiseID",
                table: "Marchandises",
                column: "Nature_MarchandiseID",
                principalTable: "Nature_Marchandises",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nature_Marchandises_TypeTarifs_TypeTarifID",
                table: "Nature_Marchandises",
                column: "TypeTarifID",
                principalTable: "TypeTarifs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Itineraires_ItineraireID",
                table: "Reservations",
                column: "ItineraireID",
                principalTable: "Itineraires",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Marchandises_MarchandiseID",
                table: "Reservations",
                column: "MarchandiseID",
                principalTable: "Marchandises",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_VolCargos_VolCargoID",
                table: "Reservations",
                column: "VolCargoID",
                principalTable: "VolCargos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Agents_AgentID",
                table: "Ventes",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Reservations_ReservationID",
                table: "Ventes",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolCargos_Aeroports_AeroportID",
                table: "VolCargos",
                column: "AeroportID",
                principalTable: "Aeroports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolCargos_AvionCargos_AvionCargoID",
                table: "VolCargos",
                column: "AvionCargoID",
                principalTable: "AvionCargos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolCargos_Itineraires_ItineraireID",
                table: "VolCargos",
                column: "ItineraireID",
                principalTable: "Itineraires",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

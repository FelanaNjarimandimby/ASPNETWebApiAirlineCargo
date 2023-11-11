using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RéservationApp.Migrations
{
    /// <inheritdoc />
    public partial class client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Reservations",
                newName: "Clientid");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ClientID",
                table: "Reservations",
                newName: "IX_Reservations_Clientid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Clients",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_Clientid",
                table: "Reservations",
                column: "Clientid",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_Clientid",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Clientid",
                table: "Reservations",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_Clientid",
                table: "Reservations",
                newName: "IX_Reservations_ClientID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clients",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientID",
                table: "Reservations",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

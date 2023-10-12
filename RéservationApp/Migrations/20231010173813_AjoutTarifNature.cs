using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RéservationApp.Migrations
{
    /// <inheritdoc />
    public partial class AjoutTarifNature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TarifNatures",
                columns: table => new
                {
                    IDTarifNature = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PoidsTaxable = table.Column<double>(type: "double precision", nullable: false),
                    TypeTarif = table.Column<string>(type: "text", nullable: false),
                    MarchandiseIDMarchandise = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarifNatures", x => x.IDTarifNature);
                    table.ForeignKey(
                        name: "FK_TarifNatures_Marchandises_MarchandiseIDMarchandise",
                        column: x => x.MarchandiseIDMarchandise,
                        principalTable: "Marchandises",
                        principalColumn: "IDMarchandise",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TarifNatures_MarchandiseIDMarchandise",
                table: "TarifNatures",
                column: "MarchandiseIDMarchandise");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarifNatures");
        }
    }
}

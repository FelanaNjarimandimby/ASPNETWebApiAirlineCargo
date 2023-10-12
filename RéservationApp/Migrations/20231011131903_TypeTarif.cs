using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RéservationApp.Migrations
{
    /// <inheritdoc />
    public partial class TypeTarif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TarifNatures_Marchandises_MarchandiseIDMarchandise",
                table: "TarifNatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TarifNatures",
                table: "TarifNatures");

            migrationBuilder.RenameTable(
                name: "TarifNatures",
                newName: "TarifNature");

            migrationBuilder.RenameIndex(
                name: "IX_TarifNatures_MarchandiseIDMarchandise",
                table: "TarifNature",
                newName: "IX_TarifNature_MarchandiseIDMarchandise");

            migrationBuilder.AddColumn<int>(
                name: "TypeTarifIDTypeTarif",
                table: "Nature_Marchandises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarifNature",
                table: "TarifNature",
                column: "IDTarifNature");

            migrationBuilder.CreateTable(
                name: "TypeTarifs",
                columns: table => new
                {
                    IDTypeTarif = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LibelleTarif = table.Column<string>(type: "text", nullable: false),
                    ValeurTarif = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTarifs", x => x.IDTypeTarif);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nature_Marchandises_TypeTarifIDTypeTarif",
                table: "Nature_Marchandises",
                column: "TypeTarifIDTypeTarif");

            migrationBuilder.AddForeignKey(
                name: "FK_Nature_Marchandises_TypeTarifs_TypeTarifIDTypeTarif",
                table: "Nature_Marchandises",
                column: "TypeTarifIDTypeTarif",
                principalTable: "TypeTarifs",
                principalColumn: "IDTypeTarif",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TarifNature_Marchandises_MarchandiseIDMarchandise",
                table: "TarifNature",
                column: "MarchandiseIDMarchandise",
                principalTable: "Marchandises",
                principalColumn: "IDMarchandise",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nature_Marchandises_TypeTarifs_TypeTarifIDTypeTarif",
                table: "Nature_Marchandises");

            migrationBuilder.DropForeignKey(
                name: "FK_TarifNature_Marchandises_MarchandiseIDMarchandise",
                table: "TarifNature");

            migrationBuilder.DropTable(
                name: "TypeTarifs");

            migrationBuilder.DropIndex(
                name: "IX_Nature_Marchandises_TypeTarifIDTypeTarif",
                table: "Nature_Marchandises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TarifNature",
                table: "TarifNature");

            migrationBuilder.DropColumn(
                name: "TypeTarifIDTypeTarif",
                table: "Nature_Marchandises");

            migrationBuilder.RenameTable(
                name: "TarifNature",
                newName: "TarifNatures");

            migrationBuilder.RenameIndex(
                name: "IX_TarifNature_MarchandiseIDMarchandise",
                table: "TarifNatures",
                newName: "IX_TarifNatures_MarchandiseIDMarchandise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarifNatures",
                table: "TarifNatures",
                column: "IDTarifNature");

            migrationBuilder.AddForeignKey(
                name: "FK_TarifNatures_Marchandises_MarchandiseIDMarchandise",
                table: "TarifNatures",
                column: "MarchandiseIDMarchandise",
                principalTable: "Marchandises",
                principalColumn: "IDMarchandise",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

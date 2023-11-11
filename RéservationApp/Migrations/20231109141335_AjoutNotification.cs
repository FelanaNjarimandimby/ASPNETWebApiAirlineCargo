using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RéservationApp.Migrations
{
    /// <inheritdoc />
    public partial class AjoutNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Vue",
                table: "Notifications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vue",
                table: "Notifications");
        }
    }
}

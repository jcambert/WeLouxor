using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace We.Louxor.Migrations
{
    /// <inheritdoc />
    public partial class ligneinventaireaddsociete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "LignesInventaires",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Societe",
                table: "LignesInventaires",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "Societe",
                table: "LignesInventaires");
        }
    }
}

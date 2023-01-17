using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace We.Louxor.Migrations
{
    /// <inheritdoc />
    public partial class AddLigneCommande : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "Of",
                table: "LignesInventaires");

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleDeTete",
                table: "LignesInventaires",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "CodeOperationFinie",
                table: "LignesInventaires",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CoutMachineDirect",
                table: "LignesInventaires",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CoutMatiereDirect",
                table: "LignesInventaires",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroCommandeClient",
                table: "LignesInventaires",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrdreDeFabication",
                table: "LignesInventaires",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LignesDeCommandes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroDocument = table.Column<int>(type: "integer", nullable: false),
                    CodeArticle = table.Column<string>(type: "text", nullable: true),
                    PrixUnitaire = table.Column<double>(type: "double precision", nullable: false),
                    QuantiteCommande = table.Column<double>(type: "double precision", nullable: false),
                    DelaiDemande = table.Column<DateOnly>(type: "date", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesDeCommandes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LignesDeCommandes");

            migrationBuilder.DropColumn(
                name: "ArticleDeTete",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "CodeOperationFinie",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "CoutMachineDirect",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "CoutMatiereDirect",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "NumeroCommandeClient",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "OrdreDeFabication",
                table: "LignesInventaires");

            migrationBuilder.AddColumn<string>(
                name: "Ar",
                table: "LignesInventaires",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Of",
                table: "LignesInventaires",
                type: "text",
                nullable: true);
        }
    }
}

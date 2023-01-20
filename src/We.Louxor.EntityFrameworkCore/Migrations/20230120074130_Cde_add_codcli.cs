using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace We.Louxor.Migrations
{
    /// <inheritdoc />
    public partial class Cdeaddcodcli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoutMatiereDirect",
                table: "LignesInventaires",
                newName: "PvArticleDeTete");

            migrationBuilder.RenameColumn(
                name: "CoutMachineDirect",
                table: "LignesInventaires",
                newName: "PuNomenclature");

            migrationBuilder.AddColumn<string>(
                name: "CodeClient",
                table: "LouxorInv_lignedecommande",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleDeTete",
                table: "LignesInventaires",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "LignesInventaires",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleDeTeteId",
                table: "LignesInventaires",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "LignesInventaires",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "PuGamme",
                table: "LignesInventaires",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeClient",
                table: "LouxorInv_lignedecommande");

            migrationBuilder.DropColumn(
                name: "ArticleDeTeteId",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "LignesInventaires");

            migrationBuilder.DropColumn(
                name: "PuGamme",
                table: "LignesInventaires");

            migrationBuilder.RenameColumn(
                name: "PvArticleDeTete",
                table: "LignesInventaires",
                newName: "CoutMatiereDirect");

            migrationBuilder.RenameColumn(
                name: "PuNomenclature",
                table: "LignesInventaires",
                newName: "CoutMachineDirect");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleDeTete",
                table: "LignesInventaires",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Article",
                table: "LignesInventaires",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}

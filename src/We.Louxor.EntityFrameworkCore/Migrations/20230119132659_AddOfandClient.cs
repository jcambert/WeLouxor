using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace We.Louxor.Migrations
{
    /// <inheritdoc />
    public partial class AddOfandClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LouxorInv_client",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uuid", nullable: false),
                        Code = table.Column<string>(type: "text", nullable: true),
                        Libelle = table.Column<string>(type: "text", nullable: true),
                        Societe = table.Column<string>(type: "text", nullable: true),
                        ExtraProperties = table.Column<string>(type: "text", nullable: true),
                        ConcurrencyStamp = table.Column<string>(
                            type: "character varying(40)",
                            maxLength: 40,
                            nullable: true
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LouxorInv_client", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "LouxorInv_ordredefabication",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uuid", nullable: false),
                        Societe = table.Column<string>(type: "text", nullable: true),
                        Numero = table.Column<int>(type: "integer", nullable: false),
                        CodeOperation = table.Column<int>(type: "integer", nullable: false),
                        NumeroAR = table.Column<int>(type: "integer", nullable: false),
                        CodeClient = table.Column<string>(type: "text", nullable: true),
                        CodeArticle = table.Column<string>(type: "text", nullable: true),
                        Quantite = table.Column<int>(type: "integer", nullable: false),
                        ExtraProperties = table.Column<string>(type: "text", nullable: true),
                        ConcurrencyStamp = table.Column<string>(
                            type: "character varying(40)",
                            maxLength: 40,
                            nullable: true
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LouxorInv_ordredefabication", x => x.Id);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_client_Code",
                table: "LouxorInv_client",
                column: "Code",
                descending: new bool[0]
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_client_Societe",
                table: "LouxorInv_client",
                column: "Societe",
                descending: new bool[0]
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_client_Societe_Code",
                table: "LouxorInv_client",
                columns: new[] { "Societe", "Code" },
                unique: true,
                descending: new bool[0]
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_ordredefabication_CodeArticle",
                table: "LouxorInv_ordredefabication",
                column: "CodeArticle",
                descending: new bool[0]
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_ordredefabication_CodeClient",
                table: "LouxorInv_ordredefabication",
                column: "CodeClient",
                descending: new bool[0]
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_ordredefabication_Numero",
                table: "LouxorInv_ordredefabication",
                column: "Numero",
                descending: new bool[0]
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_ordredefabication_NumeroAR",
                table: "LouxorInv_ordredefabication",
                column: "NumeroAR",
                descending: new bool[0]
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_ordredefabication_Societe",
                table: "LouxorInv_ordredefabication",
                column: "Societe",
                descending: new bool[0]
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_ordredefabication_Societe_Numero",
                table: "LouxorInv_ordredefabication",
                columns: new[] { "Societe", "Numero" },
                unique: true,
                descending: new bool[0]
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "LouxorInv_client");

            migrationBuilder.DropTable(name: "LouxorInv_ordredefabication");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace We.Louxor.Migrations
{
    /// <inheritdoc />
    public partial class Ofupdateindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LouxorInv_ordredefabication_Societe_Numero",
                table: "LouxorInv_ordredefabication"
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_ordredefabication_Societe_Numero_CodeOperation",
                table: "LouxorInv_ordredefabication",
                columns: new[] { "Societe", "Numero", "CodeOperation" },
                unique: true,
                descending: new bool[0]
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LouxorInv_ordredefabication_Societe_Numero_CodeOperation",
                table: "LouxorInv_ordredefabication"
            );

            migrationBuilder.CreateIndex(
                name: "IX_LouxorInv_ordredefabication_Societe_Numero",
                table: "LouxorInv_ordredefabication",
                columns: new[] { "Societe", "Numero" },
                unique: true,
                descending: new bool[0]
            );
        }
    }
}

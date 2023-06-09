using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace We.Louxor.Migrations
{
    /// <inheritdoc />
    public partial class OfQtetodouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantite",
                table: "LouxorInv_ordredefabication",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantite",
                table: "LouxorInv_ordredefabication",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision"
            );
        }
    }
}

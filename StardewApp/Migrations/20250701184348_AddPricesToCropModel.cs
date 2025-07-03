using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StardewApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPricesToCropModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasePrice",
                table: "Crops",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoldPrice",
                table: "Crops",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IridiumPrice",
                table: "Crops",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SilverPrice",
                table: "Crops",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "GoldPrice",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "IridiumPrice",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "SilverPrice",
                table: "Crops");
        }
    }
}

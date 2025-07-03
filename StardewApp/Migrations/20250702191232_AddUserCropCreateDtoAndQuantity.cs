using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StardewApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCropCreateDtoAndQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UserCrops",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UserCrops");
        }
    }
}

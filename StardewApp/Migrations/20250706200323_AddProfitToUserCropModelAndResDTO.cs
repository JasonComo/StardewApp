using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StardewApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProfitToUserCropModelAndResDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Profit",
                table: "UserCrops",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profit",
                table: "UserCrops");
        }
    }
}

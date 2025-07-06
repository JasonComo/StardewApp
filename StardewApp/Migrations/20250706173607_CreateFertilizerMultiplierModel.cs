using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StardewApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateFertilizerMultiplierModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCrops_Settings_SettingId",
                table: "UserCrops");

            migrationBuilder.DropIndex(
                name: "IX_UserCrops_SettingId",
                table: "UserCrops");

            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "UserCrops");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FertilizerMultipliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fertilizer = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Multiplier = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerMultipliers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FertilizerMultipliers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Settings");

            migrationBuilder.AddColumn<int>(
                name: "SettingId",
                table: "UserCrops",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCrops_SettingId",
                table: "UserCrops",
                column: "SettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCrops_Settings_SettingId",
                table: "UserCrops",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id");
        }
    }
}

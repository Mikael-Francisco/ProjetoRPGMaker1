using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class RPGMakerUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "CREATURES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "CHARACTERS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CREATURES_ItemID",
                table: "CREATURES",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CHARACTERS_ItemID",
                table: "CHARACTERS",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CHARACTERS_ITEMS_ItemID",
                table: "CHARACTERS",
                column: "ItemID",
                principalTable: "ITEMS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CREATURES_ITEMS_ItemID",
                table: "CREATURES",
                column: "ItemID",
                principalTable: "ITEMS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHARACTERS_ITEMS_ItemID",
                table: "CHARACTERS");

            migrationBuilder.DropForeignKey(
                name: "FK_CREATURES_ITEMS_ItemID",
                table: "CREATURES");

            migrationBuilder.DropIndex(
                name: "IX_CREATURES_ItemID",
                table: "CREATURES");

            migrationBuilder.DropIndex(
                name: "IX_CHARACTERS_ItemID",
                table: "CHARACTERS");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "CREATURES");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "CHARACTERS");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class RPGMakerInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RPGS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RPGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Permission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLASSES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RPGCreatedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLASSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLASSES_RPGS_RPGCreatedID",
                        column: x => x.RPGCreatedID,
                        principalTable: "RPGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ITEMS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Effect = table.Column<int>(nullable: false),
                    RPGCreatedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ITEMS_RPGS_RPGCreatedID",
                        column: x => x.RPGCreatedID,
                        principalTable: "RPGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RACES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RPGCreatedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RACES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RACES_RPGS_RPGCreatedID",
                        column: x => x.RPGCreatedID,
                        principalTable: "RPGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TERRITORIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RPGCreatedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TERRITORIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TERRITORIES_RPGS_RPGCreatedID",
                        column: x => x.RPGCreatedID,
                        principalTable: "RPGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHARACTERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    RaceID = table.Column<int>(nullable: false),
                    TerritoryID = table.Column<int>(nullable: false),
                    RPGCreatedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHARACTERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CHARACTERS_CLASSES_ClassID",
                        column: x => x.ClassID,
                        principalTable: "CLASSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHARACTERS_RPGS_RPGCreatedID",
                        column: x => x.RPGCreatedID,
                        principalTable: "RPGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHARACTERS_RACES_RaceID",
                        column: x => x.RaceID,
                        principalTable: "RACES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHARACTERS_TERRITORIES_TerritoryID",
                        column: x => x.TerritoryID,
                        principalTable: "TERRITORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CREATURES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    CreatureType = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    RaceID = table.Column<int>(nullable: false),
                    TerritoryID = table.Column<int>(nullable: false),
                    RPGCreatedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREATURES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CREATURES_CLASSES_ClassID",
                        column: x => x.ClassID,
                        principalTable: "CLASSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CREATURES_RPGS_RPGCreatedID",
                        column: x => x.RPGCreatedID,
                        principalTable: "RPGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CREATURES_RACES_RaceID",
                        column: x => x.RaceID,
                        principalTable: "RACES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CREATURES_TERRITORIES_TerritoryID",
                        column: x => x.TerritoryID,
                        principalTable: "TERRITORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHARACTERS_ClassID",
                table: "CHARACTERS",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CHARACTERS_RPGCreatedID",
                table: "CHARACTERS",
                column: "RPGCreatedID");

            migrationBuilder.CreateIndex(
                name: "IX_CHARACTERS_RaceID",
                table: "CHARACTERS",
                column: "RaceID");

            migrationBuilder.CreateIndex(
                name: "IX_CHARACTERS_TerritoryID",
                table: "CHARACTERS",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CLASSES_RPGCreatedID",
                table: "CLASSES",
                column: "RPGCreatedID");

            migrationBuilder.CreateIndex(
                name: "IX_CREATURES_ClassID",
                table: "CREATURES",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CREATURES_RPGCreatedID",
                table: "CREATURES",
                column: "RPGCreatedID");

            migrationBuilder.CreateIndex(
                name: "IX_CREATURES_RaceID",
                table: "CREATURES",
                column: "RaceID");

            migrationBuilder.CreateIndex(
                name: "IX_CREATURES_TerritoryID",
                table: "CREATURES",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS_RPGCreatedID",
                table: "ITEMS",
                column: "RPGCreatedID");

            migrationBuilder.CreateIndex(
                name: "IX_RACES_RPGCreatedID",
                table: "RACES",
                column: "RPGCreatedID");

            migrationBuilder.CreateIndex(
                name: "IX_TERRITORIES_RPGCreatedID",
                table: "TERRITORIES",
                column: "RPGCreatedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHARACTERS");

            migrationBuilder.DropTable(
                name: "CREATURES");

            migrationBuilder.DropTable(
                name: "ITEMS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "CLASSES");

            migrationBuilder.DropTable(
                name: "RACES");

            migrationBuilder.DropTable(
                name: "TERRITORIES");

            migrationBuilder.DropTable(
                name: "RPGS");
        }
    }
}

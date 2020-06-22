using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCentral.Migrations.Olympic
{
    public partial class om : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportName = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportID);
                    table.ForeignKey(
                        name: "FK_Sports_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(nullable: true),
                    GameID = table.Column<int>(nullable: false),
                    SportID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "indoor" },
                    { 2, "outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "GameName" },
                values: new object[,]
                {
                    { 1, "Winter Olympics" },
                    { 2, "Summer Olympics" },
                    { 3, "Paralympics" },
                    { 4, "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportID", "CategoryID", "SportName" },
                values: new object[,]
                {
                    { 1, 1, "Curling" },
                    { 3, 1, "Diving" },
                    { 5, 1, "Archery" },
                    { 7, 1, "Breakdancing" },
                    { 2, 2, "Bobsleigh" },
                    { 4, 2, "Road Cycling" },
                    { 6, 2, "Canoe Sprint" },
                    { 8, 2, "Skateboarding" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryName", "GameID", "SportID" },
                values: new object[,]
                {
                    { 1, "Canada", 1, 1 },
                    { 22, "Finland", 4, 8 },
                    { 18, "Zimbabwe", 3, 6 },
                    { 17, "Pakistan", 3, 6 },
                    { 16, "Austria", 3, 6 },
                    { 12, "USA", 2, 4 },
                    { 11, "Netherlands", 2, 4 },
                    { 10, "Brazil", 2, 4 },
                    { 6, "Japan", 1, 2 },
                    { 5, "Italy", 1, 2 },
                    { 4, "Jamaica", 1, 2 },
                    { 21, "Russia", 4, 7 },
                    { 20, "Cyprus", 4, 7 },
                    { 19, "France", 4, 7 },
                    { 15, "Ukraine", 3, 5 },
                    { 14, "Uruguay", 3, 5 },
                    { 13, "Thailand", 3, 5 },
                    { 9, "Mexico", 2, 3 },
                    { 8, "China", 2, 3 },
                    { 7, "Germany", 2, 3 },
                    { 3, "Great Britain", 1, 1 },
                    { 2, "Sweden", 1, 1 },
                    { 23, "Slovakia", 4, 8 },
                    { 24, "Portugal", 4, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportID",
                table: "Countries",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_CategoryID",
                table: "Sports",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

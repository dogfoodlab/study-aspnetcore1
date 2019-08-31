using Microsoft.EntityFrameworkCore.Migrations;

namespace study_aspnetcore1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AModels",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    A1 = table.Column<string>(nullable: true),
                    A2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BModels",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    B1 = table.Column<string>(nullable: true),
                    B2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BModels", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AModels");

            migrationBuilder.DropTable(
                name: "BModels");
        }
    }
}

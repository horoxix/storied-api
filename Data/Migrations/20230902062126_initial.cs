#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BirthLocation = table.Column<string>(type: "TEXT", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeathLocation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}

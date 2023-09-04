using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class domainentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "BirthLocation",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DeathDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DeathLocation",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "People");

            migrationBuilder.AddColumn<Guid>(
                name: "BirthEventId",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeathEventId",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LocationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("25f66e46-e87f-4a85-a4c1-4ee512907de3"), "Marriage" });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cf7c459c-77b3-43eb-8f08-4e57a37bfa27"), "Birth" });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e3706eeb-aff7-484b-90fb-3b1621dd9d22"), "Death" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0781acf3-9ff7-4508-86ca-07553240130e"), "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("25a9ad5c-623e-4e8a-9ea3-3dffd9c15c21"), "Other" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3e299323-6d9a-4576-88ab-e5efe37073be"), "Female" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("525b3984-4ed3-4fef-af6b-cf8198b1bc0f"), "Transgender" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5608bf07-a2cf-4588-a76e-c9d0057b848e"), "Non-binary" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0c088ee9-1a62-47a8-a309-5679540e2d86"), "San Francisco" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("28fcc8c5-b1e8-4316-a3a1-4da04eebffd3"), "Tokyo" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2df653ac-f256-46d3-89f9-a5917a916efd"), "Provo" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5bf7744e-c13a-446e-9b0d-398a23bdf5ee"), "Orem" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9b158b76-ba87-40b3-8360-b210d0436dfb"), "New York" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cc28c6f5-7f02-4213-b71e-d4e7d741c0b2"), "London" });

            migrationBuilder.CreateIndex(
                name: "IX_People_BirthEventId",
                table: "People",
                column: "BirthEventId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DeathEventId",
                table: "People",
                column: "DeathEventId");

            migrationBuilder.CreateIndex(
                name: "IX_People_GenderId",
                table: "People",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Events_BirthEventId",
                table: "People",
                column: "BirthEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Events_DeathEventId",
                table: "People",
                column: "DeathEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Genders_GenderId",
                table: "People",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Events_BirthEventId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Events_DeathEventId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Genders_GenderId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_People_BirthEventId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DeathEventId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_GenderId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "BirthEventId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DeathEventId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "People");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthLocation",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeathDate",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeathLocation",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

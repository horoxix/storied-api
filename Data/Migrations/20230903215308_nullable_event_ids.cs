using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class nullable_event_ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Events_BirthEventId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Events_DeathEventId",
                table: "People");

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("25f66e46-e87f-4a85-a4c1-4ee512907de3"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("cf7c459c-77b3-43eb-8f08-4e57a37bfa27"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("e3706eeb-aff7-484b-90fb-3b1621dd9d22"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("0781acf3-9ff7-4508-86ca-07553240130e"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("25a9ad5c-623e-4e8a-9ea3-3dffd9c15c21"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("3e299323-6d9a-4576-88ab-e5efe37073be"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("525b3984-4ed3-4fef-af6b-cf8198b1bc0f"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("5608bf07-a2cf-4588-a76e-c9d0057b848e"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("0c088ee9-1a62-47a8-a309-5679540e2d86"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("28fcc8c5-b1e8-4316-a3a1-4da04eebffd3"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("2df653ac-f256-46d3-89f9-a5917a916efd"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("5bf7744e-c13a-446e-9b0d-398a23bdf5ee"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("9b158b76-ba87-40b3-8360-b210d0436dfb"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("cc28c6f5-7f02-4213-b71e-d4e7d741c0b2"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DeathEventId",
                table: "People",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "BirthEventId",
                table: "People",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("60d2da2b-0e59-44ff-a401-6fe440404ab4"), "Death" });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a2b38516-7b1d-4d1b-9ec5-8aabbd18233f"), "Birth" });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e75cfd1a-59f3-461b-9a02-718146571a36"), "Marriage" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0f48d9a9-85ee-42ba-b251-044c1f29ebaa"), "Female" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2e73a543-fad7-4703-a838-dda0a79fb5bd"), "Non-binary" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("56c6c2b9-e619-435e-b899-2d19d03c6def"), "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("586c5311-adf7-4d98-bdae-b1cbd3beee50"), "Other" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cf0a5f5d-2cb6-4741-a15b-ad898aafc9c9"), "Transgender" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("05bbc52c-0067-4d2c-849b-0ee40c192823"), "Tokyo" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4aca1a49-5a43-4e7a-993a-239e5c5c91c3"), "Orem" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6023f999-51db-4ab2-8c2d-724564591ef2"), "Provo" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ae8a5fb0-8ffa-4a50-a43e-f36659801ae4"), "San Francisco" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b59145bb-1ad0-48c8-92bd-5805e195bb57"), "New York" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cf6c3a0e-cbe8-480e-923a-3a7b8944562e"), "London" });

            migrationBuilder.AddForeignKey(
                name: "FK_People_Events_BirthEventId",
                table: "People",
                column: "BirthEventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Events_DeathEventId",
                table: "People",
                column: "DeathEventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Events_BirthEventId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Events_DeathEventId",
                table: "People");

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("60d2da2b-0e59-44ff-a401-6fe440404ab4"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("a2b38516-7b1d-4d1b-9ec5-8aabbd18233f"));

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: new Guid("e75cfd1a-59f3-461b-9a02-718146571a36"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("0f48d9a9-85ee-42ba-b251-044c1f29ebaa"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("2e73a543-fad7-4703-a838-dda0a79fb5bd"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("56c6c2b9-e619-435e-b899-2d19d03c6def"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("586c5311-adf7-4d98-bdae-b1cbd3beee50"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("cf0a5f5d-2cb6-4741-a15b-ad898aafc9c9"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("05bbc52c-0067-4d2c-849b-0ee40c192823"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("4aca1a49-5a43-4e7a-993a-239e5c5c91c3"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("6023f999-51db-4ab2-8c2d-724564591ef2"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("ae8a5fb0-8ffa-4a50-a43e-f36659801ae4"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("b59145bb-1ad0-48c8-92bd-5805e195bb57"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("cf6c3a0e-cbe8-480e-923a-3a7b8944562e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DeathEventId",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BirthEventId",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

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
        }
    }
}

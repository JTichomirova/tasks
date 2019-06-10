using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_web.Migrations
{
    public partial class Task_webDALMyContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("be1e02e5-c019-4d2c-aad5-5ce6add4a35a"), "Bob" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("279f9216-b881-4e1c-a9b7-082d95818757"), "David" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatTest.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    AccessCode = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Zone = table.Column<string>(nullable: true),
                    SignalDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signals");
        }
    }
}

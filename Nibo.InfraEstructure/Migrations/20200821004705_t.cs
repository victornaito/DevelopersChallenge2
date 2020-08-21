using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nibo.InfraEstructure.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conciliation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<int>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    TransactionAmount = table.Column<double>(nullable: false),
                    TransactionDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conciliation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conciliation");
        }
    }
}

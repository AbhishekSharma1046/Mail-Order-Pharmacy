using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RefillApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbRefillOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefillDate = table.Column<DateTime>(nullable: false),
                    DrugQuantity = table.Column<int>(nullable: false),
                    RefillDelivered = table.Column<bool>(nullable: false),
                    Payment = table.Column<bool>(nullable: false),
                    SubscriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbRefillOrder", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbRefillOrder");
        }
    }
}

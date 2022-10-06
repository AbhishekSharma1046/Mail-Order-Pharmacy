using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbPrescriptionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsurancePolicyNumber = table.Column<int>(nullable: false),
                    InsuranceProvider = table.Column<string>(nullable: true),
                    PrescriptionDate = table.Column<DateTime>(nullable: false),
                    DrugName = table.Column<string>(nullable: false),
                    DoctorName = table.Column<string>(nullable: true),
                    RefillOccurrence = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPrescriptionDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbPrescriptionDetails");
        }
    }
}

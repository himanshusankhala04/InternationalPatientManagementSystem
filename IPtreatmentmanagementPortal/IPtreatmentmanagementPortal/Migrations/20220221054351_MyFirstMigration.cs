using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPtreatmentmanagementPortal.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreatmentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ailment = table.Column<int>(type: "int", nullable: false),
                    TreatmentPackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentComencementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BalanceAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentStatuses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentStatuses");
        }
    }
}

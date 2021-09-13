using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSys.DAL.Migrations.EmployeeManagementDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeAdvn",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAdvn", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmpFamilyDetAdvn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    MemberName = table.Column<string>(nullable: true),
                    MemberRelation = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFamilyDetAdvn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpFamilyDetAdvn_EmployeeAdvn_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeAdvn",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFamilyDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    MemberName = table.Column<string>(nullable: true),
                    MemberRelation = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFamilyDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeFamilyDetails_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyDetAdvn_EmployeeId",
                table: "EmpFamilyDetAdvn",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFamilyDetails_EmployeeId",
                table: "EmployeeFamilyDetails",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpFamilyDetAdvn");

            migrationBuilder.DropTable(
                name: "EmployeeFamilyDetails");

            migrationBuilder.DropTable(
                name: "EmployeeAdvn");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}

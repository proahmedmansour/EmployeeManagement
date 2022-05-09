using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace InterviewTask.EmployeeManagement.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal (15,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT_Solutions Ltd" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedTime", "Name", "Salary" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2022, 3, 30, 0, 57, 17, 21, DateTimeKind.Local).AddTicks(1352), "Ahmed Mansour", 10000m },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2022, 3, 30, 0, 57, 17, 21, DateTimeKind.Local).AddTicks(2034), "Mohamed Taha", 15000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

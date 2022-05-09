using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewTask.EmployeeManagement.Migrations
{
    public partial class Add_Relationships_Department_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "CreatedTime",
                value: new DateTime(2022, 3, 31, 13, 51, 44, 538, DateTimeKind.Local).AddTicks(3176));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "CreatedTime",
                value: new DateTime(2022, 3, 31, 13, 51, 44, 538, DateTimeKind.Local).AddTicks(2522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Departments");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "CreatedTime",
                value: new DateTime(2022, 3, 31, 13, 21, 46, 913, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "CreatedTime",
                value: new DateTime(2022, 3, 31, 13, 21, 46, 912, DateTimeKind.Local).AddTicks(9733));
        }
    }
}

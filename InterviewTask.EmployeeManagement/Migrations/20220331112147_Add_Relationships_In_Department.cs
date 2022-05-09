using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewTask.EmployeeManagement.Migrations
{
    public partial class Add_Relationships_In_Department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "CreatedTime",
                value: new DateTime(2022, 3, 31, 12, 43, 25, 267, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "CreatedTime",
                value: new DateTime(2022, 3, 31, 12, 43, 25, 267, DateTimeKind.Local).AddTicks(7360));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace InterviewTask.EmployeeManagement.Migrations
{
    public partial class Add_Relationships_In_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "CreatedTime",
                value: new DateTime(2022, 3, 30, 0, 57, 17, 21, DateTimeKind.Local).AddTicks(2034));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "CreatedTime",
                value: new DateTime(2022, 3, 30, 0, 57, 17, 21, DateTimeKind.Local).AddTicks(1352));
        }
    }
}

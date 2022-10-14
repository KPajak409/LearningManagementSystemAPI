using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class courseupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("568977a1-c784-4c54-acd4-b972e3a7678d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("beae8da9-a911-4ad0-9413-b82038bca0a4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe4a9d2f-e868-440a-9c30-29409cdfc367"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("6640c62b-d8c3-4cf7-aced-55e01875ca15"), "student@test.local", "studenttest", "studenttest", "", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("82090fcb-4639-4e6e-9ce1-bce8f4b462f5"), "teacher@test.local", "teachertest", "teachertest", "", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("a654749a-1b80-4e15-8972-62b0598f48a4"), "admin@test.local", "admintest", "admintest", "", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6640c62b-d8c3-4cf7-aced-55e01875ca15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("82090fcb-4639-4e6e-9ce1-bce8f4b462f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a654749a-1b80-4e15-8972-62b0598f48a4"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("568977a1-c784-4c54-acd4-b972e3a7678d"), "teacher@test.local", "teachertest", "teachertest", "", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("beae8da9-a911-4ad0-9413-b82038bca0a4"), "admin@test.local", "admintest", "admintest", "", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("fe4a9d2f-e868-440a-9c30-29409cdfc367"), "student@test.local", "studenttest", "studenttest", "", 3 });
        }
    }
}

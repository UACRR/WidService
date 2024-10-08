using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WidAdminLib.Migrations
{
    public partial class NewTasksAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WidConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 16, 20, 5, 23, 691, DateTimeKind.Local).AddTicks(8829), new DateTime(2023, 1, 16, 20, 5, 23, 693, DateTimeKind.Local).AddTicks(5171) });

            migrationBuilder.InsertData(
                table: "WidTaskTypes",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 10, "RenSocWidToSocWid_", "Змінити назву SocWid на SocWid_" },
                    { 11, "RenSocWidInitialToSocWid", "Змінити назву SocWidInitial на SocWid" },
                    { 12, "RenSocWid_ToSocWidInitial", "Змінити назву SocWid_ на SocWidInitial" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WidTaskTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WidTaskTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WidTaskTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "WidConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 15, 23, 17, 58, 526, DateTimeKind.Local).AddTicks(3343), new DateTime(2022, 9, 15, 23, 17, 58, 528, DateTimeKind.Local).AddTicks(3529) });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyrightObjectSearch.Server.Migrations
{
    /// <inheritdoc />
    public partial class SourceTypeTextCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Реклама");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Підписка звичайна");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Підписка преміальна");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Попереднє прослуховування");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Реклама");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Підписка");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Прослуховування музики");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Прослуховування музики");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Звіт про прибуток за рекламу");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Звіт про прибуток за підписку");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Звіт про прибуток за преміальну підписку");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Попередній звіт");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Звіт про прибуток за рекламу");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Звіт про прибуток за підписку");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Всі звіти");

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Звіт від радіо");
        }
    }
}

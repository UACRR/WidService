using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyrightObjectSearch.Server.Migrations
{
    /// <inheritdoc />
    public partial class PartnerToSourceType1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartnerToSourceTypePartnerId",
                table: "PartnerWorkSourceTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartnerToSourceTypeSourceTypeId",
                table: "PartnerWorkSourceTypes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PartnerWorkSourceTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorkSourceTypes_PartnerToSourceTypePartnerId_PartnerToSourceTypeSourceTypeId",
                table: "PartnerWorkSourceTypes",
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerWorkSourceTypes_PartnerToSourceType_PartnerToSourceTypePartnerId_PartnerToSourceTypeSourceTypeId",
                table: "PartnerWorkSourceTypes",
                columns: new[] { "PartnerToSourceTypePartnerId", "PartnerToSourceTypeSourceTypeId" },
                principalTable: "PartnerToSourceType",
                principalColumns: new[] { "PartnerId", "SourceTypeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerWorkSourceTypes_PartnerToSourceType_PartnerToSourceTypePartnerId_PartnerToSourceTypeSourceTypeId",
                table: "PartnerWorkSourceTypes");

            migrationBuilder.DropIndex(
                name: "IX_PartnerWorkSourceTypes_PartnerToSourceTypePartnerId_PartnerToSourceTypeSourceTypeId",
                table: "PartnerWorkSourceTypes");

            migrationBuilder.DropColumn(
                name: "PartnerToSourceTypePartnerId",
                table: "PartnerWorkSourceTypes");

            migrationBuilder.DropColumn(
                name: "PartnerToSourceTypeSourceTypeId",
                table: "PartnerWorkSourceTypes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CopyrightObjectSearch.Server.Migrations
{
    /// <inheritdoc />
    public partial class PartnerToSourceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Partners",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Partners",
                type: "varchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.CreateTable(
                name: "PartnerToSourceType",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    SourceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerToSourceType", x => new { x.PartnerId, x.SourceTypeId });
                    table.ForeignKey(
                        name: "FK_PartnerToSourceType_PartnerWorkSourceTypes_SourceTypeId",
                        column: x => x.SourceTypeId,
                        principalTable: "PartnerWorkSourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerToSourceType_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PartnerToSourceType",
                columns: new[] { "PartnerId", "SourceTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 4, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerToSourceType_SourceTypeId",
                table: "PartnerToSourceType",
                column: "SourceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerToSourceType");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Partners",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Partners",
                type: "varchar(32)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldNullable: true);
        }
    }
}

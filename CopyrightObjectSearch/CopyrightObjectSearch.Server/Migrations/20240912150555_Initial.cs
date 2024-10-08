using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyrightObjectSearch.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Performers = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Iswc = table.Column<string>(type: "varchar(13)", nullable: false),
                    FoundObjId = table.Column<int>(type: "int", nullable: false),
                    FoundWic = table.Column<int>(type: "int", nullable: false),
                    FoundIswc = table.Column<string>(type: "varchar(13)", nullable: false),
                    FoundVia = table.Column<string>(type: "varchar(8)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalObjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalObjects_Title",
                table: "ExternalObjects",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalObjects_Title_Authors_Performers_Iswc",
                table: "ExternalObjects",
                columns: new[] { "Title", "Authors", "Performers", "Iswc" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalObjects");
        }
    }
}

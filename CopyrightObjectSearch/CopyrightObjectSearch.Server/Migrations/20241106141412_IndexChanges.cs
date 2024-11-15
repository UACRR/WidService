using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyrightObjectSearch.Server.Migrations
{
    /// <inheritdoc />
    public partial class IndexChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartnerWorks_AlbumId",
                table: "PartnerWorks");

            migrationBuilder.DropIndex(
                name: "IX_PartnerWorks_NameId_AuthorsId_PerformersId_IswcId",
                table: "PartnerWorks");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_AlbumId_NameId_AuthorsId_PerformersId_IswcId",
                table: "PartnerWorks",
                columns: new[] { "AlbumId", "NameId", "AuthorsId", "PerformersId", "IswcId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartnerWorks_AlbumId_NameId_AuthorsId_PerformersId_IswcId",
                table: "PartnerWorks");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_AlbumId",
                table: "PartnerWorks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_NameId_AuthorsId_PerformersId_IswcId",
                table: "PartnerWorks",
                columns: new[] { "NameId", "AuthorsId", "PerformersId", "IswcId" },
                unique: true);
        }
    }
}

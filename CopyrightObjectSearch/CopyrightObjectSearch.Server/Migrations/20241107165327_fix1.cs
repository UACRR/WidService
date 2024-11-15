using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyrightObjectSearch.Server.Migrations
{
    /// <inheritdoc />
    public partial class fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerWorkToSources_PartnerWorks_ParnterWorkId",
                table: "PartnerWorkToSources");

            migrationBuilder.RenameColumn(
                name: "ParnterWorkId",
                table: "PartnerWorkToSources",
                newName: "PartnerWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_PartnerWorkToSources_ParnterWorkId",
                table: "PartnerWorkToSources",
                newName: "IX_PartnerWorkToSources_PartnerWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerWorkToSources_PartnerWorks_PartnerWorkId",
                table: "PartnerWorkToSources",
                column: "PartnerWorkId",
                principalTable: "PartnerWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerWorkToSources_PartnerWorks_PartnerWorkId",
                table: "PartnerWorkToSources");

            migrationBuilder.RenameColumn(
                name: "PartnerWorkId",
                table: "PartnerWorkToSources",
                newName: "ParnterWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_PartnerWorkToSources_PartnerWorkId",
                table: "PartnerWorkToSources",
                newName: "IX_PartnerWorkToSources_ParnterWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerWorkToSources_PartnerWorks_ParnterWorkId",
                table: "PartnerWorkToSources",
                column: "ParnterWorkId",
                principalTable: "PartnerWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

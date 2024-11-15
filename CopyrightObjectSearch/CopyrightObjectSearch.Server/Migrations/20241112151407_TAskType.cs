using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyrightObjectSearch.Server.Migrations
{
    /// <inheritdoc />
    public partial class TAskType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTaskType",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[] { 3, "SearchRightHolderWork", "Пошук творів правовласників" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTaskType",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

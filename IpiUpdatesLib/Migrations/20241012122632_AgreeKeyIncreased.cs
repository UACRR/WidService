using Microsoft.EntityFrameworkCore.Migrations;

namespace IpiUpdatesLib.Migrations
{
    public partial class AgreeKeyIncreased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAgreeNr",
                table: "IpiTerritory",
                type: "varchar(41)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(26)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IpAgreeNr",
                table: "IpiAgreement",
                type: "varchar(41)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(26)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAgreeNr",
                table: "IpiTerritory",
                type: "varchar(26)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(41)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IpAgreeNr",
                table: "IpiAgreement",
                type: "varchar(26)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(41)",
                oldNullable: true);
        }
    }
}

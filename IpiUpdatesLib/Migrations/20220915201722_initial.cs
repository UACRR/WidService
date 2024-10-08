using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IpiUpdatesLib.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IpiAgreement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAgreeNr = table.Column<string>(type: "varchar(26)", nullable: true),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RgtCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    FromDt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SignD = table.Column<DateTime>(type: "date", nullable: false),
                    Shr = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AmdDt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiAgreement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true),
                    IpType = table.Column<string>(type: "varchar(1)", nullable: true),
                    BirthD = table.Column<DateTime>(type: "date", nullable: false),
                    DeathD = table.Column<DateTime>(type: "date", nullable: false),
                    BirthPlace = table.Column<string>(type: "varchar(30)", nullable: true),
                    BirthState = table.Column<string>(type: "varchar(30)", nullable: true),
                    BirthTisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrFromD = table.Column<DateTime>(type: "date", nullable: false),
                    BirthTisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromD = table.Column<DateTime>(type: "date", nullable: false),
                    Sex = table.Column<string>(type: "varchar(1)", nullable: true),
                    AmdDt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpNameNr = table.Column<int>(type: "int", nullable: false),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true),
                    IpNameNrRef = table.Column<int>(type: "int", nullable: true),
                    IpBaseNrRef = table.Column<string>(type: "varchar(13)", nullable: true),
                    Name = table.Column<string>(type: "varchar(90)", nullable: true),
                    FstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreDt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AmdDt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiNameUsage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpNameNr = table.Column<int>(type: "int", nullable: false),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiNameUsage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiNationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrFromD = table.Column<DateTime>(type: "date", nullable: false),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromD = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiNationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiRemark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    Txt = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiRemark", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true),
                    IpBaseNrRef = table.Column<string>(type: "varchar(13)", nullable: true),
                    SttCde = table.Column<string>(type: "varchar(1)", nullable: true),
                    FromDt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AmdDt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiTerritory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAgreeNr = table.Column<string>(type: "varchar(26)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrFromD = table.Column<DateTime>(type: "date", nullable: false),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromD = table.Column<DateTime>(type: "date", nullable: false),
                    IncExcInd = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiTerritory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpdFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(32)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DicCcl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    Cde = table.Column<string>(type: "varchar(2)", nullable: true),
                    Dsc = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicCcl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicCcl_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicCsc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreSubClsCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicCsc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicCsc_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicHna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    TisNrPa = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrPaFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNrPaToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanPa = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanPaFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanPaToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisaPa = table.Column<string>(type: "varchar(6)", nullable: true),
                    TisNrCh = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrChFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNrChToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanCh = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanChFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanChToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisaCh = table.Column<string>(type: "varchar(6)", nullable: true),
                    FromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicHna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicHna_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicHnr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    TisNrPa = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrPaFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNrPaToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanPa = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanPaFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanPaToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisaPa = table.Column<string>(type: "varchar(6)", nullable: true),
                    TisNrCh = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrChFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNrChToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanCh = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanChFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanChToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisaCh = table.Column<string>(type: "varchar(6)", nullable: true),
                    FromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicHnr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicHnr_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicIri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    Cde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RgtCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicIri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicIri_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicIsc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    Cde = table.Column<string>(type: "varchar(1)", nullable: true),
                    Dsc = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicIsc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicIsc_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicNmt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    Cde = table.Column<string>(type: "varchar(2)", nullable: true),
                    Dsc = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicNmt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicNmt_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicRcc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicRcc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicRcc_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicRig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    Cde = table.Column<string>(type: "varchar(2)", nullable: true),
                    Dsc = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicRig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicRig_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicRis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RgtCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicRis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicRis_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicRix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RgtCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    FromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ToD = table.Column<string>(type: "varchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicRix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicRix_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    Cde = table.Column<string>(type: "varchar(2)", nullable: true),
                    Dsc = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicRol_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicSoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    Cde = table.Column<string>(type: "varchar(3)", nullable: true),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    Country = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicSoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicSoc_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicSop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    PartnerSocCde = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicSop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicSop_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicTna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNrToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    Tisa = table.Column<string>(type: "varchar(6)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTna_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicTnr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNrToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisanToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    Tisa = table.Column<string>(type: "varchar(6)", nullable: true),
                    LngCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicTnr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DicTnr_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecBdn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpType = table.Column<string>(type: "varchar(1)", nullable: true),
                    BirthYy = table.Column<string>(type: "varchar(4)", nullable: true),
                    BirthMm = table.Column<string>(type: "varchar(2)", nullable: true),
                    BirthDd = table.Column<string>(type: "varchar(2)", nullable: true),
                    DeathYy = table.Column<string>(type: "varchar(4)", nullable: true),
                    DeathMm = table.Column<string>(type: "varchar(2)", nullable: true),
                    DeathDd = table.Column<string>(type: "varchar(2)", nullable: true),
                    BirthPlace = table.Column<string>(type: "varchar(30)", nullable: true),
                    BirthState = table.Column<string>(type: "varchar(30)", nullable: true),
                    BirthTisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    BirthTisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    Sex = table.Column<string>(type: "varchar(1)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecBdn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecBdn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecBdo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpType = table.Column<string>(type: "varchar(1)", nullable: true),
                    BirthD = table.Column<string>(type: "varchar(8)", nullable: true),
                    DeathD = table.Column<string>(type: "varchar(8)", nullable: true),
                    BirthPlace = table.Column<string>(type: "varchar(30)", nullable: true),
                    BirthState = table.Column<string>(type: "varchar(30)", nullable: true),
                    BirthTisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    BirthTisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    Sex = table.Column<string>(type: "varchar(1)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecBdo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecBdo_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecGrh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransType = table.Column<string>(type: "varchar(3)", nullable: true),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    VerNr = table.Column<string>(type: "varchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecGrh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecGrh_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecGrt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    TransCnt = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecCnt = table.Column<string>(type: "varchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecGrt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecGrt_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecHdr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    SenderType = table.Column<string>(type: "varchar(2)", nullable: true),
                    SenderId = table.Column<string>(type: "varchar(9)", nullable: true),
                    SenderName = table.Column<string>(type: "varchar(45)", nullable: true),
                    StdVerNr = table.Column<string>(type: "varchar(5)", nullable: true),
                    CreD = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreT = table.Column<string>(type: "varchar(6)", nullable: true),
                    TransmitD = table.Column<string>(type: "varchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecHdr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecHdr_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecImn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecImn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecImn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecImo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecImo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecImo_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecInn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecInn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecInn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecIno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecIno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecIno_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecMan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RgtCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    ValidFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidFromT = table.Column<string>(type: "varchar(6)", nullable: true),
                    ValidToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidToT = table.Column<string>(type: "varchar(6)", nullable: true),
                    SignD = table.Column<string>(type: "varchar(8)", nullable: true),
                    Shr = table.Column<string>(type: "varchar(5)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecMan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecMan_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecMao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RgtCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    ValidFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidFromT = table.Column<string>(type: "varchar(6)", nullable: true),
                    ValidToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidToT = table.Column<string>(type: "varchar(6)", nullable: true),
                    SignD = table.Column<string>(type: "varchar(8)", nullable: true),
                    Shr = table.Column<string>(type: "varchar(5)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecMao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecMao_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecMcn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    Name = table.Column<string>(type: "varchar(90)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreD = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreT = table.Column<string>(type: "varchar(6)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecMcn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecMcn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecMco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    Name = table.Column<string>(type: "varchar(90)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreD = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreT = table.Column<string>(type: "varchar(6)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecMco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecMco_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecMun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    IpBaseNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecMun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecMun_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecMuo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    IpBaseNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecMuo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecMuo_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecNcn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    Name = table.Column<string>(type: "varchar(90)", nullable: true),
                    FstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreD = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreT = table.Column<string>(type: "varchar(6)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecNcn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecNcn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecNco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    Name = table.Column<string>(type: "varchar(90)", nullable: true),
                    FstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreD = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreT = table.Column<string>(type: "varchar(6)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecNco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecNco_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecNtn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidToD = table.Column<string>(type: "varchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecNtn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecNtn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecNto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidToD = table.Column<string>(type: "varchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecNto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecNto_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecNun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecNun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecNun_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecNuo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreClsCde = table.Column<string>(type: "varchar(2)", nullable: true),
                    RolCde = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecNuo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecNuo_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecOnn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    Name = table.Column<string>(type: "varchar(90)", nullable: true),
                    FstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreD = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreT = table.Column<string>(type: "varchar(6)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true),
                    IpNameNrRef = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecOnn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecOnn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecOno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    Name = table.Column<string>(type: "varchar(90)", nullable: true),
                    FstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreD = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreT = table.Column<string>(type: "varchar(6)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true),
                    IpNameNrRef = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecOno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecOno_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecRen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    SeqNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    Txt = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecRen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecRen_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecReo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    SeqNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    Txt = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecReo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecReo_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecStn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpBaseNrRef = table.Column<string>(type: "varchar(13)", nullable: true),
                    SttCde = table.Column<string>(type: "varchar(1)", nullable: true),
                    ValidFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidFromT = table.Column<string>(type: "varchar(6)", nullable: true),
                    ValidToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidToT = table.Column<string>(type: "varchar(6)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecStn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecStn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecSto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IpBaseNrRef = table.Column<string>(type: "varchar(13)", nullable: true),
                    SttCde = table.Column<string>(type: "varchar(1)", nullable: true),
                    ValidFromD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidFromT = table.Column<string>(type: "varchar(6)", nullable: true),
                    ValidToD = table.Column<string>(type: "varchar(8)", nullable: true),
                    ValidToT = table.Column<string>(type: "varchar(6)", nullable: true),
                    AmdD = table.Column<string>(type: "varchar(8)", nullable: true),
                    AmdT = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecSto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecSto_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecTma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanValidFrom = table.Column<string>(type: "varchar(8)", nullable: true),
                    IncExcInd = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecTma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecTma_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpdTrans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    GrId = table.Column<string>(type: "varchar(5)", nullable: true),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    TransD = table.Column<string>(type: "varchar(8)", nullable: true),
                    TransT = table.Column<string>(type: "varchar(6)", nullable: true),
                    RemitSocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    RemitSocName = table.Column<string>(type: "varchar(20)", nullable: true),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: true),
                    SttCde = table.Column<string>(type: "varchar(1)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: true),
                    IpBaseNrRef = table.Column<string>(type: "varchar(13)", nullable: true),
                    SttCdeRef = table.Column<string>(type: "varchar(1)", nullable: true),
                    IpNameNrRef = table.Column<string>(type: "varchar(11)", nullable: true),
                    NameTypeRef = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdTrans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpdTrans_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DicCcl_UpdFileId",
                table: "DicCcl",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicCsc_UpdFileId",
                table: "DicCsc",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicHna_UpdFileId",
                table: "DicHna",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicHnr_UpdFileId",
                table: "DicHnr",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicIri_UpdFileId",
                table: "DicIri",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicIsc_UpdFileId",
                table: "DicIsc",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicNmt_UpdFileId",
                table: "DicNmt",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicRcc_UpdFileId",
                table: "DicRcc",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicRig_UpdFileId",
                table: "DicRig",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicRis_UpdFileId",
                table: "DicRis",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicRix_UpdFileId",
                table: "DicRix",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicRol_UpdFileId",
                table: "DicRol",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicSoc_UpdFileId",
                table: "DicSoc",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicSop_UpdFileId",
                table: "DicSop",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTna_UpdFileId",
                table: "DicTna",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DicTnr_UpdFileId",
                table: "DicTnr",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecBdn_UpdFileId",
                table: "RecBdn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecBdo_UpdFileId",
                table: "RecBdo",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecGrh_UpdFileId",
                table: "RecGrh",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecGrt_UpdFileId",
                table: "RecGrt",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecHdr_UpdFileId",
                table: "RecHdr",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecImn_UpdFileId",
                table: "RecImn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecImo_UpdFileId",
                table: "RecImo",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecInn_UpdFileId",
                table: "RecInn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecIno_UpdFileId",
                table: "RecIno",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecMan_UpdFileId",
                table: "RecMan",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecMao_UpdFileId",
                table: "RecMao",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecMcn_UpdFileId",
                table: "RecMcn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecMco_UpdFileId",
                table: "RecMco",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecMun_UpdFileId",
                table: "RecMun",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecMuo_UpdFileId",
                table: "RecMuo",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecNcn_UpdFileId",
                table: "RecNcn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecNco_UpdFileId",
                table: "RecNco",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecNtn_UpdFileId",
                table: "RecNtn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecNto_UpdFileId",
                table: "RecNto",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecNun_UpdFileId",
                table: "RecNun",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecNuo_UpdFileId",
                table: "RecNuo",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecOnn_UpdFileId",
                table: "RecOnn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecOno_UpdFileId",
                table: "RecOno",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecRen_UpdFileId",
                table: "RecRen",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecReo_UpdFileId",
                table: "RecReo",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecStn_UpdFileId",
                table: "RecStn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecSto_UpdFileId",
                table: "RecSto",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecTma_UpdFileId",
                table: "RecTma",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdTrans_UpdFileId",
                table: "UpdTrans",
                column: "UpdFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DicCcl");

            migrationBuilder.DropTable(
                name: "DicCsc");

            migrationBuilder.DropTable(
                name: "DicHna");

            migrationBuilder.DropTable(
                name: "DicHnr");

            migrationBuilder.DropTable(
                name: "DicIri");

            migrationBuilder.DropTable(
                name: "DicIsc");

            migrationBuilder.DropTable(
                name: "DicNmt");

            migrationBuilder.DropTable(
                name: "DicRcc");

            migrationBuilder.DropTable(
                name: "DicRig");

            migrationBuilder.DropTable(
                name: "DicRis");

            migrationBuilder.DropTable(
                name: "DicRix");

            migrationBuilder.DropTable(
                name: "DicRol");

            migrationBuilder.DropTable(
                name: "DicSoc");

            migrationBuilder.DropTable(
                name: "DicSop");

            migrationBuilder.DropTable(
                name: "DicTna");

            migrationBuilder.DropTable(
                name: "DicTnr");

            migrationBuilder.DropTable(
                name: "IpiAgreement");

            migrationBuilder.DropTable(
                name: "IpiBase");

            migrationBuilder.DropTable(
                name: "IpiName");

            migrationBuilder.DropTable(
                name: "IpiNameUsage");

            migrationBuilder.DropTable(
                name: "IpiNationality");

            migrationBuilder.DropTable(
                name: "IpiRemark");

            migrationBuilder.DropTable(
                name: "IpiStatus");

            migrationBuilder.DropTable(
                name: "IpiTerritory");

            migrationBuilder.DropTable(
                name: "RecBdn");

            migrationBuilder.DropTable(
                name: "RecBdo");

            migrationBuilder.DropTable(
                name: "RecGrh");

            migrationBuilder.DropTable(
                name: "RecGrt");

            migrationBuilder.DropTable(
                name: "RecHdr");

            migrationBuilder.DropTable(
                name: "RecImn");

            migrationBuilder.DropTable(
                name: "RecImo");

            migrationBuilder.DropTable(
                name: "RecInn");

            migrationBuilder.DropTable(
                name: "RecIno");

            migrationBuilder.DropTable(
                name: "RecMan");

            migrationBuilder.DropTable(
                name: "RecMao");

            migrationBuilder.DropTable(
                name: "RecMcn");

            migrationBuilder.DropTable(
                name: "RecMco");

            migrationBuilder.DropTable(
                name: "RecMun");

            migrationBuilder.DropTable(
                name: "RecMuo");

            migrationBuilder.DropTable(
                name: "RecNcn");

            migrationBuilder.DropTable(
                name: "RecNco");

            migrationBuilder.DropTable(
                name: "RecNtn");

            migrationBuilder.DropTable(
                name: "RecNto");

            migrationBuilder.DropTable(
                name: "RecNun");

            migrationBuilder.DropTable(
                name: "RecNuo");

            migrationBuilder.DropTable(
                name: "RecOnn");

            migrationBuilder.DropTable(
                name: "RecOno");

            migrationBuilder.DropTable(
                name: "RecRen");

            migrationBuilder.DropTable(
                name: "RecReo");

            migrationBuilder.DropTable(
                name: "RecStn");

            migrationBuilder.DropTable(
                name: "RecSto");

            migrationBuilder.DropTable(
                name: "RecTma");

            migrationBuilder.DropTable(
                name: "UpdTrans");

            migrationBuilder.DropTable(
                name: "UpdFiles");
        }
    }
}

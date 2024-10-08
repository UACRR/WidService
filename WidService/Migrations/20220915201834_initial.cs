using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WidServiceLib.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IpiBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    IpType = table.Column<string>(type: "varchar(1)", nullable: false),
                    BirthYy = table.Column<string>(type: "varchar(4)", nullable: true),
                    BirthMm = table.Column<string>(type: "varchar(2)", nullable: true),
                    BirthDd = table.Column<string>(type: "varchar(2)", nullable: true),
                    DeathYy = table.Column<string>(type: "varchar(4)", nullable: true),
                    DeathMm = table.Column<string>(type: "varchar(2)", nullable: true),
                    DeathDd = table.Column<string>(type: "varchar(2)", nullable: true),
                    BirthPlace = table.Column<string>(type: "varchar(30)", nullable: true),
                    BirthState = table.Column<string>(type: "varchar(30)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrFromTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: true),
                    AmdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiBaseHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    IpType = table.Column<string>(type: "varchar(1)", nullable: false),
                    BirthYy = table.Column<string>(type: "varchar(4)", nullable: true),
                    BirthMm = table.Column<string>(type: "varchar(2)", nullable: true),
                    BirthDd = table.Column<string>(type: "varchar(2)", nullable: true),
                    DeathYy = table.Column<string>(type: "varchar(4)", nullable: true),
                    DeathMm = table.Column<string>(type: "varchar(2)", nullable: true),
                    DeathDd = table.Column<string>(type: "varchar(2)", nullable: true),
                    BirthPlace = table.Column<string>(type: "varchar(30)", nullable: true),
                    BirthState = table.Column<string>(type: "varchar(30)", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: true),
                    TisNrFromTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: true),
                    AmdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiBaseHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "IpiMbrAgreeTerr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    SocId = table.Column<string>(type: "varchar(3)", nullable: false),
                    CreClass = table.Column<string>(type: "varchar(2)", nullable: false),
                    Rol = table.Column<string>(type: "varchar(2)", nullable: false),
                    Rgt = table.Column<string>(type: "varchar(2)", nullable: false),
                    FromTs = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToTs = table.Column<DateTime>(type: "datetime", nullable: false),
                    Shr = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AmdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: false),
                    TisNrFromTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    IncExc = table.Column<string>(type: "varchar(1)", nullable: false),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiMbrAgreeTerr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiMbrAgreeTerrHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    SocId = table.Column<string>(type: "varchar(3)", nullable: false),
                    CreClass = table.Column<string>(type: "varchar(2)", nullable: false),
                    Rol = table.Column<string>(type: "varchar(2)", nullable: false),
                    Rgt = table.Column<string>(type: "varchar(2)", nullable: false),
                    FromTs = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToTs = table.Column<DateTime>(type: "datetime", nullable: false),
                    Shr = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AmdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    TisNr = table.Column<string>(type: "varchar(4)", nullable: false),
                    TisNrFromTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tisan = table.Column<string>(type: "varchar(20)", nullable: true),
                    TisanFromTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    IncExc = table.Column<string>(type: "varchar(1)", nullable: false),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiMbrAgreeTerrHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "IpiName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: false),
                    FstName = table.Column<string>(type: "varchar(90)", nullable: false),
                    LstName = table.Column<string>(type: "varchar(90)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: false),
                    AmdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    NameCrea = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiNameHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: false),
                    FstName = table.Column<string>(type: "varchar(90)", nullable: false),
                    LstName = table.Column<string>(type: "varchar(90)", nullable: true),
                    NameType = table.Column<string>(type: "varchar(2)", nullable: false),
                    AmdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    NameCrea = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiNameHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "IpiStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    RelIpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    StsCde = table.Column<string>(type: "varchar(1)", nullable: false),
                    FromTs = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToTs = table.Column<DateTime>(type: "datetime", nullable: false),
                    AmdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpiStatusHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    IpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    RelIpBaseNr = table.Column<string>(type: "varchar(13)", nullable: false),
                    StsCde = table.Column<string>(type: "varchar(1)", nullable: false),
                    FromTs = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToTs = table.Column<DateTime>(type: "datetime", nullable: false),
                    AmdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpiStatusHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widAltTtl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    AltTtl = table.Column<string>(type: "varchar(120)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    TtlType = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widAltTtl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widAltTtlHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    AltTtl = table.Column<string>(type: "varchar(120)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    TtlType = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widAltTtlHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widArtist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    PerfArtistLstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    PerfArtistFstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    PerfArtistIpNameNr = table.Column<int>(type: "int", nullable: true),
                    Isrc = table.Column<string>(type: "varchar(20)", nullable: true),
                    CaeNr = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widArtist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widArtistHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    PerfArtistLstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    PerfArtistFstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    PerfArtistIpNameNr = table.Column<int>(type: "int", nullable: true),
                    Isrc = table.Column<string>(type: "varchar(20)", nullable: true),
                    CaeNr = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widArtistHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    SubmWrkNr = table.Column<string>(type: "varchar(100)", nullable: true),
                    IswcComp = table.Column<string>(type: "varchar(11)", nullable: true),
                    Ttl = table.Column<string>(type: "varchar(60)", nullable: true),
                    DurHr = table.Column<int>(type: "int", nullable: true),
                    DurMm = table.Column<int>(type: "int", nullable: true),
                    DurSs = table.Column<int>(type: "int", nullable: true),
                    WrtLstName1 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    WrtIpNameNr1 = table.Column<int>(type: "int", nullable: true),
                    CarNr1 = table.Column<int>(type: "int", nullable: true),
                    WriterLstName2 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    WrtIpNameNr2 = table.Column<int>(type: "int", nullable: true),
                    CarNr2 = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widComponentHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    SubmWrkNr = table.Column<string>(type: "varchar(100)", nullable: true),
                    IswcComp = table.Column<string>(type: "varchar(11)", nullable: true),
                    Ttl = table.Column<string>(type: "varchar(60)", nullable: true),
                    DurHr = table.Column<int>(type: "int", nullable: true),
                    DurMm = table.Column<int>(type: "int", nullable: true),
                    DurSs = table.Column<int>(type: "int", nullable: true),
                    WrtLstName1 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    WrtIpNameNr1 = table.Column<int>(type: "int", nullable: true),
                    CarNr1 = table.Column<int>(type: "int", nullable: true),
                    WriterLstName2 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    WrtIpNameNr2 = table.Column<int>(type: "int", nullable: true),
                    CarNr2 = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widComponentHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widConflict",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SocCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: false),
                    CflReasonCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    CflDt = table.Column<DateTime>(type: "datetime", nullable: true),
                    RsvDt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CflNote = table.Column<string>(type: "varchar(60)", nullable: true),
                    CntrName = table.Column<string>(type: "varchar(30)", nullable: true),
                    CntrId = table.Column<string>(type: "varchar(10)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widConflict", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widConflictHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SocCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: false),
                    CflReasonCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    CflDt = table.Column<DateTime>(type: "datetime", nullable: true),
                    RsvDt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CflNote = table.Column<string>(type: "varchar(60)", nullable: true),
                    CntrName = table.Column<string>(type: "varchar(30)", nullable: true),
                    CntrId = table.Column<string>(type: "varchar(10)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widConflictHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widInstn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: true),
                    StdInstrType = table.Column<string>(type: "varchar(3)", nullable: false),
                    NumOfVoices = table.Column<int>(type: "int", nullable: true),
                    InstrDsc = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widInstn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widInstnDtl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    InstrCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    NumOfPlayers = table.Column<int>(type: "int", nullable: true),
                    SeqNrInst = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widInstnDtl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widInstnDtlHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    InstrCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    NumOfPlayers = table.Column<int>(type: "int", nullable: true),
                    SeqNrInst = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widInstnDtlHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widInstnHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: true),
                    StdInstrType = table.Column<string>(type: "varchar(3)", nullable: false),
                    NumOfVoices = table.Column<int>(type: "int", nullable: true),
                    InstrDsc = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widInstnHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widIntrPty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    SubmIpNr = table.Column<string>(type: "varchar(10)", nullable: true),
                    IpRole = table.Column<string>(type: "varchar(3)", nullable: true),
                    IpNameNr = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widIntrPty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widIntrPtyHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    SubmIpNr = table.Column<string>(type: "varchar(10)", nullable: true),
                    IpRole = table.Column<string>(type: "varchar(3)", nullable: true),
                    IpNameNr = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widIntrPtyHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widIswc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: false),
                    PrefIswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widIswc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widIswcHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: false),
                    PrefIswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widIswcHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widOrgTtlVrExrp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    VrExrpInd = table.Column<string>(type: "varchar(60)", nullable: false),
                    EntireWrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    WrtLstName1 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    WrtLstName2 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Source = table.Column<string>(type: "varchar(60)", nullable: true),
                    IswcWrk = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widOrgTtlVrExrp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widOrgTtlVrExrpHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    VrExrpInd = table.Column<string>(type: "varchar(60)", nullable: false),
                    EntireWrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    WrtLstName1 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    WrtLstName2 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Source = table.Column<string>(type: "varchar(60)", nullable: true),
                    IswcWrk = table.Column<string>(type: "varchar(11)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widOrgTtlVrExrpHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widShares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    IntrPtyRolid = table.Column<int>(type: "int", nullable: false),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: false),
                    CtlPtySub = table.Column<byte>(type: "tinyint", nullable: true),
                    Shares = table.Column<decimal>(type: "smallmoney", nullable: true),
                    SocLicense = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widShares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widSharesHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    IntrPtyRolid = table.Column<int>(type: "int", nullable: false),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: false),
                    CtlPtySub = table.Column<byte>(type: "tinyint", nullable: true),
                    Shares = table.Column<decimal>(type: "smallmoney", nullable: true),
                    SocLicense = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widSharesHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widSubmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    SubmDt = table.Column<DateTime>(type: "datetime", nullable: true),
                    SocWorkCde = table.Column<string>(type: "varchar(20)", nullable: true),
                    TrTyp = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widSubmission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widSubmissionHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    SocCde = table.Column<string>(type: "varchar(3)", nullable: true),
                    SubmDt = table.Column<DateTime>(type: "datetime", nullable: true),
                    SocWorkCde = table.Column<string>(type: "varchar(20)", nullable: true),
                    TrTyp = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widSubmissionHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    WrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    DurHr = table.Column<int>(type: "int", nullable: true),
                    DurMm = table.Column<int>(type: "int", nullable: true),
                    DurSs = table.Column<int>(type: "int", nullable: true),
                    CprDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CprNr = table.Column<string>(type: "varchar(12)", nullable: true),
                    RecInd = table.Column<string>(type: "varchar(1)", nullable: true),
                    MwDistrCat = table.Column<string>(type: "varchar(3)", nullable: true),
                    VerType = table.Column<string>(type: "varchar(3)", nullable: true),
                    VerWic = table.Column<int>(type: "int", nullable: true),
                    ExcType = table.Column<string>(type: "varchar(3)", nullable: true),
                    ExcWic = table.Column<int>(type: "int", nullable: true),
                    CmpType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TxtMusicRel = table.Column<string>(type: "varchar(3)", nullable: true),
                    MusicArr = table.Column<string>(type: "varchar(3)", nullable: true),
                    LyrAdapt = table.Column<string>(type: "varchar(3)", nullable: true),
                    PdInd = table.Column<string>(type: "varchar(1)", nullable: true),
                    NonDisplay = table.Column<string>(type: "varchar(1)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widTitleHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    WrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    DurHr = table.Column<int>(type: "int", nullable: true),
                    DurMm = table.Column<int>(type: "int", nullable: true),
                    DurSs = table.Column<int>(type: "int", nullable: true),
                    CprDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CprNr = table.Column<string>(type: "varchar(12)", nullable: true),
                    RecInd = table.Column<string>(type: "varchar(1)", nullable: true),
                    MwDistrCat = table.Column<string>(type: "varchar(3)", nullable: true),
                    VerType = table.Column<string>(type: "varchar(3)", nullable: true),
                    VerWic = table.Column<int>(type: "int", nullable: true),
                    ExcType = table.Column<string>(type: "varchar(3)", nullable: true),
                    ExcWic = table.Column<int>(type: "int", nullable: true),
                    CmpType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TxtMusicRel = table.Column<string>(type: "varchar(3)", nullable: true),
                    MusicArr = table.Column<string>(type: "varchar(3)", nullable: true),
                    LyrAdapt = table.Column<string>(type: "varchar(3)", nullable: true),
                    PdInd = table.Column<string>(type: "varchar(1)", nullable: true),
                    NonDisplay = table.Column<string>(type: "varchar(1)", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widTitleHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widWrkOrg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    IntndPps = table.Column<string>(type: "varchar(3)", nullable: true),
                    ProdTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    CdId = table.Column<string>(type: "varchar(15)", nullable: true),
                    CutNr = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widWrkOrg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widWrkOrgHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    IntndPps = table.Column<string>(type: "varchar(3)", nullable: true),
                    ProdTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    CdId = table.Column<string>(type: "varchar(15)", nullable: true),
                    CutNr = table.Column<int>(type: "int", nullable: true),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widWrkOrgHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });

            migrationBuilder.CreateTable(
                name: "widWtrPubRel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    WtrIntrPtySeq = table.Column<int>(type: "int", nullable: false),
                    PubIntrPtySeq = table.Column<int>(type: "int", nullable: false),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widWtrPubRel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "widWtrPubRelHist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Wic = table.Column<int>(type: "int", nullable: false),
                    WtrIntrPtySeq = table.Column<int>(type: "int", nullable: false),
                    PubIntrPtySeq = table.Column<int>(type: "int", nullable: false),
                    CreTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreUid = table.Column<string>(type: "varchar(15)", nullable: true),
                    UpdTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUid = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_widWtrPubRelHist", x => new { x.Id, x.ValidFrom, x.ValidTo });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IpiBase");

            migrationBuilder.DropTable(
                name: "IpiBaseHist");

            migrationBuilder.DropTable(
                name: "IpiMbrAgreeTerr");

            migrationBuilder.DropTable(
                name: "IpiMbrAgreeTerrHist");

            migrationBuilder.DropTable(
                name: "IpiName");

            migrationBuilder.DropTable(
                name: "IpiNameHist");

            migrationBuilder.DropTable(
                name: "IpiStatus");

            migrationBuilder.DropTable(
                name: "IpiStatusHist");

            migrationBuilder.DropTable(
                name: "widAltTtl");

            migrationBuilder.DropTable(
                name: "widAltTtlHist");

            migrationBuilder.DropTable(
                name: "widArtist");

            migrationBuilder.DropTable(
                name: "widArtistHist");

            migrationBuilder.DropTable(
                name: "widComponent");

            migrationBuilder.DropTable(
                name: "widComponentHist");

            migrationBuilder.DropTable(
                name: "widConflict");

            migrationBuilder.DropTable(
                name: "widConflictHist");

            migrationBuilder.DropTable(
                name: "widInstn");

            migrationBuilder.DropTable(
                name: "widInstnDtl");

            migrationBuilder.DropTable(
                name: "widInstnDtlHist");

            migrationBuilder.DropTable(
                name: "widInstnHist");

            migrationBuilder.DropTable(
                name: "widIntrPty");

            migrationBuilder.DropTable(
                name: "widIntrPtyHist");

            migrationBuilder.DropTable(
                name: "widIswc");

            migrationBuilder.DropTable(
                name: "widIswcHist");

            migrationBuilder.DropTable(
                name: "widOrgTtlVrExrp");

            migrationBuilder.DropTable(
                name: "widOrgTtlVrExrpHist");

            migrationBuilder.DropTable(
                name: "widShares");

            migrationBuilder.DropTable(
                name: "widSharesHist");

            migrationBuilder.DropTable(
                name: "widSubmission");

            migrationBuilder.DropTable(
                name: "widSubmissionHist");

            migrationBuilder.DropTable(
                name: "widTitle");

            migrationBuilder.DropTable(
                name: "widTitleHist");

            migrationBuilder.DropTable(
                name: "widWrkOrg");

            migrationBuilder.DropTable(
                name: "widWrkOrgHist");

            migrationBuilder.DropTable(
                name: "widWtrPubRel");

            migrationBuilder.DropTable(
                name: "widWtrPubRelHist");
        }
    }
}

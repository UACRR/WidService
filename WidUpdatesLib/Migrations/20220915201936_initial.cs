using Microsoft.EntityFrameworkCore.Migrations;

namespace WidUpdatesLib.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DscFieldColNames",
                columns: table => new
                {
                    FieldName = table.Column<string>(type: "varchar(64)", nullable: false),
                    ColName = table.Column<string>(type: "varchar(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DscFieldColNames", x => x.FieldName);
                });

            migrationBuilder.CreateTable(
                name: "DscFmtInfo",
                columns: table => new
                {
                    Fmt = table.Column<string>(type: "char(1)", nullable: false),
                    CsTypeName = table.Column<string>(type: "varchar(32)", nullable: true),
                    SqlTypeName = table.Column<string>(type: "varchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DscFmtInfo", x => x.Fmt);
                });

            migrationBuilder.CreateTable(
                name: "DscRecTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Nr = table.Column<string>(type: "char(4)", nullable: true),
                    Dsc = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DscRecTypes", x => x.Code);
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
                name: "WrkAffectedRecords",
                columns: table => new
                {
                    EntityName = table.Column<string>(type: "varchar(6)", nullable: true),
                    Wic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DscRecFields",
                columns: table => new
                {
                    RecTypeCode = table.Column<string>(type: "char(3)", nullable: false),
                    SeqNr = table.Column<int>(type: "int", nullable: false),
                    Field = table.Column<string>(type: "varchar(64)", nullable: true),
                    Start = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Fmt = table.Column<string>(type: "char(1)", nullable: false),
                    Req = table.Column<string>(type: "char(1)", nullable: false),
                    Dsc = table.Column<string>(type: "varchar(1024)", nullable: true),
                    Rules = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DscRecFields", x => new { x.RecTypeCode, x.SeqNr });
                    table.ForeignKey(
                        name: "FK_DscRecFields_DscRecTypes_RecTypeCode",
                        column: x => x.RecTypeCode,
                        principalTable: "DscRecTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecAck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreDate = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreTime = table.Column<string>(type: "varchar(6)", nullable: true),
                    OrigGrpNr = table.Column<string>(type: "varchar(5)", nullable: true),
                    OrigTransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    OrigTransType = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    SubmCreNr = table.Column<string>(type: "varchar(20)", nullable: true),
                    RcpntCreNr = table.Column<string>(type: "varchar(20)", nullable: true),
                    ProcDate = table.Column<string>(type: "varchar(8)", nullable: true),
                    TransStt = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecAck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecAck_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecAlt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    AltTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    TtlType = table.Column<string>(type: "varchar(3)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecAlt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecAlt_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecCom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Ttl = table.Column<string>(type: "varchar(60)", nullable: true),
                    IswcComp = table.Column<string>(type: "varchar(11)", nullable: true),
                    SubmWrkNr = table.Column<string>(type: "varchar(14)", nullable: true),
                    Dur = table.Column<string>(type: "varchar(6)", nullable: true),
                    WrtLstName1 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName1 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Filler1 = table.Column<string>(type: "varchar(9)", nullable: true),
                    WriterLstName2 = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName2 = table.Column<string>(type: "varchar(30)", nullable: true),
                    Filler2 = table.Column<string>(type: "varchar(9)", nullable: true),
                    WrtIpNameNr1 = table.Column<string>(type: "varchar(11)", nullable: true),
                    WrtIpNameNr2 = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecCom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecCom_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecCon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    CflReasonCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: true),
                    WrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    CflNote = table.Column<string>(type: "varchar(60)", nullable: true),
                    CntrName = table.Column<string>(type: "varchar(30)", nullable: true),
                    CntrId = table.Column<string>(type: "varchar(10)", nullable: true),
                    SocCode = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecCon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecCon_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecDel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    SubmWrkNr = table.Column<string>(type: "varchar(14)", nullable: true),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecDel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecDel_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecEwt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    EntireWrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    IswcWrk = table.Column<string>(type: "varchar(11)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    WrtLstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    Src = table.Column<string>(type: "varchar(60)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecEwt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecEwt_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecInd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    InstrCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    NumOfPlayers = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecInd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecInd_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    NumOfVoices = table.Column<string>(type: "varchar(3)", nullable: true),
                    StdInstrType = table.Column<string>(type: "varchar(3)", nullable: true),
                    InstrDsc = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecIns_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecIsw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    CreTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecIsw", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecIsw_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecLnk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    WicMergedWrk = table.Column<string>(type: "varchar(10)", nullable: true),
                    WicDelWrk = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecLnk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecLnk_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecMsg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    MsgType = table.Column<string>(type: "varchar(1)", nullable: true),
                    OrigRecSeq = table.Column<string>(type: "varchar(8)", nullable: true),
                    OrigRecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    MsgLevel = table.Column<string>(type: "varchar(1)", nullable: true),
                    CndNr = table.Column<string>(type: "varchar(3)", nullable: true),
                    MsgTxt = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecMsg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecMsg_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecOip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Filler1 = table.Column<string>(type: "varchar(9)", nullable: true),
                    IpNr = table.Column<string>(type: "varchar(9)", nullable: true),
                    IpName = table.Column<string>(type: "varchar(45)", nullable: true),
                    IpFstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    IpRole = table.Column<string>(type: "varchar(2)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecOip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecOip_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecOrn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    IntndPps = table.Column<string>(type: "varchar(3)", nullable: true),
                    ProdTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    CdId = table.Column<string>(type: "varchar(15)", nullable: true),
                    CutNr = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecOrn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecOrn_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecOsr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Filler3 = table.Column<string>(type: "varchar(9)", nullable: true),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: true),
                    Shares = table.Column<string>(type: "varchar(5)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    Aff = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecOsr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecOsr_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecPer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    PerfArtistLstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    PerfArtistFstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    Filler4 = table.Column<string>(type: "varchar(9)", nullable: true),
                    PerfArtistIpNameNr = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecPer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecPer_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecRes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: true),
                    WrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    SocCode = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecRes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecRes_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecSip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Filler5 = table.Column<string>(type: "varchar(9)", nullable: true),
                    IpNr = table.Column<string>(type: "varchar(9)", nullable: true),
                    IpName = table.Column<string>(type: "varchar(45)", nullable: true),
                    IpFstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    IpRole = table.Column<string>(type: "varchar(2)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecSip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecSip_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecSoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    WrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    SubmWrkNr = table.Column<string>(type: "varchar(14)", nullable: true),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    CprDate = table.Column<string>(type: "varchar(8)", nullable: true),
                    CprNr = table.Column<string>(type: "varchar(12)", nullable: true),
                    MwDistrCat = table.Column<string>(type: "varchar(3)", nullable: true),
                    Dur = table.Column<string>(type: "varchar(6)", nullable: true),
                    RecInd = table.Column<string>(type: "varchar(1)", nullable: true),
                    TxtMusicRel = table.Column<string>(type: "varchar(3)", nullable: true),
                    CmpType = table.Column<string>(type: "varchar(3)", nullable: true),
                    VerType = table.Column<string>(type: "varchar(3)", nullable: true),
                    ExcType = table.Column<string>(type: "varchar(3)", nullable: true),
                    MusicArr = table.Column<string>(type: "varchar(3)", nullable: true),
                    LyrAdapt = table.Column<string>(type: "varchar(3)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    UpdDate = table.Column<string>(type: "varchar(8)", nullable: true),
                    FstSendDateToCis = table.Column<string>(type: "varchar(8)", nullable: true),
                    LstSendDateToCis = table.Column<string>(type: "varchar(8)", nullable: true),
                    SocWrkType = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecSoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecSoc_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecSsr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Filler6 = table.Column<string>(type: "varchar(9)", nullable: true),
                    RightType = table.Column<string>(type: "varchar(3)", nullable: true),
                    Shares = table.Column<string>(type: "varchar(5)", nullable: true),
                    IpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    Aff = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecSsr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecSsr_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecTtu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    OrigWrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    NewWrkTtl = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecTtu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecTtu_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecVer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    OrigWrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    IswcOrigWrk = table.Column<string>(type: "varchar(11)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    WrtLstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    WrtFstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    Src = table.Column<string>(type: "varchar(60)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecVer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecVer_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecWia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    WrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    SubmWrkNr = table.Column<string>(type: "varchar(14)", nullable: true),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    CprDate = table.Column<string>(type: "varchar(8)", nullable: true),
                    CprNr = table.Column<string>(type: "varchar(12)", nullable: true),
                    MwDistrCat = table.Column<string>(type: "varchar(3)", nullable: true),
                    Dur = table.Column<string>(type: "varchar(6)", nullable: true),
                    RecInd = table.Column<string>(type: "varchar(1)", nullable: true),
                    TxtMusicRel = table.Column<string>(type: "varchar(3)", nullable: true),
                    CmpType = table.Column<string>(type: "varchar(3)", nullable: true),
                    VerType = table.Column<string>(type: "varchar(3)", nullable: true),
                    ExcType = table.Column<string>(type: "varchar(3)", nullable: true),
                    MusicArr = table.Column<string>(type: "varchar(3)", nullable: true),
                    LyrAdapt = table.Column<string>(type: "varchar(3)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    UpdDate = table.Column<string>(type: "varchar(8)", nullable: true),
                    FstSendDateToCis = table.Column<string>(type: "varchar(8)", nullable: true),
                    LstSendDateToCis = table.Column<string>(type: "varchar(8)", nullable: true),
                    SocWrkType = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecWia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecWia_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecWiu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    WrkTtl = table.Column<string>(type: "varchar(60)", nullable: true),
                    LngCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    SubmWrkNr = table.Column<string>(type: "varchar(14)", nullable: true),
                    Iswc = table.Column<string>(type: "varchar(11)", nullable: true),
                    CprDate = table.Column<string>(type: "varchar(8)", nullable: true),
                    CprNr = table.Column<string>(type: "varchar(12)", nullable: true),
                    MwDistrCat = table.Column<string>(type: "varchar(3)", nullable: true),
                    Dur = table.Column<string>(type: "varchar(6)", nullable: true),
                    RecInd = table.Column<string>(type: "varchar(1)", nullable: true),
                    TxtMusicRel = table.Column<string>(type: "varchar(3)", nullable: true),
                    CmpType = table.Column<string>(type: "varchar(3)", nullable: true),
                    VerType = table.Column<string>(type: "varchar(3)", nullable: true),
                    ExcType = table.Column<string>(type: "varchar(3)", nullable: true),
                    MusicArr = table.Column<string>(type: "varchar(3)", nullable: true),
                    LyrAdapt = table.Column<string>(type: "varchar(3)", nullable: true),
                    WicCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    UpdDate = table.Column<string>(type: "varchar(8)", nullable: true),
                    FstSendDateToCis = table.Column<string>(type: "varchar(8)", nullable: true),
                    LstSendDateToCis = table.Column<string>(type: "varchar(8)", nullable: true),
                    SocWrkType = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecWiu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecWiu_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecWpl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdFileId = table.Column<int>(type: "int", nullable: false),
                    RecType = table.Column<string>(type: "varchar(3)", nullable: true),
                    TransSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    RecSeqNr = table.Column<string>(type: "varchar(8)", nullable: true),
                    Filler7 = table.Column<string>(type: "varchar(9)", nullable: true),
                    Filler8 = table.Column<string>(type: "varchar(9)", nullable: true),
                    WrtIpNameNr = table.Column<string>(type: "varchar(11)", nullable: true),
                    PubIpNameNr = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecWpl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecWpl_UpdFiles_UpdFileId",
                        column: x => x.UpdFileId,
                        principalTable: "UpdFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DscFieldColNames",
                columns: new[] { "FieldName", "ColName" },
                values: new object[,]
                {
                    { "Affiliation", "Aff" },
                    { "Source", "Src" },
                    { "Society Work type", "SocWrkType" },
                    { "Society Code", "SocCode" },
                    { "Shares", "Shares" },
                    { "Right Type", "RightType" },
                    { "Recorded Indicator", "RecInd" },
                    { "Record Type", "RecType" },
                    { "Record Sequence #", "RecSeqNr" },
                    { "Publisher  IPI Name #", "PubIpNameNr" },
                    { "Standard Instrumentation Type", "StdInstrType" },
                    { "Production Title", "ProdTtl" },
                    { "Performing Artist Last Name", "PerfArtistLstName" },
                    { "Performing Artist IPI Name #", "PerfArtistIpNameNr" },
                    { "Performing Artist First Name", "PerfArtistFstName" },
                    { "Original Work Title", "OrigWrkTtl" },
                    { "Original Transaction Type", "OrigTransType" },
                    { "Original Transaction Sequence #", "OrigTransSeqNr" },
                    { "Original Record Type", "OrigRecType" },
                    { "Original Record Sequence ", "OrigRecSeq" },
                    { "Original Group Number", "OrigGrpNr" },
                    { "Processing Date", "ProcDate" },
                    { "Submitter Creation #", "SubmCreNr" },
                    { "Submitter Work #", "SubmWrkNr" },
                    { "Text Music Relationship", "TxtMusicRel" },
                    { "Writer Last Name", "WrtLstName" },
                    { "Writer IPI Name #", "WrtIpNameNr" },
                    { "Writer First Name", "WrtFstName" },
                    { "Writer 2: Last Name", "WriterLstName2" },
                    { "Writer 2: IPI Name #", "WrtIpNameNr2" },
                    { "Writer 2: First Name", "WrtFstName2" },
                    { "Writer 1: Last Name", "WrtLstName1" },
                    { "Writer 1: IPI Name #", "WrtIpNameNr1" },
                    { "Writer 1: First Name", "WrtFstName1" },
                    { "Work Title", "WrkTtl" },
                    { "WIC of Newly Merged Work", "kMergedWrk" },
                    { "WIC of Deleted Work", "WickDelWr" },
                    { "WIC ", "Wic" },
                    { "WI Code", "WicCode" },
                    { "Version Type", "VerType" },
                    { "Update date ", "UpdDate " },
                    { "Type of Right", "RightType" }
                });

            migrationBuilder.InsertData(
                table: "DscFieldColNames",
                columns: new[] { "FieldName", "ColName" },
                values: new object[,]
                {
                    { "Transaction Status", "TransStt" },
                    { "Transaction Sequence #", "TransSeqNr" },
                    { "Title Type", "TtlType" },
                    { "Title", "Ttl" },
                    { "Number of Voices", "NumOfVoices" },
                    { "Number of Players", "NumOfPlayers" },
                    { "Recipient Creation #", "RcpntCreNr" },
                    { "Musical Work Distribution Category", "MwDistrCat" },
                    { "Filler3", "Filler3" },
                    { "Filler2", "Filler2" },
                    { "Filler1", "Filler1" },
                    { "Excerpt Type", "ExcType" },
                    { "Entire Work Title", "EntireWrkTtl" },
                    { "Duration", "Dur" },
                    { "Cut Number", "CutNr" },
                    { "Creation Title", "CreTtl" },
                    { "Creation Time", "CreTime" },
                    { "Creation Date", "CreDate" },
                    { "Copyright Number", "CprNr" },
                    { "New Work Title", "NewWrkTtl" },
                    { "Contact Name", "CntrName" },
                    { "Contact ID", "CntrId" },
                    { "Conflict Reason Code", "CflReasonCode" },
                    { "Conflict Note", "CflNote" },
                    { "Condition Number", "CndNr" },
                    { "Composite Type", "CmpType" },
                    { "CD Identifier", "CdId" },
                    { "Archived ISWC", "ArchIswc" },
                    { "Alternate Title", "AltTtl" },
                    { "Filler4", "Filler4" },
                    { "Filler5", "Filler5" },
                    { "Copyright Date", "CprDate" },
                    { "Filler7", "Filler7" },
                    { "Music Arrangement ", "MusicArr" },
                    { "Message Type", "MsgType" },
                    { "Message Text", "MsgTxt" },
                    { "Message Level", "MsgLevel" },
                    { "Lyric Adaptation", "LyrAdapt" },
                    { "Last sending date to CIS-Net", "LstSendDateToCis" },
                    { "Language Code", "LngCode" },
                    { "ISWC of Original Work", "IswcOrigWrk" },
                    { "ISWC of Entire Work", "IswcWrk" }
                });

            migrationBuilder.InsertData(
                table: "DscFieldColNames",
                columns: new[] { "FieldName", "ColName" },
                values: new object[,]
                {
                    { "ISWC of Component", "IswcComp" },
                    { "ISWC", "Iswc" },
                    { "IP Role", "IpRole" },
                    { "IP Name", "IpName" },
                    { "IP First Name", "IpFstName" },
                    { "Interested Party #", "IpNr" },
                    { "Intended Purpose", "IntndPps" },
                    { "Instrumentation Description", "InstrDsc" },
                    { "Instrument Code", "InstrCode" },
                    { "First sending date to CIS-Net", "FstSendDateToCis" },
                    { "Filler8", "Filler8" },
                    { "IPI Name #", "IpNameNr" },
                    { "Filler6", "Filler6" }
                });

            migrationBuilder.InsertData(
                table: "DscFmtInfo",
                columns: new[] { "Fmt", "CsTypeName", "SqlTypeName" },
                values: new object[,]
                {
                    { "N", "string", "varchar" },
                    { "O", "string", "varchar" },
                    { "L", "string", "varchar" },
                    { "D", "string", "varchar" },
                    { "A", "string", "varchar" },
                    { "F", "string", "varchar" }
                });

            migrationBuilder.InsertData(
                table: "DscRecTypes",
                columns: new[] { "Code", "Dsc", "Nr" },
                values: new object[,]
                {
                    { "IND", "Instrumentation Detail", "7.14" },
                    { "INS", "Instrumentation Summary", "7.13" },
                    { "ORN", "Work Origin", "7.12" },
                    { "PER", "Performing Artist", "7.11" },
                    { "VER", "Original Work Title for Versions", "7.10" },
                    { "EWT", "Entire Work Title for Excerpts", "7.09" },
                    { "ALT", "Alternate Title", "7.08" },
                    { "WPL", "Writer Publisher Link", "7.07" },
                    { "OSR", "Other Shares", "7.06" },
                    { "SSR", "Shares Controlled by Submitter", "7.05" },
                    { "OIP", "Other Interested Party", "7.04" },
                    { "SIP", "Interested Party Controlled By Submitter", "7.03" },
                    { "ISW", "Notification of Additional ISWC", "7.01" },
                    { "ACK", "Acknowledgment of Transaction", "6.08" },
                    { "DEL", "Delete Transaction", "6.07" },
                    { "RES", "Notification of Resolution of Conflict", "6.06" },
                    { "CON", "Conflict Notification", "6.05" },
                    { "TTU", "Work Title Update", "6.04" },
                    { "SOC", "Society Notification", "6.03" },
                    { "WIU", "Work Information Update", "6.02" },
                    { "WIA", "Work Information Add", "6.01" },
                    { "COM", "Component", "7.15" },
                    { "LNK", "Notification of Work merged to its Duplicate", "7.02" }
                });

            migrationBuilder.InsertData(
                table: "DscRecTypes",
                columns: new[] { "Code", "Dsc", "Nr" },
                values: new object[] { "MSG", "Message", "7.16" });

            migrationBuilder.InsertData(
                table: "DscRecFields",
                columns: new[] { "RecTypeCode", "SeqNr", "Dsc", "Field", "Fmt", "Req", "Rules", "Size", "Start" },
                values: new object[,]
                {
                    { "WIA", 1, "Set Record Type = WIA (Work Information Add) for new registrations, WIU (Work Information Update) for revisions, or SOC (Society Notification)", "Record Type", "A", "M", "A", 3, 1 },
                    { "OSR", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "OSR", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "OSR", 4, "No longer in use", "Filler3", " ", " ", "", 9, 20 },
                    { "OSR", 5, "The type of right for which these shares exist. These values reside on the Type of Right Table.", "Type of Right", "L", "M", "2", 3, 29 },
                    { "OSR", 6, "The shares assigned to this IP for this type of right.  Shares should be formatted as 999V99 (implied decimal point).  For example, 25.87% would be entered as ‘02587’.", "Shares", "N", "M", "3", 5, 32 },
                    { "OSR", 7, "The IPI name number assigned to this IP.", "IPI Name #", "N", "M", "1,4", 11, 37 },
                    { "OSR", 8, "The society to which this IP belongs for this right.", "Affiliation", "L", "O", "", 3, 48 },
                    { "WPL", 1, "Set Record Type = WPL (Writer Publisher Link)", "Record Type", "A", "M", "A", 3, 1 },
                    { "WPL", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "WPL", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "WPL", 4, "No longer used", "Filler7", " ", " ", "", 9, 20 },
                    { "WPL", 5, "No longer used", "Filler8", "L", "C", " ", 9, 29 },
                    { "OSR", 1, "Set Record Type = SSR (Shares Controlled by Submitter) or OSR (Other Shares)", "Record Type", "A", "M", "A", 3, 1 },
                    { "WPL", 6, "The IPI Name # for the writer linked to the Publisher IPI Name #on this record.", "Writer IPI Name #", "L", "C", "1", 11, 38 },
                    { "ALT", 1, "Set Record Type = ALT (Alternate Title)", "Record Type", "A", "M", "A", 3, 1 },
                    { "ALT", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "ALT", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "ALT", 4, "AKA or pseudonym of the work title.", "Alternate Title", "A", "M", "1", 60, 20 },
                    { "ALT", 5, "Indicates the type of alternate title presented on this record.  These values reside in the Title Type Table.", "Title Type", "L", "M", "2", 3, 80 },
                    { "ALT", 6, "The Code representing the language that this alternate title has been translated into.  These values reside in the Language Code Table.", "Language Code", "L", "O", "3", 2, 83 },
                    { "EWT", 1, "Set Record Type = EWT (Entire Work Title for Excerpts)", "Record Type", "A", "M", "A", 3, 1 },
                    { "EWT", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "EWT", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "EWT", 4, "The title of the entire work from which this excerpt has been derived.", "Entire Work Title", "A", "M", "1", 60, 20 },
                    { "EWT", 5, "The International Standard Work Code assigned to the work from which this excerpt has been derived.", "ISWC of Entire Work", "A", "O", "2,5", 11, 80 },
                    { "EWT", 6, "The Code defining the language in which the entire was originally written.  These values reside in the Language Code Table.", "Language Code", "L", "O", "3", 2, 91 },
                    { "WPL", 7, "The IPI Name #for the publisher linked to the Writer IPI Name #on this record.", "Publisher  IPI Name #", "L", "C", "2", 11, 49 },
                    { "EWT", 7, "Last name of the original writer/composer of the work from which this excerpt has been taken. Note that if the submitter does not have the ability to split first and last names, the entire name should be entered in this field in the format “LastName, FirstName” including the comma after the last name.", "Writer Last Name", "A", "O", "", 45, 93 },
                    { "SSR", 8, "The society to which this IP belongs for this right.", "Affiliation", "L", "O", "", 3, 48 },
                    { "SSR", 6, "The shares assigned to this IP for this type of right.  Shares should be formatted as 999V99 (implied decimal point).  For example, 25.87% would be entered as ‘02587’.", "Shares", "N", "M", "3", 5, 32 },
                    { "LNK", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "LNK", 4, "The WIC assigned to the newly merged musical work. ", "WIC of Newly Merged Work", "N", "M", "1", 10, 20 },
                    { "LNK", 5, "The WIC assigned to the duplicate work that is being deleted.", "WIC of Deleted Work", "N", "M", "2", 10, 30 },
                    { "SIP", 1, "Set Record Type = SIP (Interested Party Controlled by Submitter) or OIP (Other Interested Party)", "Record Type", "A", "M", "A,2", 3, 1 },
                    { "SIP", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "SIP", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "SIP", 4, "No longer in use", "Filler5", " ", " ", "", 9, 20 },
                    { "SIP", 5, "Submitters unique identifier for this IP.  This field is required for record type SIP and optional for record type OIP.", "Interested Party #", "A", "C", "2,3", 9, 29 },
                    { "SIP", 6, "For publisher IP’s, enter the name of the publisher.  For writer IP’s, enter the writers last name.", "IP Name", "A", "M", "4", 45, 38 },
                    { "SIP", 7, "For writer IP’s, enter the writers first name.", "IP First Name", "O", "O", "4", 30, 83 },
                    { "SIP", 8, "Code defining this interested party’s role in this work.   These values reside on the Works IP Role  Table.", "IP Role", "L", "M", "5", 2, 113 }
                });

            migrationBuilder.InsertData(
                table: "DscRecFields",
                columns: new[] { "RecTypeCode", "SeqNr", "Dsc", "Field", "Fmt", "Req", "Rules", "Size", "Start" },
                values: new object[,]
                {
                    { "SIP", 9, "The IPI name number assigned to this IP.", "IPI Name #", "L", "M", "1,7,8,9", 11, 115 },
                    { "SSR", 7, "The IPI name number assigned to this IP.", "IPI Name #", "N", "M", "1,4", 11, 37 },
                    { "OIP", 1, "Set Record Type = SIP (Interested Party Controlled by Submitter) or OIP (Other Interested Party)", "Record Type", "A", "M", "A,2", 3, 1 },
                    { "OIP", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "OIP", 4, "No longer in use", "Filler1", " ", " ", "", 9, 20 },
                    { "OIP", 5, "Submitters unique identifier for this IP.  This field is required for record type SIP and optional for record type OIP.", "Interested Party #", "A", "C", "2,3", 9, 29 },
                    { "OIP", 6, "For publisher IP’s, enter the name of the publisher.  For writer IP’s, enter the writers last name.", "IP Name", "A", "M", "4", 45, 38 },
                    { "OIP", 7, "For writer IP’s, enter the writers first name.", "IP First Name", "O", "O", "4", 30, 83 },
                    { "OIP", 8, "Code defining this interested party’s role in this work.   These values reside on the Works IP Role  Table.", "IP Role", "L", "M", "5", 2, 113 },
                    { "OIP", 9, "The IPI name number assigned to this IP.", "IPI Name #", "L", "M", "1,7,8,9", 11, 115 },
                    { "SSR", 1, "Set Record Type = SSR (Shares Controlled by Submitter) or OSR (Other Shares)", "Record Type", "A", "M", "A", 3, 1 },
                    { "SSR", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "SSR", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "SSR", 4, "No longer in use", "Filler6", " ", " ", "", 9, 20 },
                    { "SSR", 5, "The type of right for which these shares exist. These values reside on the Type of Right Table.", "Type of Right", "L", "M", "2", 3, 29 },
                    { "OIP", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "EWT", 8, "First name of the original writer/composer of the work from which this excerpt has been taken.", "Writer First Name", "A", "O", "", 30, 138 },
                    { "EWT", 9, "A description of the source from which the work was obtained.", "Source", "A", "O", "", 60, 168 },
                    { "EWT", 10, "The WI Code assigned to the work from which this excerpt has been derived.", "WI Code", "N", "O", "4,5", 10, 228 },
                    { "IND", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "IND", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "IND", 4, "Indicates the use of a specific instrument in this version of instrumentation.  These values reside in the Instrument Table.", "Instrument Code", "L", "M", "1", 3, 20 },
                    { "IND", 5, "Indicates the number of players for the above instrument.  Note if the number of players is not a significant detail enter zero.", "Number of Players", "N", "M", "2", 3, 23 },
                    { "COM", 1, "Set Record Type = COM (Composite Component)", "Record Type", "A", "M", "A", 3, 1 },
                    { "COM", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "COM", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "COM", 4, "The title of the original work from which a portion was taken to include in the composite.", "Title", "A", "M", "1", 60, 20 },
                    { "COM", 5, "The International Standard Work Code assigned to the original work from which a portion was taken and included in this composite work.", "ISWC of Component", "L", "O", "2", 11, 80 },
                    { "COM", 6, "The number that the submitting publisher uses to refer to this  component.", "Submitter Work #", "A", "O", "", 14, 91 },
                    { "COM", 7, "The duration of the individual  component within the composite work.", "Duration", "T", "O", "3", 6, 105 },
                    { "COM", 8, "Last name of the first writer of this component. Note that if the submitter does not have the ability to split first and last names, the entire name should be entered in this field in the format “LastName, FirstName” including the comma after the last name.", "Writer 1: Last Name", "A", "M", "4", 45, 111 },
                    { "IND", 1, "Set Record Type = IND (Instrumentation Detail)", "Record Type", "A", "M", "A", 3, 1 },
                    { "COM", 9, "First name of the first writer of this component.", "Writer 1: First Name", "A", "O", "", 30, 156 },
                    { "COM", 11, "Last name of the second writer of this component. Note that if the submitter does not have the ability to split first and last names, the entire name should be entered in this field in the format “LastName, FirstName” including the comma after the last name.", "Writer 2: Last Name", "A", "O", "", 45, 195 },
                    { "COM", 12, "First name of the second writer of this component.", "Writer 2: First Name", "A", "O", "", 30, 240 },
                    { "COM", 13, "No longer used", "Filler2", " ", " ", " ", 9, 270 },
                    { "COM", 14, "IPI Name # of the first writer of this component.", "Writer 1: IPI Name #", "N", "O", "6", 11, 279 },
                    { "COM", 15, "IPI Name # of the second writer of this component.", "Writer 2: IPI Name #", "N", "O", "6", 11, 290 },
                    { "MSG", 1, "Set Record Type = MSG (Message)", "Record Type", "A", "M", "A", 3, 1 },
                    { "MSG", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "MSG", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "MSG", 4, "Indicates whether this information is a warning, error, or for information only.  Values are F = Field Rejected, R = Record Rejected, T = Transaction Rejected, G = Group Rejected, E = Entire File Rejected", "Message Type", "L", "M", "1", 1, 20 }
                });

            migrationBuilder.InsertData(
                table: "DscRecFields",
                columns: new[] { "RecTypeCode", "SeqNr", "Dsc", "Field", "Fmt", "Req", "Rules", "Size", "Start" },
                values: new object[,]
                {
                    { "MSG", 5, "The Record Sequence Number within the packet associated with this acknowledgment that caused the generation of this message.", "Original Record Sequence ", "N", "M", "2", 8, 21 },
                    { "MSG", 6, "The record type within the original transaction that caused generation of this message.", "Original Record Type", "A", "M", "", 3, 29 },
                    { "MSG", 7, "The level of editing that was responsible for generation of this message.  Values are E = Entire File, G = Group, T = Transaction, R = Record, F = Field.", "Message Level", "L", "M", "3", 1, 32 },
                    { "COM", 10, "No longer used", "Filler1", " ", " ", " ", 9, 186 },
                    { "INS", 6, "Describes instrumentation if non-standard instrumentation is used on this work. Note that this field is required if IND records are not entered or if Standard Instrumentation Type is blank.", "Instrumentation Description", "A", "C", "", 50, 26 },
                    { "INS", 5, "Describes instrumentation if standard instrumentation is used on this work. Note that this field is required if IND records are not entered or if Instrumentation Description is blank.  These values reside in the Standard Instrumentation Table.", "Standard Instrumentation Type", "L", "C", "2,3", 3, 23 },
                    { "INS", 4, "Indicates the number of independent parts on this work.", "Number of Voices", "N", "M", "1", 3, 20 },
                    { "VER", 1, "Set Record Type = VER (Original Work Title for Versions)", "Record Type", "A", "M", "A", 3, 1 },
                    { "VER", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "VER", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "VER", 4, "Original title of the work from which this version was derived.", "Original Work Title", "A", "M", "1", 60, 20 },
                    { "VER", 5, "The International Standard Work Code assigned to the work from which this version has been derived.", "ISWC of Original Work", "A", "O", "2,5", 11, 80 },
                    { "VER", 6, "The Code defining the language in which the work was originally written.  These values reside in the Language Code Table.", "Language Code", "L", "O", "3", 2, 91 },
                    { "VER", 7, "Last name of the original writer/composer of the work from which this version has been derived. Note that if the submitter does not have the ability to split first and last names, the entire name should be entered in this field in the format “LastName, FirstName” including the comma after the last name.", "Writer Last Name", "A", "O", "", 45, 93 },
                    { "VER", 8, "First name of the original writer/composer of the work from which this version has been derived.", "Writer First Name", "A", "O", "", 30, 138 },
                    { "VER", 9, "A description of the source from which the work was obtained.", "Source", "A", "O", "", 60, 168 },
                    { "VER", 10, "The WI Code assigned to the work from which this version has been derived.", "WI Code", "N", "O", "4,5", 10, 228 },
                    { "PER", 1, "Set Record Type = PER (Performing Artist)", "Record Type", "A", "M", "A", 3, 1 },
                    { "PER", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "PER", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "PER", 4, "Last name of a person or name of a group that has performed the work on a recording or in public.", "Performing Artist Last Name", "A", "M", "1", 45, 20 },
                    { "PER", 5, "First name associated with the performing artist identified in the previous field.", "Performing Artist First Name", "A", "O", "", 30, 65 },
                    { "PER", 6, "No longer used", "Filler4", " ", " ", " ", 9, 95 },
                    { "PER", 7, "The IPI Name # corresponding to this performing artist.  Values reside in the IPI System.", "Performing Artist IPI Name #", "L", "O", "2", 11, 104 },
                    { "ORN", 1, "Set Record Type = ORN (Work Origin)", "Record Type", "A", "M", "A", 3, 1 },
                    { "ORN", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "ORN", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "ORN", 4, "Indicates the type of production from which this work originated.  These values reside in the Intended Purpose Table.", "Intended Purpose", "L", "M", "1", 3, 20 },
                    { "ORN", 5, "Name of the production or library from which this work originated.", "Production Title", "A", "M", "2", 60, 23 },
                    { "ORN", 6, "If Intended Purpose is equal to LIB (Library Work), enter the identifier associated with the CD upon which the work appears", "CD Identifier", "A", "C", "3", 15, 83 },
                    { "ORN", 7, "If Intended Purpose is equal to LIB (Library Work), enter the track number on the CD Identifier where the work appears.  This field is required when CD Identifier is entered.", "Cut Number", "N", "C", "3", 4, 98 },
                    { "INS", 1, "Set Record Type = INS (Instrumentation Summary)", "Record Type", "A", "M", "A", 3, 1 },
                    { "INS", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "INS", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "LNK", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "LNK", 1, "Set Record Type = LNK (Notification of Work Merged to its Duplicate)", "Record Type", "A", "M", "A", 3, 1 },
                    { "ISW", 5, "An Archived ISWC assigned to this musical work. ", "Archived ISWC", "A", "M", "2", 11, 80 },
                    { "ISW", 4, "The creation title as delivered by the submitter (i.e. the title of the musical work).", "Creation Title", "A", "C", "1", 60, 20 },
                    { "WIU", 10, "Describes the type of music as it applies to special distribution rules.  Values for this field reside in the Musical Work Distribution Category Table. ", "Musical Work Distribution Category", "L", "M", "6,7", 3, 127 },
                    { "WIU", 11, "Duration of the work in hours, minutes, and seconds.  This field must be greater than zero if Musical Work Distribution Category is equal to SER.  ", "Duration", "T", "C", "8", 6, 130 },
                    { "WIU", 12, "Indicates whether or not the work has ever been recorded.", "Recorded Indicator", "F", "M", "9", 1, 136 },
                    { "WIU", 13, "Indicates whether this work contains music, text, and/or both.  Values are MTX = Both Music and Text, MUS = Music only, TXT = Text only.", "Text Music Relationship", "A", "O", "10", 3, 137 }
                });

            migrationBuilder.InsertData(
                table: "DscRecFields",
                columns: new[] { "RecTypeCode", "SeqNr", "Dsc", "Field", "Fmt", "Req", "Rules", "Size", "Start" },
                values: new object[,]
                {
                    { "WIU", 14, "If this is a composite work, this field will indicate the type of composite.  Values reside in the Composite Type Table.", "Composite Type", "L", "O", "11", 3, 140 },
                    { "WIU", 15, "Indicates relationships between this work and other works.  Note that this field is used to indicate whether or not this work is an arrangement.  Values reside in the Version Type Table.", "Version Type", "L", "M", "12,14,15", 3, 143 },
                    { "WIU", 16, "If this is an excerpt, this field will indicate the type of excerpt.  Values reside in the Excerpt Type Table.", "Excerpt Type", "L", "O", "13", 3, 146 },
                    { "WIU", 17, "If Version Type is equal to ‘MOD’, this field indicates the type of music arrangement.  Values reside in the Music Arrangement Table.", "Music Arrangement ", "L", "C", "14", 3, 149 },
                    { "WIU", 18, "If Version Type is equal to ‘MOD’, this field indicates the type of lyric adaptation.  Values reside in the Lyric Adaptation Table.", "Lyric Adaptation", "L", "C", "15", 3, 152 },
                    { "WIU", 19, "The unique code used by the WI Center to identify this work.", "WI Code", "N", "C", "16,17,18,19", 10, 155 },
                    { "WIU", 20, "This field contains the date of the last update done on the corresponding Work in the legacy system  This field is mandatory/optional in case you use the CIS-Net Dataloader.", "Update date ", "N", "O", "", 8, 165 },
                    { "WIU", 21, "This date indicates the ' First sending date to CIS-Net'.. This field is mandatory/optional in case you use the CIS-Net Dataloader", "First sending date to CIS-Net", "N", "O", "", 8, 173 },
                    { "WIU", 9, "Original copyright number of the work.", "Copyright Number", "A", "O", "", 12, 115 },
                    { "WIU", 22, "This date indicates the 'Last sending date to CIS-Net '.  This field is mandatory/optional in case you use the CIS-Net Dataloader", "Last sending date to CIS-Net", "N", "O", "", 8, 181 },
                    { "SOC", 1, "Set Record Type = WIA (Work Information Add) for new registrations, WIU (Work Information Update) for revisions, or SOC (Society Notification)", "Record Type", "A", "M", "A", 3, 1 },
                    { "SOC", 2, "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "SOC", 3, "Always set to 00000000.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "SOC", 4, "Name/Title of the work.", "Work Title", "A", "M", "1", 60, 20 },
                    { "SOC", 5, "The Code representing the language of this title.  These values reside in the Language Code Table.", "Language Code", "L", "O", "2", 2, 80 },
                    { "SOC", 6, "Number assigned to the work by the party submitting the file.  This number must be unique for the submitter.  On files sent to the WID it is the society work #.  On SOC transactions it is the work # of the society that last submitted the work.", "Submitter Work #", "A", "M", "3", 14, 82 },
                    { "SOC", 7, "The preferred International Standard Work Code assigned to this work as confirmed by the CSI.", "ISWC", "A", "O", "4,18", 11, 96 },
                    { "SOC", 8, "Original copyright date of the work.", "Copyright Date", "D", "O", "5", 8, 107 },
                    { "SOC", 9, "Original copyright number of the work.", "Copyright Number", "A", "O", "", 12, 115 },
                    { "SOC", 10, "Describes the type of music as it applies to special distribution rules.  Values for this field reside in the Musical Work Distribution Category Table. ", "Musical Work Distribution Category", "L", "M", "6,7", 3, 127 },
                    { "SOC", 11, "Duration of the work in hours, minutes, and seconds.  This field must be greater than zero if Musical Work Distribution Category is equal to SER.  ", "Duration", "T", "C", "8", 6, 130 },
                    { "SOC", 12, "Indicates whether or not the work has ever been recorded.", "Recorded Indicator", "F", "M", "9", 1, 136 },
                    { "WIU", 23, "Indicates if it is a domestic work ('DOM') or an international work ('INT').  This field is required by the CIS-Net Data loader.", "Society Work type", "L", "C", "", 3, 189 },
                    { "WIU", 8, "Original copyright date of the work.", "Copyright Date", "D", "O", "5", 8, 107 },
                    { "WIU", 7, "The preferred International Standard Work Code assigned to this work as confirmed by the CSI.", "ISWC", "A", "O", "4,18", 11, 96 },
                    { "WIU", 6, "Number assigned to the work by the party submitting the file.  This number must be unique for the submitter.  On files sent to the WID it is the society work #.  On SOC transactions it is the work # of the society that last submitted the work.", "Submitter Work #", "A", "M", "3", 14, 82 },
                    { "WIA", 2, "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "WIA", 3, "Always set to 00000000.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "WIA", 4, "Name/Title of the work.", "Work Title", "A", "M", "1", 60, 20 },
                    { "WIA", 5, "The Code representing the language of this title.  These values reside in the Language Code Table.", "Language Code", "L", "O", "2", 2, 80 },
                    { "WIA", 6, "Number assigned to the work by the party submitting the file.  This number must be unique for the submitter.  On files sent to the WID it is the society work #.  On SOC transactions it is the work # of the society that last submitted the work.", "Submitter Work #", "A", "M", "3", 14, 82 },
                    { "WIA", 7, "The preferred International Standard Work Code assigned to this work as confirmed by the CSI.", "ISWC", "A", "O", "4,18", 11, 96 },
                    { "WIA", 8, "Original copyright date of the work.", "Copyright Date", "D", "O", "5", 8, 107 },
                    { "WIA", 9, "Original copyright number of the work.", "Copyright Number", "A", "O", "", 12, 115 },
                    { "WIA", 10, "Describes the type of music as it applies to special distribution rules.  Values for this field reside in the Musical Work Distribution Category Table. ", "Musical Work Distribution Category", "L", "M", "6,7", 3, 127 },
                    { "WIA", 11, "Duration of the work in hours, minutes, and seconds.  This field must be greater than zero if Musical Work Distribution Category is equal to SER.  ", "Duration", "T", "C", "8", 6, 130 },
                    { "WIA", 12, "Indicates whether or not the work has ever been recorded.", "Recorded Indicator", "F", "M", "9", 1, 136 },
                    { "WIA", 13, "Indicates whether this work contains music, text, and/or both.  Values are MTX = Both Music and Text, MUS = Music only, TXT = Text only.", "Text Music Relationship", "A", "O", "10", 3, 137 },
                    { "WIA", 14, "If this is a composite work, this field will indicate the type of composite.  Values reside in the Composite Type Table.", "Composite Type", "L", "O", "11", 3, 140 },
                    { "WIA", 15, "Indicates relationships between this work and other works.  Note that this field is used to indicate whether or not this work is an arrangement.  Values reside in the Version Type Table.", "Version Type", "L", "M", "12,14,15", 3, 143 },
                    { "WIA", 16, "If this is an excerpt, this field will indicate the type of excerpt.  Values reside in the Excerpt Type Table.", "Excerpt Type", "L", "O", "13", 3, 146 },
                    { "WIA", 17, "If Version Type is equal to ‘MOD’, this field indicates the type of music arrangement.  Values reside in the Music Arrangement Table.", "Music Arrangement ", "L", "C", "14", 3, 149 }
                });

            migrationBuilder.InsertData(
                table: "DscRecFields",
                columns: new[] { "RecTypeCode", "SeqNr", "Dsc", "Field", "Fmt", "Req", "Rules", "Size", "Start" },
                values: new object[,]
                {
                    { "WIA", 18, "If Version Type is equal to ‘MOD’, this field indicates the type of lyric adaptation.  Values reside in the Lyric Adaptation Table.", "Lyric Adaptation", "L", "C", "15", 3, 152 },
                    { "WIA", 19, "The unique code used by the WI Center to identify this work.", "WI Code", "N", "C", "16,17,18,19", 10, 155 },
                    { "WIA", 20, "This field contains the date of the last update done on the corresponding Work in the legacy system  This field is mandatory/optional in case you use the CIS-Net Dataloader.", "Update date ", "N", "O", "", 8, 165 },
                    { "WIA", 21, "This date indicates the ' First sending date to CIS-Net'.. This field is mandatory/optional in case you use the CIS-Net Dataloader", "First sending date to CIS-Net", "N", "O", "", 8, 173 },
                    { "WIA", 22, "This date indicates the 'Last sending date to CIS-Net '.  This field is mandatory/optional in case you use the CIS-Net Dataloader", "Last sending date to CIS-Net", "N", "O", "", 8, 181 },
                    { "WIA", 23, "Indicates if it is a domestic work ('DOM') or an international work ('INT').  This field is required by the CIS-Net Data loader.", "Society Work type", "L", "C", "", 3, 189 },
                    { "WIU", 1, "Set Record Type = WIA (Work Information Add) for new registrations, WIU (Work Information Update) for revisions, or SOC (Society Notification)", "Record Type", "A", "M", "A", 3, 1 },
                    { "WIU", 2, "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "WIU", 3, "Always set to 00000000.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "WIU", 4, "Name/Title of the work.", "Work Title", "A", "M", "1", 60, 20 },
                    { "WIU", 5, "The Code representing the language of this title.  These values reside in the Language Code Table.", "Language Code", "L", "O", "2", 2, 80 },
                    { "SOC", 13, "Indicates whether this work contains music, text, and/or both.  Values are MTX = Both Music and Text, MUS = Music only, TXT = Text only.", "Text Music Relationship", "A", "O", "10", 3, 137 },
                    { "MSG", 8, "Identifies the specific edit condition that generated this message.  Note that the combination of Record Type, Message Level, and Condition Number points back to a condition within this document.", "Condition Number", "A", "M", "", 3, 33 },
                    { "SOC", 14, "If this is a composite work, this field will indicate the type of composite.  Values reside in the Composite Type Table.", "Composite Type", "L", "O", "11", 3, 140 },
                    { "SOC", 16, "If this is an excerpt, this field will indicate the type of excerpt.  Values reside in the Excerpt Type Table.", "Excerpt Type", "L", "O", "13", 3, 146 },
                    { "RES", 6, "The type of right for which this conflict exists. These values reside on the Type of Right Table.", "Type of Right", "L", "M", "8", 3, 41 },
                    { "RES", 7, "The title of the work to be marked resolved.", "Work Title", "A", "M", "5", 60, 44 },
                    { "RES", 8, "The code representing the society that submitted this resolution.  These values reside on the Society Code Table.", "Society Code", "N", "M", "6", 3, 104 },
                    { "DEL", 1, "Set Record Type = DEL ", "Record Type", "A", "M", "A", 3, 1 },
                    { "DEL", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "DEL", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "DEL", 4, "Submitter Work # of work to delete. ", "Submitter Work #", "A", "M", "1,2", 14, 20 },
                    { "DEL", 5, "ISWC of work to delete.", "ISWC", "A", "O", "", 11, 34 },
                    { "DEL", 6, "WI Code of work to delete. ", "WIC ", "N", "O", "", 10, 45 },
                    { "DEL", 7, "Right type(s) controlled by submitter to delete. (PER, MEC or spaces).", "Right Type", "A", "O", "6", 3, 55 },
                    { "ACK", 1, "Set Record Type = ACK (Acknowledgment of Transaction)", "Record Type", "A", "M", "A", 3, 1 },
                    { "ACK", 2, "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "RES", 5, "WI Code of title to be marked resolved.  This field is required if ISWC is not entered.", "WI Code", "N", "C", "2,3,4,5", 10, 31 },
                    { "ACK", 3, "Always set to 00000000.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "ACK", 5, "The Creation Time of the original file that contained the transaction which this ACK applies to.", "Creation Time", "T", "M", "1,2", 6, 28 },
                    { "ACK", 6, "The Group Number within which the original transaction that this ACK applies to was located.  Note that if the ACK is a result of a HDR or TRL record problem, set this field to zeroes.", "Original Group Number", "N", "M", "2", 5, 34 },
                    { "ACK", 7, "The Transaction Sequence # of the original transaction that this ACK applies to. Note that if the ACK is a result of a HDR or TRL record problem, set this field to zeroes.", "Original Transaction Sequence #", "N", "M", "2", 8, 39 },
                    { "ACK", 8, "The Transaction Type of the original transaction that this ACK applies to. Note that if the ACK is a result of a HDR or TRL record problem, set this field to HDR or TRL (whichever is applicable).", "Original Transaction Type", "L", "M", "", 3, 47 },
                    { "ACK", 9, "The creation title as delivered by the submitter (i.e. the title of the musical work or audio visual production).  This field is required if the ACK is in response to a transaction.", "Creation Title", "A", "C", "4", 60, 50 },
                    { "ACK", 10, "The unique identifier assigned by the submitter to this work. This field is required if the ACK is in response to a transaction.", "Submitter Creation #", "A", "C", "4,5", 20, 110 },
                    { "ACK", 11, "The preferred ISWC assigned to this work as confirmed by the CSI.", "Recipient Creation #", "A", "O", "6", 20, 130 },
                    { "ACK", 12, "The date this transaction or file was formally processed by the recipient.", "Processing Date", "D", "M", "7", 8, 150 },
                    { "ACK", 13, "The current status of this transaction.  Values for this field reside in the Transaction Status Table.", "Transaction Status", "L", "M", "8", 2, 158 },
                    { "ISW", 1, "Set Record Type = ISW (Notification of Additional ISWC)", "Record Type", "A", "M", "A", 3, 1 },
                    { "ISW", 2, "The Transaction Sequence # of the previous transaction header.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "ISW", 3, "The Record Sequence # of the previous record written to the file incremented by 1.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "ACK", 4, "The Creation Date of the original file that contained the transaction which this ACK applies to.", "Creation Date", "D", "M", "1,2", 8, 20 }
                });

            migrationBuilder.InsertData(
                table: "DscRecFields",
                columns: new[] { "RecTypeCode", "SeqNr", "Dsc", "Field", "Fmt", "Req", "Rules", "Size", "Start" },
                values: new object[,]
                {
                    { "RES", 4, "ISWC of title to be marked resolved.  This field is required if WI Code is not entered.", "ISWC", "L", "C", "1,3,4,5", 11, 20 },
                    { "RES", 3, "Always set to 00000000.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "RES", 2, "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "SOC", 17, "If Version Type is equal to ‘MOD’, this field indicates the type of music arrangement.  Values reside in the Music Arrangement Table.", "Music Arrangement ", "L", "C", "14", 3, 149 },
                    { "SOC", 18, "If Version Type is equal to ‘MOD’, this field indicates the type of lyric adaptation.  Values reside in the Lyric Adaptation Table.", "Lyric Adaptation", "L", "C", "15", 3, 152 },
                    { "SOC", 19, "The unique code used by the WI Center to identify this work.", "WI Code", "N", "C", "16,17,18,19", 10, 155 },
                    { "SOC", 20, "This field contains the date of the last update done on the corresponding Work in the legacy system  This field is mandatory/optional in case you use the CIS-Net Dataloader.", "Update date ", "N", "O", "", 8, 165 },
                    { "SOC", 21, "This date indicates the ' First sending date to CIS-Net'.. This field is mandatory/optional in case you use the CIS-Net Dataloader", "First sending date to CIS-Net", "N", "O", "", 8, 173 },
                    { "SOC", 22, "This date indicates the 'Last sending date to CIS-Net '.  This field is mandatory/optional in case you use the CIS-Net Dataloader", "Last sending date to CIS-Net", "N", "O", "", 8, 181 },
                    { "SOC", 23, "Indicates if it is a domestic work ('DOM') or an international work ('INT').  This field is required by the CIS-Net Data loader.", "Society Work type", "L", "C", "", 3, 189 },
                    { "TTU", 1, "Set Record Type = TTU (Work Title Update)", "Record Type", "A", "M", "A", 3, 1 },
                    { "TTU", 2, "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "TTU", 3, "Always set to 00000000.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "TTU", 4, "ISWC of title to be changed.  This field is required if WI Code is not entered.", "ISWC", "L", "C", "1,3,5", 11, 20 },
                    { "TTU", 5, "WI Code of title to be changed.  This field is required if ISWC is not entered.", "WI Code", "N", "C", "2,3,5", 10, 31 },
                    { "TTU", 6, "The original title of the work.", "Original Work Title", "A", "M", "5", 60, 41 },
                    { "TTU", 7, "The new title of the work", "New Work Title", "A", "M", "6", 60, 101 },
                    { "CON", 1, "Set Record Type = CON (Conflict Notification)", "Record Type", "A", "M", "A", 3, 1 },
                    { "CON", 2, "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.", "Transaction Sequence #", "N", "M", "B,C,D,G,H", 8, 4 },
                    { "CON", 3, "Always set to 00000000.", "Record Sequence #", "N", "M", "E,F", 8, 12 },
                    { "CON", 4, "ISWC of title to be marked in conflict.  This field is required if WI Code is not entered.", "ISWC", "L", "C", "1,3,4", 11, 20 },
                    { "CON", 5, "WI Code of title to be marked in conflict.  This field is required if ISWC is not entered.", "WI Code", "N", "C", "2,3,4", 10, 31 },
                    { "CON", 6, "The reason that this work is being marked in conflict.  Values for this field reside in the Conflict Reason Code Table.", "Conflict Reason Code", "L", "M", "7", 3, 41 },
                    { "CON", 7, "The type of right for which this conflict exists. These values reside on the Type of Right Table.", "Type of Right", "L", "M", "6", 3, 44 },
                    { "CON", 8, "The title of the work to be marked in conflict.", "Work Title", "A", "M", "5", 60, 47 },
                    { "CON", 9, "A description of the issue creating the conflict.", "Conflict Note", "A", "O", "", 60, 107 },
                    { "CON", 10, "The name of a business contact person at the organization that originated this transaction.", "Contact Name", "A", "O", "8", 30, 167 },
                    { "CON", 11, "An identifier associated with the contact person at the organization that originated this transaction.", "Contact ID", "A", "O", "", 10, 197 },
                    { "CON", 12, "The code representing the society that submitted this conflict.  These values reside on the Society Code Table.", "Society Code", "N", "M", "9", 3, 207 },
                    { "RES", 1, "Set Record Type = RES (Conflict Resolution)", "Record Type", "A", "M", "A", 3, 1 },
                    { "SOC", 15, "Indicates relationships between this work and other works.  Note that this field is used to indicate whether or not this work is an arrangement.  Values reside in the Version Type Table.", "Version Type", "L", "M", "12,14,15", 3, 143 },
                    { "MSG", 9, "The text associated with this message.", "Message Text", "A", "M", "4", 150, 36 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecAck_UpdFileId",
                table: "RecAck",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecAlt_UpdFileId",
                table: "RecAlt",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecCom_UpdFileId",
                table: "RecCom",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecCon_UpdFileId",
                table: "RecCon",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecDel_UpdFileId",
                table: "RecDel",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecEwt_UpdFileId",
                table: "RecEwt",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecInd_UpdFileId",
                table: "RecInd",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecIns_UpdFileId",
                table: "RecIns",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecIsw_UpdFileId",
                table: "RecIsw",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecLnk_UpdFileId",
                table: "RecLnk",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecMsg_UpdFileId",
                table: "RecMsg",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecOip_UpdFileId",
                table: "RecOip",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecOrn_UpdFileId",
                table: "RecOrn",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecOsr_UpdFileId",
                table: "RecOsr",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecPer_UpdFileId",
                table: "RecPer",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecRes_UpdFileId",
                table: "RecRes",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecSip_UpdFileId",
                table: "RecSip",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecSoc_UpdFileId",
                table: "RecSoc",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecSsr_UpdFileId",
                table: "RecSsr",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecTtu_UpdFileId",
                table: "RecTtu",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecVer_UpdFileId",
                table: "RecVer",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecWia_UpdFileId",
                table: "RecWia",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecWiu_UpdFileId",
                table: "RecWiu",
                column: "UpdFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecWpl_UpdFileId",
                table: "RecWpl",
                column: "UpdFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DscFieldColNames");

            migrationBuilder.DropTable(
                name: "DscFmtInfo");

            migrationBuilder.DropTable(
                name: "DscRecFields");

            migrationBuilder.DropTable(
                name: "RecAck");

            migrationBuilder.DropTable(
                name: "RecAlt");

            migrationBuilder.DropTable(
                name: "RecCom");

            migrationBuilder.DropTable(
                name: "RecCon");

            migrationBuilder.DropTable(
                name: "RecDel");

            migrationBuilder.DropTable(
                name: "RecEwt");

            migrationBuilder.DropTable(
                name: "RecInd");

            migrationBuilder.DropTable(
                name: "RecIns");

            migrationBuilder.DropTable(
                name: "RecIsw");

            migrationBuilder.DropTable(
                name: "RecLnk");

            migrationBuilder.DropTable(
                name: "RecMsg");

            migrationBuilder.DropTable(
                name: "RecOip");

            migrationBuilder.DropTable(
                name: "RecOrn");

            migrationBuilder.DropTable(
                name: "RecOsr");

            migrationBuilder.DropTable(
                name: "RecPer");

            migrationBuilder.DropTable(
                name: "RecRes");

            migrationBuilder.DropTable(
                name: "RecSip");

            migrationBuilder.DropTable(
                name: "RecSoc");

            migrationBuilder.DropTable(
                name: "RecSsr");

            migrationBuilder.DropTable(
                name: "RecTtu");

            migrationBuilder.DropTable(
                name: "RecVer");

            migrationBuilder.DropTable(
                name: "RecWia");

            migrationBuilder.DropTable(
                name: "RecWiu");

            migrationBuilder.DropTable(
                name: "RecWpl");

            migrationBuilder.DropTable(
                name: "WrkAffectedRecords");

            migrationBuilder.DropTable(
                name: "DscRecTypes");

            migrationBuilder.DropTable(
                name: "UpdFiles");
        }
    }
}

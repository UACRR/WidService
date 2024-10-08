using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WidAdminLib.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WidConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    WidFtpUrl = table.Column<string>(type: "varchar(1024)", nullable: true),
                    WidFtpLogin = table.Column<string>(type: "varchar(64)", nullable: true),
                    WidFtpPassword = table.Column<string>(type: "varchar(64)", nullable: true),
                    WidFtpDumpPath = table.Column<string>(type: "varchar(1024)", nullable: true),
                    WidFtpUpdatesPath = table.Column<string>(type: "varchar(1024)", nullable: true),
                    WidWorkFilesRootPath = table.Column<string>(type: "varchar(1024)", nullable: true),
                    IpiFtpUrl = table.Column<string>(type: "varchar(1024)", nullable: true),
                    IpiFtpLogin = table.Column<string>(type: "varchar(64)", nullable: true),
                    IpiFtpPassword = table.Column<string>(type: "varchar(64)", nullable: true),
                    IpiFtpDumpPath = table.Column<string>(type: "varchar(1024)", nullable: true),
                    IpiFtpUpdatesPath = table.Column<string>(type: "varchar(1024)", nullable: true),
                    IpiWorkFilesRootPath = table.Column<string>(type: "varchar(1024)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WidTaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidTaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WidTaskSubjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(32)", nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidTaskSubjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WidTaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(32)", nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidTaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WidUpdatePeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WidTaskStatusId = table.Column<int>(type: "int", nullable: false),
                    WidDumpTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    NewWidDumpTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    WidDumpFilesTotalSize = table.Column<long>(type: "bigint", nullable: false),
                    NewWidDumpFilesTotalSize = table.Column<long>(type: "bigint", nullable: false),
                    IpiDumpTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    NewIpiDumpTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidUpdatePeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidUpdatePeriods_WidTaskStatuses_WidTaskStatusId",
                        column: x => x.WidTaskStatusId,
                        principalTable: "WidTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WidTaskSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WidUpdatePeriodId = table.Column<int>(type: "int", nullable: false),
                    WidTaskSubjectTypeId = table.Column<int>(type: "int", nullable: false),
                    WidTaskStatusId = table.Column<int>(type: "int", nullable: false),
                    Db = table.Column<string>(type: "varchar(3)", nullable: true),
                    TasksDate = table.Column<DateTime>(type: "date", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidTaskSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidTaskSubjects_WidTaskStatuses_WidTaskStatusId",
                        column: x => x.WidTaskStatusId,
                        principalTable: "WidTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WidTaskSubjects_WidTaskTypes_WidTaskSubjectTypeId",
                        column: x => x.WidTaskSubjectTypeId,
                        principalTable: "WidTaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WidTaskSubjects_WidUpdatePeriods_WidUpdatePeriodId",
                        column: x => x.WidUpdatePeriodId,
                        principalTable: "WidUpdatePeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidTaskObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WidTaskSubjectId = table.Column<int>(type: "int", nullable: false),
                    WidTaskStatusId = table.Column<int>(type: "int", nullable: false),
                    ObjectInfo = table.Column<string>(type: "varchar(64)", nullable: true),
                    ObjectFileTs = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidTaskObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidTaskObjects_WidTaskStatuses_WidTaskStatusId",
                        column: x => x.WidTaskStatusId,
                        principalTable: "WidTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WidTaskObjects_WidTaskSubjects_WidTaskSubjectId",
                        column: x => x.WidTaskSubjectId,
                        principalTable: "WidTaskSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WidTaskObjectId = table.Column<int>(type: "int", nullable: false),
                    WidTaskTypeId = table.Column<int>(type: "int", nullable: false),
                    WidTaskStatusId = table.Column<int>(type: "int", nullable: false),
                    PrevWidTaskId = table.Column<int>(type: "int", nullable: true),
                    NextWidTaskId = table.Column<int>(type: "int", nullable: true),
                    PercentDone = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastTransLineIdx = table.Column<int>(type: "int", nullable: true),
                    ErrMsg = table.Column<string>(type: "varchar(1024)", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    WidConfigurationEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidTasks_WidConfigurations_WidConfigurationEntityId",
                        column: x => x.WidConfigurationEntityId,
                        principalTable: "WidConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidTasks_WidTaskObjects_WidTaskObjectId",
                        column: x => x.WidTaskObjectId,
                        principalTable: "WidTaskObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidTasks_WidTasks_PrevWidTaskId",
                        column: x => x.PrevWidTaskId,
                        principalTable: "WidTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidTasks_WidTaskStatuses_WidTaskStatusId",
                        column: x => x.WidTaskStatusId,
                        principalTable: "WidTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WidTasks_WidTaskTypes_WidTaskTypeId",
                        column: x => x.WidTaskTypeId,
                        principalTable: "WidTaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WidConfigurations",
                columns: new[] { "Id", "CreatedAt", "IpiFtpDumpPath", "IpiFtpLogin", "IpiFtpPassword", "IpiFtpUpdatesPath", "IpiFtpUrl", "IpiWorkFilesRootPath", "Name", "UpdatedAt", "WidFtpDumpPath", "WidFtpLogin", "WidFtpPassword", "WidFtpUpdatesPath", "WidFtpUrl", "WidWorkFilesRootPath" },
                values: new object[] { 1, new DateTime(2022, 9, 15, 23, 17, 58, 526, DateTimeKind.Local).AddTicks(3343), "IPI/IPI_Pub/Complete_IPI", "UACRR", "0RvLrb0M", "IPI/download", "ftp://ftp.suisa.ch", "D:\\UACRR\\WID\\ReplicationWorkFiles\\Ipi", "Development environment", new DateTime(2022, 9, 15, 23, 17, 58, 528, DateTimeKind.Local).AddTicks(3529), "wid-dump", "wid_140", "ad1WropKoPhlyb", "outbox/SOC", "ftp://ftp-aws.fasttrackdcn.net", "D:\\UACRR\\WID\\ReplicationWorkFiles\\Wid" });

            migrationBuilder.InsertData(
                table: "WidTaskStatuses",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "Pending", "Очікує початку виконання" },
                    { 2, "InProgress", "Виконується" },
                    { 3, "Completed", "Завершено" },
                    { 4, "Failed", "Перервано внаслідок помилок" }
                });

            migrationBuilder.InsertData(
                table: "WidTaskSubjectTypes",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 6, "UpdateFromNewDump", "Внесення змін в базу на основі нового дампу" },
                    { 4, "InitNewDump", "Заповнення проміжної бази інформацією з нового дампу" },
                    { 5, "CalcNewDumpTs", "Знайти дату нового дампу" },
                    { 2, "CalcInitDumpTs", "Знайти дату початкового дампу" },
                    { 1, "InitFromDump", "Створення початкової бази з дампу" },
                    { 3, "UpdateFromTranFiles", "Внесення змін в базу на основі файлів транзакцій" }
                });

            migrationBuilder.InsertData(
                table: "WidTaskTypes",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 8, "TableApplyToSocDb", "Створити копію файлу змін в базі даних" },
                    { 1, "FileDownload", "Завантажити файл з FTP" },
                    { 2, "FileUnzip", "Розпакувати файл" },
                    { 3, "FileZipDelete", "Видалити файл архіву" },
                    { 4, "FileApplyToDb", "Обробити файл" },
                    { 5, "FileDelete", "Видалити файл" },
                    { 6, "CalcWidDumpTs", "Знайти дату останньої зміни в таблицях дампу" },
                    { 7, "TableApplyToDb", "Застосувати інформацію з таблиці нового дампу" },
                    { 9, "CreateHistRecords", "Створити історичні записи" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WidTaskObjects_WidTaskStatusId",
                table: "WidTaskObjects",
                column: "WidTaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTaskObjects_WidTaskSubjectId",
                table: "WidTaskObjects",
                column: "WidTaskSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTasks_PrevWidTaskId",
                table: "WidTasks",
                column: "PrevWidTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTasks_WidConfigurationEntityId",
                table: "WidTasks",
                column: "WidConfigurationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTasks_WidTaskObjectId",
                table: "WidTasks",
                column: "WidTaskObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTasks_WidTaskStatusId",
                table: "WidTasks",
                column: "WidTaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTasks_WidTaskTypeId",
                table: "WidTasks",
                column: "WidTaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTaskSubjects_WidTaskStatusId",
                table: "WidTaskSubjects",
                column: "WidTaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTaskSubjects_WidTaskSubjectTypeId",
                table: "WidTaskSubjects",
                column: "WidTaskSubjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WidTaskSubjects_WidUpdatePeriodId",
                table: "WidTaskSubjects",
                column: "WidUpdatePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_WidUpdatePeriods_WidTaskStatusId",
                table: "WidUpdatePeriods",
                column: "WidTaskStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WidTasks");

            migrationBuilder.DropTable(
                name: "WidTaskSubjectTypes");

            migrationBuilder.DropTable(
                name: "WidConfigurations");

            migrationBuilder.DropTable(
                name: "WidTaskObjects");

            migrationBuilder.DropTable(
                name: "WidTaskSubjects");

            migrationBuilder.DropTable(
                name: "WidTaskTypes");

            migrationBuilder.DropTable(
                name: "WidUpdatePeriods");

            migrationBuilder.DropTable(
                name: "WidTaskStatuses");
        }
    }
}

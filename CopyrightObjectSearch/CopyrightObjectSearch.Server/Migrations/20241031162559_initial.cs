using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CopyrightObjectSearch.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(32)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorkAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorkAlbums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorkAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorkAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorkIswcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorkIswcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorkNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorkNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorkPerformers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorkPerformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorkSourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(32)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorkSourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(32)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TmpSelectedIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "varchar(36)", nullable: false),
                    SelectedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmpSelectedIds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    PasswordHash = table.Column<string>(type: "char(256)", nullable: false),
                    IsPwdDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsSuperUser = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(32)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(32)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    NameId = table.Column<int>(type: "int", nullable: false),
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    PerformersId = table.Column<int>(type: "int", nullable: false),
                    IswcId = table.Column<int>(type: "int", nullable: false),
                    FoundObjId = table.Column<int>(type: "int", nullable: false),
                    FoundWic = table.Column<int>(type: "int", nullable: false),
                    FoundIswc = table.Column<string>(type: "varchar(13)", nullable: false),
                    FoundVia = table.Column<string>(type: "varchar(8)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerWorks_PartnerWorkAlbums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "PartnerWorkAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerWorks_PartnerWorkAuthors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "PartnerWorkAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerWorks_PartnerWorkIswcs_IswcId",
                        column: x => x.IswcId,
                        principalTable: "PartnerWorkIswcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerWorks_PartnerWorkNames_NameId",
                        column: x => x.NameId,
                        principalTable: "PartnerWorkNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerWorks_PartnerWorkPerformers_PerformersId",
                        column: x => x.PerformersId,
                        principalTable: "PartnerWorkPerformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorkSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(266)", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    SourceTypeId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorkSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerWorkSources_PartnerWorkSourceTypes_SourceTypeId",
                        column: x => x.SourceTypeId,
                        principalTable: "PartnerWorkSourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerWorkSources_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartnerWorkToSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerWorkSourceId = table.Column<int>(type: "int", nullable: false),
                    ParnterWorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerWorkToSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerWorkToSources_PartnerWorkSources_PartnerWorkSourceId",
                        column: x => x.PartnerWorkSourceId,
                        principalTable: "PartnerWorkSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerWorkToSources_PartnerWorks_ParnterWorkId",
                        column: x => x.ParnterWorkId,
                        principalTable: "PartnerWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(266)", nullable: false),
                    UserTaskTypeId = table.Column<int>(type: "int", nullable: false),
                    PartnerWorkSourceId = table.Column<int>(type: "int", nullable: false),
                    AssignedUserId = table.Column<int>(type: "int", nullable: false),
                    PartnerWorksRange = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTasks_PartnerWorkSources_PartnerWorkSourceId",
                        column: x => x.PartnerWorkSourceId,
                        principalTable: "PartnerWorkSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTasks_UserTaskType_UserTaskTypeId",
                        column: x => x.UserTaskTypeId,
                        principalTable: "UserTaskType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTaskId = table.Column<int>(type: "int", nullable: false),
                    PartnerWorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTaskItems_PartnerWorks_PartnerWorkId",
                        column: x => x.PartnerWorkId,
                        principalTable: "PartnerWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTaskItems_UserTasks_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "UserTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PartnerWorkSourceTypes",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "YouTubeAdv", "Звіт про прибуток за рекламу" },
                    { 2, "YouTubeMusic", "Звіт про прибуток за підписку" },
                    { 3, "YouTubePemium", "Звіт про прибуток за преміальну підписку" },
                    { 4, "YouTubePreClaim", "Попередній звіт" },
                    { 5, "SpotifyFree", "Звіт про прибуток за рекламу" },
                    { 6, "SpotifySubscr", "Звіт про прибуток за підписку" },
                    { 7, "DeezerAll", "Всі звіти" },
                    { 8, "RadioStationReport", "Звіт від радіо" }
                });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "Google", "Google" },
                    { 2, "Spotify", "Spotify" },
                    { 3, "Deezer", "Deezer" },
                    { 4, "RadioStation", "Українське радіо" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "UserAdmin", "Адміністратор користувачів" },
                    { 2, "TaskAdmin", "Адміністратор завдань" },
                    { 3, "TaskOperator", "Виконавець завдань" }
                });

            migrationBuilder.InsertData(
                table: "UserTaskStatuses",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "New", "Нова" },
                    { 2, "Assigned", "Запланована" },
                    { 3, "InProgress", "В роботі" },
                    { 4, "Completed", "Завершена" }
                });

            migrationBuilder.InsertData(
                table: "UserTaskType",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "SeachSocWork", "Пошук творів товариства" },
                    { 2, "SearchPartnerWork", "Пошук творів партнерів" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_AlbumId",
                table: "PartnerWorks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_AuthorsId",
                table: "PartnerWorks",
                column: "AuthorsId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_IswcId",
                table: "PartnerWorks",
                column: "IswcId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_NameId",
                table: "PartnerWorks",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_NameId_AuthorsId_PerformersId_IswcId",
                table: "PartnerWorks",
                columns: new[] { "NameId", "AuthorsId", "PerformersId", "IswcId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorks_PerformersId",
                table: "PartnerWorks",
                column: "PerformersId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorkSources_PartnerId",
                table: "PartnerWorkSources",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorkSources_SourceTypeId",
                table: "PartnerWorkSources",
                column: "SourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorkToSources_ParnterWorkId",
                table: "PartnerWorkToSources",
                column: "ParnterWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerWorkToSources_PartnerWorkSourceId",
                table: "PartnerWorkToSources",
                column: "PartnerWorkSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskItems_PartnerWorkId",
                table: "UserTaskItems",
                column: "PartnerWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskItems_UserTaskId",
                table: "UserTaskItems",
                column: "UserTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AssignedUserId",
                table: "UserTasks",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_PartnerWorkSourceId",
                table: "UserTasks",
                column: "PartnerWorkSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserTaskTypeId",
                table: "UserTasks",
                column: "UserTaskTypeId");

            var programmabilityBuilder = new ProgrammabilityBuilder(migrationBuilder);
            programmabilityBuilder.Run();

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerWorkToSources");

            migrationBuilder.DropTable(
                name: "TmpSelectedIds");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTaskItems");

            migrationBuilder.DropTable(
                name: "UserTaskStatuses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "PartnerWorks");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "PartnerWorkAlbums");

            migrationBuilder.DropTable(
                name: "PartnerWorkAuthors");

            migrationBuilder.DropTable(
                name: "PartnerWorkIswcs");

            migrationBuilder.DropTable(
                name: "PartnerWorkNames");

            migrationBuilder.DropTable(
                name: "PartnerWorkPerformers");

            migrationBuilder.DropTable(
                name: "PartnerWorkSources");

            migrationBuilder.DropTable(
                name: "UserTaskType");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PartnerWorkSourceTypes");

            migrationBuilder.DropTable(
                name: "Partners");
        }
    }
}

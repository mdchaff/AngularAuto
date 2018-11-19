using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace angularAutoSite.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AngAutos",
                columns: table => new
                {
                    AngAuto_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    projectName = table.Column<string>(nullable: true),
                    thePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngAutos", x => x.AngAuto_ID);
                });

            migrationBuilder.CreateTable(
                name: "Installs",
                columns: table => new
                {
                    Install_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AngAuto_ID = table.Column<int>(nullable: false),
                    TheInstall = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installs", x => x.Install_ID);
                    table.ForeignKey(
                        name: "FK_Installs_AngAutos_AngAuto_ID",
                        column: x => x.AngAuto_ID,
                        principalTable: "AngAutos",
                        principalColumn: "AngAuto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installs_AngAuto_ID",
                table: "Installs",
                column: "AngAuto_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installs");

            migrationBuilder.DropTable(
                name: "AngAutos");
        }
    }
}

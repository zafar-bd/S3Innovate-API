using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace S3Inovate.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Location = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataFields",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataFields", x => x.Id);
                    table.UniqueConstraint("AK_DataFields_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.Id);
                    table.UniqueConstraint("AK_Objects_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    BuildingId = table.Column<short>(type: "smallint", nullable: false),
                    ObjectId = table.Column<byte>(type: "tinyint", nullable: false),
                    DataFieldId = table.Column<byte>(type: "tinyint", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => new { x.BuildingId, x.ObjectId, x.DataFieldId });
                    table.ForeignKey(
                        name: "FK_Readings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Readings_DataFields_DataFieldId",
                        column: x => x.DataFieldId,
                        principalTable: "DataFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Readings_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_Location_Name",
                table: "Buildings",
                columns: new[] { "Location", "Name" },
                unique: true,
                filter: "[Location] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_DataFieldId",
                table: "Readings",
                column: "DataFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_ObjectId",
                table: "Readings",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_Timestamp",
                table: "Readings",
                column: "Timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "DataFields");

            migrationBuilder.DropTable(
                name: "Objects");
        }
    }
}

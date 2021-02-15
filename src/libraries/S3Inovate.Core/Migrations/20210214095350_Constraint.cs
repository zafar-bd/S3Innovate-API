using Microsoft.EntityFrameworkCore.Migrations;

namespace S3Inovate.Core.Migrations
{
    public partial class Constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Readings",
                table: "Readings");

            migrationBuilder.DropIndex(
                name: "IX_Readings_Timestamp",
                table: "Readings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Readings",
                table: "Readings",
                columns: new[] { "BuildingId", "ObjectId", "DataFieldId", "Timestamp" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Readings",
                table: "Readings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Readings",
                table: "Readings",
                columns: new[] { "BuildingId", "ObjectId", "DataFieldId" });

            migrationBuilder.CreateIndex(
                name: "IX_Readings_Timestamp",
                table: "Readings",
                column: "Timestamp");
        }
    }
}

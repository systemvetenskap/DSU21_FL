using Microsoft.EntityFrameworkCore.Migrations;

namespace DSU21.Migrations
{
    public partial class captain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PirateId",
                table: "Ships",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_PirateId",
                table: "Ships",
                column: "PirateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_Pirates_PirateId",
                table: "Ships",
                column: "PirateId",
                principalTable: "Pirates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_Pirates_PirateId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_PirateId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "PirateId",
                table: "Ships");
        }
    }
}

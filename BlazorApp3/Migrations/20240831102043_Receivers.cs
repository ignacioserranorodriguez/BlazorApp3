using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp3.Migrations
{
    /// <inheritdoc />
    public partial class Receivers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransmitterId",
                table: "Device",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Device_TransmitterId",
                table: "Device",
                column: "TransmitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Device_TransmitterId",
                table: "Device",
                column: "TransmitterId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Device_TransmitterId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_TransmitterId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "TransmitterId",
                table: "Device");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom13.Migrations
{
    /// <inheritdoc />
    public partial class Khachhang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiachiNV",
                table: "Khachhang",
                newName: "DiachiKH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiachiKH",
                table: "Khachhang",
                newName: "DiachiNV");
        }
    }
}

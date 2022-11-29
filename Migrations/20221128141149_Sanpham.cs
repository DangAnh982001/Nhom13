using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom13.Migrations
{
    /// <inheritdoc />
    public partial class Sanpham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "TEXT", nullable: false),
                    TenSP = table.Column<string>(type: "TEXT", nullable: true),
                    GiaSP = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.MaSP);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sanpham");
        }
    }
}

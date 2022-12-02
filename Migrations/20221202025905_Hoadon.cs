using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom13.Migrations
{
    /// <inheritdoc />
    public partial class Hoadon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hoadon",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "TEXT", nullable: false),
                    TenKH = table.Column<string>(type: "TEXT", nullable: true),
                    TenSP = table.Column<string>(type: "TEXT", nullable: true),
                    SoluongHD = table.Column<int>(type: "INTEGER", nullable: false),
                    Ngayban = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadon", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_Hoadon_Khachhang_TenKH",
                        column: x => x.TenKH,
                        principalTable: "Khachhang",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK_Hoadon_Sanpham_TenSP",
                        column: x => x.TenSP,
                        principalTable: "Sanpham",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hoadon_TenKH",
                table: "Hoadon",
                column: "TenKH");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadon_TenSP",
                table: "Hoadon",
                column: "TenSP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hoadon");
        }
    }
}

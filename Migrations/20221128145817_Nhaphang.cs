using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom13.Migrations
{
    /// <inheritdoc />
    public partial class Nhaphang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhaphang",
                columns: table => new
                {
                    IDNH = table.Column<string>(type: "TEXT", nullable: false),
                    TenSP = table.Column<string>(type: "TEXT", nullable: true),
                    SoluongSP = table.Column<string>(type: "TEXT", nullable: true),
                    TenNCC = table.Column<string>(type: "TEXT", nullable: true),
                    TenNV = table.Column<string>(type: "TEXT", nullable: true),
                    NgaynhapSP = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhaphang", x => x.IDNH);
                    table.ForeignKey(
                        name: "FK_Nhaphang_Nhacungcap_TenNCC",
                        column: x => x.TenNCC,
                        principalTable: "Nhacungcap",
                        principalColumn: "MaNCC");
                    table.ForeignKey(
                        name: "FK_Nhaphang_Nhanvien_TenNV",
                        column: x => x.TenNV,
                        principalTable: "Nhanvien",
                        principalColumn: "MaNV");
                    table.ForeignKey(
                        name: "FK_Nhaphang_Sanpham_TenSP",
                        column: x => x.TenSP,
                        principalTable: "Sanpham",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nhaphang_TenNCC",
                table: "Nhaphang",
                column: "TenNCC");

            migrationBuilder.CreateIndex(
                name: "IX_Nhaphang_TenNV",
                table: "Nhaphang",
                column: "TenNV");

            migrationBuilder.CreateIndex(
                name: "IX_Nhaphang_TenSP",
                table: "Nhaphang",
                column: "TenSP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhaphang");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom13.Migrations
{
    /// <inheritdoc />
    public partial class Nhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhanvien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: true),
                    NgaysinhNV = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SdtNV = table.Column<string>(type: "TEXT", nullable: true),
                    DiachiNV = table.Column<string>(type: "TEXT", nullable: true),
                    EmailNV = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanvien", x => x.MaNV);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhanvien");
        }
    }
}

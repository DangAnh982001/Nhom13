using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom13.Migrations
{
    /// <inheritdoc />
    public partial class Nhacungcap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhacungcap",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "TEXT", nullable: false),
                    TenNCC = table.Column<string>(type: "TEXT", nullable: true),
                    SdtNCC = table.Column<string>(type: "TEXT", nullable: true),
                    DiachiNCC = table.Column<string>(type: "TEXT", nullable: true),
                    EmailNCC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhacungcap", x => x.MaNCC);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhacungcap");
        }
    }
}

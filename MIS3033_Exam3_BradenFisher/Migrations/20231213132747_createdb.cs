using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS3033_Exam3_BradenFisher.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Subtotal = table.Column<double>(type: "double precision", nullable: false),
                    Tip = table.Column<double>(type: "double precision", nullable: false),
                    TipRatio = table.Column<double>(type: "double precision", nullable: false),
                    TipRatioLevel = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

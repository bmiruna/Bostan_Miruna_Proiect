using Microsoft.EntityFrameworkCore.Migrations;

namespace Bostan_Miruna_Proiect.Migrations
{
    public partial class Makes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeID",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_MakeID",
                table: "Product",
                column: "MakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Make_MakeID",
                table: "Product",
                column: "MakeID",
                principalTable: "Make",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Make_MakeID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropIndex(
                name: "IX_Product_MakeID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "Product");
        }
    }
}

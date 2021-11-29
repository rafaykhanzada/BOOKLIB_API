using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLIB_API.Migrations
{
    public partial class book_ret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblReturnRecord_Bk_ID",
                table: "tblReturnRecord",
                column: "Bk_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReturnRecord_tblBook_Bk_ID",
                table: "tblReturnRecord",
                column: "Bk_ID",
                principalTable: "tblBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReturnRecord_tblBook_Bk_ID",
                table: "tblReturnRecord");

            migrationBuilder.DropIndex(
                name: "IX_tblReturnRecord_Bk_ID",
                table: "tblReturnRecord");
        }
    }
}

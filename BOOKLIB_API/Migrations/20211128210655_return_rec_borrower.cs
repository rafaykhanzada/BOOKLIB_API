using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLIB_API.Migrations
{
    public partial class return_rec_borrower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblReturnRecord_Borrower_ID",
                table: "tblReturnRecord",
                column: "Borrower_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReturnRecord_tblBorrower_Borrower_ID",
                table: "tblReturnRecord",
                column: "Borrower_ID",
                principalTable: "tblBorrower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReturnRecord_tblBorrower_Borrower_ID",
                table: "tblReturnRecord");

            migrationBuilder.DropIndex(
                name: "IX_tblReturnRecord_Borrower_ID",
                table: "tblReturnRecord");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLIB_API.Migrations
{
    public partial class return_rec_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "User_ID",
                table: "tblReturnRecord",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblReturnRecord_User_ID",
                table: "tblReturnRecord",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReturnRecord_tblUser_User_ID",
                table: "tblReturnRecord",
                column: "User_ID",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReturnRecord_tblUser_User_ID",
                table: "tblReturnRecord");

            migrationBuilder.DropIndex(
                name: "IX_tblReturnRecord_User_ID",
                table: "tblReturnRecord");

            migrationBuilder.AlterColumn<string>(
                name: "User_ID",
                table: "tblReturnRecord",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLIB_API.Migrations
{
    public partial class borrower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bk_Copies",
                table: "tblBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Bk_Cost",
                table: "tblBook",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Bk_Edition",
                table: "tblBook",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblBorrower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bk_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Bk_Copies = table.Column<int>(type: "int", nullable: false),
                    Release_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBorrower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblBorrower_tblBook_Bk_ID",
                        column: x => x.Bk_ID,
                        principalTable: "tblBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblBorrower_tblUser_User_ID",
                        column: x => x.User_ID,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblBorrower_Bk_ID",
                table: "tblBorrower",
                column: "Bk_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tblBorrower_User_ID",
                table: "tblBorrower",
                column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBorrower");

            migrationBuilder.DropColumn(
                name: "Bk_Copies",
                table: "tblBook");

            migrationBuilder.DropColumn(
                name: "Bk_Cost",
                table: "tblBook");

            migrationBuilder.DropColumn(
                name: "Bk_Edition",
                table: "tblBook");
        }
    }
}

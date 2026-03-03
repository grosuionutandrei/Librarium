using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librarium.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Members_MemberEmail",
                table: "Loans");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "MemberDto",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberDto", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    AuthorsAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BooksDtoIsbn = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.AuthorsAuthorId, x.BooksDtoIsbn });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorsAuthorId",
                        column: x => x.AuthorsAuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BooksDtoIsbn",
                        column: x => x.BooksDtoIsbn,
                        principalTable: "Books",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BooksDtoIsbn",
                table: "BookAuthors",
                column: "BooksDtoIsbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_MemberDto_MemberEmail",
                table: "Loans",
                column: "MemberEmail",
                principalTable: "MemberDto",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_MemberDto_MemberEmail",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "MemberDto");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Members_MemberEmail",
                table: "Loans",
                column: "MemberEmail",
                principalTable: "Members",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

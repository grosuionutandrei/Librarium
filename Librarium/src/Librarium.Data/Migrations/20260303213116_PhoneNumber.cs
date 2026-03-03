using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librarium.Data.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_MemberDto_MemberEmail",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "MemberDto");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Members",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Members_MemberEmail",
                table: "Loans",
                column: "MemberEmail",
                principalTable: "Members",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Members_MemberEmail",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Members");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_MemberDto_MemberEmail",
                table: "Loans",
                column: "MemberEmail",
                principalTable: "MemberDto",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

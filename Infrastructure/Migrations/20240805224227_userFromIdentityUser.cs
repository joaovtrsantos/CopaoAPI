using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userFromIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_CaptainId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeam_User_UserId",
                table: "UserTeam");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_UserTeam_UserId",
                table: "UserTeam");

            migrationBuilder.DropIndex(
                name: "IX_Team_CaptainId",
                table: "Team");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "UserTeam",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CaptainId1",
                table: "Team",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Elo",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nick",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Pix",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTeam_UsuarioId",
                table: "UserTeam",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CaptainId1",
                table: "Team",
                column: "CaptainId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_AspNetUsers_CaptainId1",
                table: "Team",
                column: "CaptainId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeam_AspNetUsers_UsuarioId",
                table: "UserTeam",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_AspNetUsers_CaptainId1",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeam_AspNetUsers_UsuarioId",
                table: "UserTeam");

            migrationBuilder.DropIndex(
                name: "IX_UserTeam_UsuarioId",
                table: "UserTeam");

            migrationBuilder.DropIndex(
                name: "IX_Team_CaptainId1",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UserTeam");

            migrationBuilder.DropColumn(
                name: "CaptainId1",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Elo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nick",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pix",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Elo = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Nick = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Phone = table.Column<string>(type: "longtext", nullable: false),
                    Pix = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeam_UserId",
                table: "UserTeam",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CaptainId",
                table: "Team",
                column: "CaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_CaptainId",
                table: "Team",
                column: "CaptainId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeam_User_UserId",
                table: "UserTeam",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoCloud.Migrations
{
    public partial class RemovendoCampoSenha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Senha_Usuario",
                table: "Usuario");

            migrationBuilder.CreateTable(
                name: "ProjetoCloudUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoCloudUser", x => x.Id);

                });

            migrationBuilder.AddColumn<int>(
                name: "UsuarioDeAutenticacaoId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_AspNetUsers_UsuarioDeAutenticacaoId",
                table: "Usuario",
                column: "UsuarioDeAutenticacaoId",
                principalTable: "AspNetUsers",
                principalColumn: "UsuarioDeAplicacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoCloudUser_UsuarioId",
                table: "ProjetoCloudUser",
                column: "UsuarioDeAutenticacaoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoCloudUser");

            migrationBuilder.AddColumn<string>(
                name: "Email_Usuario",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha_Usuario",
                table: "Usuario",
                nullable: true);
        }
    }
}

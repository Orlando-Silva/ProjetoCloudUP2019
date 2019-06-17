using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoCloud.Migrations.ProjetoCloud
{
    public partial class AdicionandoVinculoAoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioDeAplicacaoId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Usuario_UsuarioId",
                table: "AspNetUsers",
                column: "UsuarioDeAplicacaoId",
                principalTable: "Usuario",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Usuario_UsuarioId",
                table: "AspNetUsers");     

            migrationBuilder.DropColumn(
                name: "UsuarioDeAplicacaoId",
                table: "AspNetUsers");
        }
    }
}

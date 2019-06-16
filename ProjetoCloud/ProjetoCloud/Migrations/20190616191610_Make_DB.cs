using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoCloud.Migrations
{
    public partial class Make_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id_Plano = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Plano = table.Column<string>(nullable: true),
                    Valor_Plano = table.Column<decimal>(nullable: false),
                    Data_Cadastro_Plano = table.Column<DateTime>(nullable: false),
                    Qtde_Max_Dispositivos_Plano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id_Plano);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Usuario = table.Column<string>(nullable: true),
                    Data_Cadastro_Usuario = table.Column<DateTime>(nullable: false),
                    CPF_Usuario = table.Column<string>(nullable: true),
                    Cartao_Usuario = table.Column<string>(nullable: true),
                    CEP_Usuario = table.Column<int>(nullable: false),
                    Email_Usuario = table.Column<string>(nullable: true),
                    Senha_Usuario = table.Column<string>(nullable: true),
                    Adm_Usuario = table.Column<bool>(nullable: false),
                    Plano_UsuarioId_Plano = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Plano_Plano_UsuarioId_Plano",
                        column: x => x.Plano_UsuarioId_Plano,
                        principalTable: "Plano",
                        principalColumn: "Id_Plano",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ambiente",
                columns: table => new
                {
                    Id_Ambiente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Ambiente = table.Column<string>(nullable: true),
                    Data_Cadastro_Ambiente = table.Column<DateTime>(nullable: false),
                    Qtda_Dispositivo_Ambiente = table.Column<int>(nullable: false),
                    UsuarioId_Usuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambiente", x => x.Id_Ambiente);
                    table.ForeignKey(
                        name: "FK_Ambiente_Usuario_UsuarioId_Usuario",
                        column: x => x.UsuarioId_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivo",
                columns: table => new
                {
                    Id_Dispositivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Dispositivo = table.Column<string>(nullable: true),
                    Data_Cadastro_Dispositivo = table.Column<DateTime>(nullable: false),
                    Status_Dispositivo = table.Column<bool>(nullable: false),
                    AmbienteId_Ambiente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivo", x => x.Id_Dispositivo);
                    table.ForeignKey(
                        name: "FK_Dispositivo_Ambiente_AmbienteId_Ambiente",
                        column: x => x.AmbienteId_Ambiente,
                        principalTable: "Ambiente",
                        principalColumn: "Id_Ambiente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ambiente_UsuarioId_Usuario",
                table: "Ambiente",
                column: "UsuarioId_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_AmbienteId_Ambiente",
                table: "Dispositivo",
                column: "AmbienteId_Ambiente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Plano_UsuarioId_Plano",
                table: "Usuario",
                column: "Plano_UsuarioId_Plano");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispositivo");

            migrationBuilder.DropTable(
                name: "Ambiente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Plano");
        }
    }
}

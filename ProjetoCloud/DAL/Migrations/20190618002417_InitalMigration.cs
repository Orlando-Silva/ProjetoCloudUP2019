using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id_Plano = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Plano = table.Column<string>(maxLength: 128, nullable: false),
                    Valor_Plano = table.Column<decimal>(nullable: false),
                    Data_Cadastro_Plano = table.Column<DateTime>(nullable: false),
                    Qtde_Max_Dispositivos_Plano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id_Plano);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Usuario = table.Column<string>(maxLength: 128, nullable: false),
                    Data_Cadastro_Usuario = table.Column<DateTime>(nullable: false),
                    CPF_Usuario = table.Column<string>(nullable: true),
                    Cartao_Usuario = table.Column<string>(nullable: true),
                    CEP_Usuario = table.Column<string>(nullable: true),
                    Plano_UsuarioId_Plano = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Planos_Plano_UsuarioId_Plano",
                        column: x => x.Plano_UsuarioId_Plano,
                        principalTable: "Planos",
                        principalColumn: "Id_Plano",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ambientes",
                columns: table => new
                {
                    Id_Ambiente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Ambiente = table.Column<string>(maxLength: 128, nullable: false),
                    Data_Cadastro_Ambiente = table.Column<DateTime>(nullable: false),
                    Qtda_Dispositivo_Ambiente = table.Column<int>(nullable: false),
                    UsuarioId_Usuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambientes", x => x.Id_Ambiente);
                    table.ForeignKey(
                        name: "FK_Ambientes_Usuarios_UsuarioId_Usuario",
                        column: x => x.UsuarioId_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    Id_Dispositivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Dispositivo = table.Column<string>(maxLength: 128, nullable: false),
                    Data_Cadastro_Dispositivo = table.Column<DateTime>(nullable: false),
                    Status_Dispositivo = table.Column<bool>(nullable: false),
                    AmbienteId_Ambiente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.Id_Dispositivo);
                    table.ForeignKey(
                        name: "FK_Dispositivos_Ambientes_AmbienteId_Ambiente",
                        column: x => x.AmbienteId_Ambiente,
                        principalTable: "Ambientes",
                        principalColumn: "Id_Ambiente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ambientes_UsuarioId_Usuario",
                table: "Ambientes",
                column: "UsuarioId_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_AmbienteId_Ambiente",
                table: "Dispositivos",
                column: "AmbienteId_Ambiente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Plano_UsuarioId_Plano",
                table: "Usuarios",
                column: "Plano_UsuarioId_Plano");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Ambientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Planos");
        }
    }
}

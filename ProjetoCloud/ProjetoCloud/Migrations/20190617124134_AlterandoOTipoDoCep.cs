using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoCloud.Migrations
{
    public partial class AlterandoOTipoDoCep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP_Usuario",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CEP_Usuario",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

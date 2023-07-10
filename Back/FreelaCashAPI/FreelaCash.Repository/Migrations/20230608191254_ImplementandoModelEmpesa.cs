using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelaCash.Repository.Migrations
{
    public partial class ImplementandoModelEmpesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeEmpresa",
                table: "Servicos");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Servicos");

            migrationBuilder.AddColumn<string>(
                name: "NomeEmpresa",
                table: "Servicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

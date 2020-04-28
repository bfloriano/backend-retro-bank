using Microsoft.EntityFrameworkCore.Migrations;

namespace retro_bank.Migrations
{
    public partial class TransferenciaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    ClienteRemetenteId = table.Column<int>(nullable: false),
                    ClienteDestinatarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferencias");
        }
    }
}

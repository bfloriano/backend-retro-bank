using Microsoft.EntityFrameworkCore.Migrations;

namespace retro_bank.Migrations
{
    public partial class ExtratoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Extratos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Extratos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

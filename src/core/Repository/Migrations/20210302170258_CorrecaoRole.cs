using Microsoft.EntityFrameworkCore.Migrations;

namespace Alterdata.Bimer.Core.Repository.Migrations
{
    public partial class CorrecaoRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "AspNetRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

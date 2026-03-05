using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaEstadoToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "estado");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Books",
                newName: "Description");
        }
    }
}

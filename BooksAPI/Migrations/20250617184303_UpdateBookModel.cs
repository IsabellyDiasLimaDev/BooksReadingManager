using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "pageCount",
                table: "Books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "publisher",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pageCount",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "publisher",
                table: "Books");
        }
    }
}

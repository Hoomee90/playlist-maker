using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaylistMaker.Migrations
{
    public partial class UpdateSongPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Songs",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Songs",
                newName: "Name");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternPipeline.Migrations
{
    /// <inheritdoc />
    public partial class addBlogTableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogModelTable",
                table: "BlogModelTable");

            migrationBuilder.RenameTable(
                name: "BlogModelTable",
                newName: "BlogTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTable",
                table: "BlogTable",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTable",
                table: "BlogTable");

            migrationBuilder.RenameTable(
                name: "BlogTable",
                newName: "BlogModelTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogModelTable",
                table: "BlogModelTable",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllUpMVC.Migrations
{
    /// <inheritdoc />
    public partial class addparentcategoryid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "Categorys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Categorys");
        }
    }
}

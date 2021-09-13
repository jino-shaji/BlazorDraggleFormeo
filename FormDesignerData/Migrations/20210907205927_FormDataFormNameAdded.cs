using Microsoft.EntityFrameworkCore.Migrations;

namespace FormDesignerData.Migrations
{
    public partial class FormDataFormNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormName",
                table: "FormData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormName",
                table: "FormData");
        }
    }
}

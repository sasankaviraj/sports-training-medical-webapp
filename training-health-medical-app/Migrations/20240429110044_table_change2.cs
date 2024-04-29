using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace training_health_medical_app.Migrations
{
    public partial class table_change2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnose",
                table: "Survey",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnose",
                table: "Survey");
        }
    }
}

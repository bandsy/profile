using Microsoft.EntityFrameworkCore.Migrations;

namespace profile.api.Migrations
{
    public partial class AddMasterIDAndUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "m_ID",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "m_ID",
                table: "Profiles");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace profile.api.Migrations
{
    public partial class RenamedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowersModels",
                table: "FollowersModels");

            migrationBuilder.RenameTable(
                name: "FollowersModels",
                newName: "Followers");

            migrationBuilder.RenameColumn(
                name: "m_id",
                table: "Followers",
                newName: "m_Id");

            migrationBuilder.RenameColumn(
                name: "f_id",
                table: "Followers",
                newName: "f_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "FollowersModels");

            migrationBuilder.RenameColumn(
                name: "m_Id",
                table: "FollowersModels",
                newName: "m_id");

            migrationBuilder.RenameColumn(
                name: "f_Id",
                table: "FollowersModels",
                newName: "f_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowersModels",
                table: "FollowersModels",
                column: "Id");
        }
    }
}

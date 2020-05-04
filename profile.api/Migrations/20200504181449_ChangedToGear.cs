using Microsoft.EntityFrameworkCore.Migrations;

namespace profile.api.Migrations
{
    public partial class ChangedToGear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearModels_Profiles_ProfileModelId",
                table: "GearModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearModels",
                table: "GearModels");

            migrationBuilder.RenameTable(
                name: "GearModels",
                newName: "Gear");

            migrationBuilder.RenameIndex(
                name: "IX_GearModels_ProfileModelId",
                table: "Gear",
                newName: "IX_Gear_ProfileModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gear",
                table: "Gear",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gear_Profiles_ProfileModelId",
                table: "Gear",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gear_Profiles_ProfileModelId",
                table: "Gear");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gear",
                table: "Gear");

            migrationBuilder.RenameTable(
                name: "Gear",
                newName: "GearModels");

            migrationBuilder.RenameIndex(
                name: "IX_Gear_ProfileModelId",
                table: "GearModels",
                newName: "IX_GearModels_ProfileModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearModels",
                table: "GearModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GearModels_Profiles_ProfileModelId",
                table: "GearModels",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

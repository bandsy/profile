using Microsoft.EntityFrameworkCore.Migrations;

namespace profile.api.Migrations
{
    public partial class UpdatedDbSetNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsModel_Profiles_ProfileModelId",
                table: "EventsModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceModel_Profiles_ProfileModelId",
                table: "ExperienceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GearModel_Profiles_ProfileModelId",
                table: "GearModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaModels_Profiles_ProfileModelId",
                table: "MediaModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_MediaModels_ProfilePictureId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaModels",
                table: "MediaModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearModel",
                table: "GearModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExperienceModel",
                table: "ExperienceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsModel",
                table: "EventsModel");

            migrationBuilder.RenameTable(
                name: "MediaModels",
                newName: "Media");

            migrationBuilder.RenameTable(
                name: "GearModel",
                newName: "GearModels");

            migrationBuilder.RenameTable(
                name: "ExperienceModel",
                newName: "Experience");

            migrationBuilder.RenameTable(
                name: "EventsModel",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_MediaModels_ProfileModelId",
                table: "Media",
                newName: "IX_Media_ProfileModelId");

            migrationBuilder.RenameIndex(
                name: "IX_GearModel_ProfileModelId",
                table: "GearModels",
                newName: "IX_GearModels_ProfileModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ExperienceModel_ProfileModelId",
                table: "Experience",
                newName: "IX_Experience_ProfileModelId");

            migrationBuilder.RenameIndex(
                name: "IX_EventsModel_ProfileModelId",
                table: "Events",
                newName: "IX_Events_ProfileModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearModels",
                table: "GearModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experience",
                table: "Experience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Profiles_ProfileModelId",
                table: "Events",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Profiles_ProfileModelId",
                table: "Experience",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GearModels_Profiles_ProfileModelId",
                table: "GearModels",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Profiles_ProfileModelId",
                table: "Media",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Media_ProfilePictureId",
                table: "Profiles",
                column: "ProfilePictureId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Profiles_ProfileModelId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Profiles_ProfileModelId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_GearModels_Profiles_ProfileModelId",
                table: "GearModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Profiles_ProfileModelId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Media_ProfilePictureId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearModels",
                table: "GearModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experience",
                table: "Experience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "MediaModels");

            migrationBuilder.RenameTable(
                name: "GearModels",
                newName: "GearModel");

            migrationBuilder.RenameTable(
                name: "Experience",
                newName: "ExperienceModel");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "EventsModel");

            migrationBuilder.RenameIndex(
                name: "IX_Media_ProfileModelId",
                table: "MediaModels",
                newName: "IX_MediaModels_ProfileModelId");

            migrationBuilder.RenameIndex(
                name: "IX_GearModels_ProfileModelId",
                table: "GearModel",
                newName: "IX_GearModel_ProfileModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Experience_ProfileModelId",
                table: "ExperienceModel",
                newName: "IX_ExperienceModel_ProfileModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_ProfileModelId",
                table: "EventsModel",
                newName: "IX_EventsModel_ProfileModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaModels",
                table: "MediaModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearModel",
                table: "GearModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExperienceModel",
                table: "ExperienceModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsModel",
                table: "EventsModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsModel_Profiles_ProfileModelId",
                table: "EventsModel",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceModel_Profiles_ProfileModelId",
                table: "ExperienceModel",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GearModel_Profiles_ProfileModelId",
                table: "GearModel",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaModels_Profiles_ProfileModelId",
                table: "MediaModels",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_MediaModels_ProfilePictureId",
                table: "Profiles",
                column: "ProfilePictureId",
                principalTable: "MediaModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

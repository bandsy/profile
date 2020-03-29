using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace profile.api.Migrations
{
    public partial class UpdatedProfileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeZoneId",
                table: "Profiles",
                newName: "TimezoneId");

            migrationBuilder.AddColumn<List<DateTime>>(
                name: "Availability",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileVisibility",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileModelId",
                table: "MediaModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventsModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsModel_Profiles_ProfileModelId",
                        column: x => x.ProfileModelId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Years = table.Column<int>(nullable: false),
                    Instrument = table.Column<int>(nullable: false),
                    ProfileModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceModel_Profiles_ProfileModelId",
                        column: x => x.ProfileModelId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GearModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Instrument = table.Column<int>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    ProfileModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearModel_Profiles_ProfileModelId",
                        column: x => x.ProfileModelId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaModels_ProfileModelId",
                table: "MediaModels",
                column: "ProfileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsModel_ProfileModelId",
                table: "EventsModel",
                column: "ProfileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceModel_ProfileModelId",
                table: "ExperienceModel",
                column: "ProfileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GearModel_ProfileModelId",
                table: "GearModel",
                column: "ProfileModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaModels_Profiles_ProfileModelId",
                table: "MediaModels",
                column: "ProfileModelId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaModels_Profiles_ProfileModelId",
                table: "MediaModels");

            migrationBuilder.DropTable(
                name: "EventsModel");

            migrationBuilder.DropTable(
                name: "ExperienceModel");

            migrationBuilder.DropTable(
                name: "GearModel");

            migrationBuilder.DropIndex(
                name: "IX_MediaModels_ProfileModelId",
                table: "MediaModels");

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileVisibility",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileModelId",
                table: "MediaModels");

            migrationBuilder.RenameColumn(
                name: "TimezoneId",
                table: "Profiles",
                newName: "TimeZoneId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PresidentialElection.Migrations
{
    public partial class RelationalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CitizenID",
                table: "AspNetUsers",
                newName: "GovernmentID");

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CanditateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Party = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CanditateID);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteID);
                    table.ForeignKey(
                        name: "FK_Votes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CanditateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CandidateID",
                table: "Votes",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.RenameColumn(
                name: "GovernmentID",
                table: "AspNetUsers",
                newName: "CitizenID");
        }
    }
}

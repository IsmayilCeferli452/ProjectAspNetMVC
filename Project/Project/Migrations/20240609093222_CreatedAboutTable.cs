using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class CreatedAboutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Informations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informations_AboutId",
                table: "Informations",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Informations_About_AboutId",
                table: "Informations",
                column: "AboutId",
                principalTable: "About",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informations_About_AboutId",
                table: "Informations");

            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropIndex(
                name: "IX_Informations_AboutId",
                table: "Informations");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Informations");
        }
    }
}

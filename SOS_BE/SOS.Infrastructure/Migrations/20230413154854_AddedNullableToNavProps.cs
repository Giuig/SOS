using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOS.Infrastructure.Migrations
{
    public partial class AddedNullableToNavProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mission_Team_TeamId",
                table: "Mission");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Mission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Mission_Team_TeamId",
                table: "Mission",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mission_Team_TeamId",
                table: "Mission");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mission_Team_TeamId",
                table: "Mission",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

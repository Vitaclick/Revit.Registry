using Microsoft.EntityFrameworkCore.Migrations;

namespace Reg.DataAccess.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Projects_ProjectId",
                table: "Models");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Models",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Projects_ProjectId",
                table: "Models",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Projects_ProjectId",
                table: "Models");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Models",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Projects_ProjectId",
                table: "Models",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

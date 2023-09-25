using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBAuth.DAL.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UtilisateurApplication_IdApplication",
                table: "UtilisateurApplication");

            migrationBuilder.DropIndex(
                name: "IX_Permission_IdRole",
                table: "Permission");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateurApplication_IdApplication",
                table: "UtilisateurApplication",
                column: "IdApplication");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdRole",
                table: "Permission",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UtilisateurApplication_IdApplication",
                table: "UtilisateurApplication");

            migrationBuilder.DropIndex(
                name: "IX_Permission_IdRole",
                table: "Permission");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateurApplication_IdApplication",
                table: "UtilisateurApplication",
                column: "IdApplication",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdRole",
                table: "Permission",
                column: "IdRole",
                unique: true);
        }
    }
}

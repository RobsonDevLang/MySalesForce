using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Migrations
{
    /// <inheritdoc />
    public partial class SyncModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_app_user_role_model_role_id",
                table: "app_user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_model",
                table: "role_model");

            migrationBuilder.RenameTable(
                name: "role_model",
                newName: "role");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role",
                table: "role",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_app_user_role_role_id",
                table: "app_user",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_app_user_role_role_id",
                table: "app_user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role",
                table: "role");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "role_model");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_model",
                table: "role_model",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_app_user_role_model_role_id",
                table: "app_user",
                column: "role_id",
                principalTable: "role_model",
                principalColumn: "id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SimpleChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefleshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefleshTokenEndDate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefleshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefleshTokenEndDate",
                table: "AspNetUsers");
        }
    }
}

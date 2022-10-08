using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.Lamazon.DataAccess.Migrations
{
    public partial class DbInsertRolesAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Key", "Name" },
                values: new object[,]
                {
                    { "user", "User" },
                    { "admin", "Administrator" }
                });

            migrationBuilder.InsertData(
              table: "Users",
              columns: new[] { "FullName", "RoleKey", "Email", "PasswordHash" },
              values: new object[,]
              {
                    { "Administrator User", "admin", "admin@outlook.com", "AQAAAAEAACcQAAAAEGYnACfyA5QEAgjb4I4LWYsDDAzQwmnzR7f1j3F/Q5uWr94dnFjUu6sFYevXLVH4bQ==" },
                    { "Normal User", "user", "user@outlook.com", "AQAAAAEAACcQAAAAEGYnACfyA5QEAgjb4I4LWYsDDAzQwmnzR7f1j3F/Q5uWr94dnFjUu6sFYevXLVH4bQ==" }
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValues: new object[] { "admin@outlook.com", "user@outlook.com" }
            );

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Key",
                keyValues: new object[] { "user", "admin" }
            );
        }
    }
}

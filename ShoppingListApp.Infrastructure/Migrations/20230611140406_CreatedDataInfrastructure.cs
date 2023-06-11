using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApp.Infrastructure.Migrations
{
    public partial class CreatedDataInfrastructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "Money", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"), "2", "Customer", "CUSTOMER" },
                    { new Guid("b3bf89bc-b80a-4b24-9f4b-9a90bb4fe652"), "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("48787569-f841-4832-8528-1f503a8427cf"), 0, "ab9e8513-a75e-46dd-969d-7eac62c0f91b", "valeri.yanev@icloud.com", false, "Valeri", true, "Yanev", false, null, "VALERI.YANEV@ICLOUD.COM", "valeri", "AQAAAAEAACcQAAAAEP1WCRQeKT8g9p48tsuL+PkfRyPXuP/VFCibVwahJqMJqno4coCIuM3UEVXG5+cjJg==", null, false, null, false, "valeri" },
                    { new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3"), 0, "896e025c-edfc-4d88-ab50-90e413d0cd42", "georgi@mail.com", false, "Georgi", true, "Ivanov", false, null, "GEORGI@MAIL.COM", "GEORGI", "AQAAAAEAACcQAAAAEP640Eh5veUnz+zZ3q+zoCnhsqudi7yL2Kc34R7rXfUVPGEAVHXCIUYyivu+rpdxvA==", null, false, null, false, "georgi" },
                    { new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6"), 0, "38932551-bf97-4127-8442-ca26034a6da3", "nakov@softuni.bg", false, "Svetlin", true, "Nakov", false, null, "NAKOV@SOFTUNI.BG", "NAKOV", "AQAAAAEAACcQAAAAELYGOo3uD2fesOGhxbGu/IOcjK4qJOUVqmiwoHc69W/VbVn8hJVh4nRTkT9PjUR28g==", null, false, null, false, "nakov" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b3bf89bc-b80a-4b24-9f4b-9a90bb4fe652"), new Guid("48787569-f841-4832-8528-1f503a8427cf") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"), new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"), new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6") });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b3bf89bc-b80a-4b24-9f4b-9a90bb4fe652"), new Guid("48787569-f841-4832-8528-1f503a8427cf") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"), new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"), new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3bf89bc-b80a-4b24-9f4b-9a90bb4fe652"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48787569-f841-4832-8528-1f503a8427cf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6"));
        }
    }
}

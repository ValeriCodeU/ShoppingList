using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApp.Infrastructure.Migrations
{
    public partial class UpadatedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48787569-f841-4832-8528-1f503a8427cf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81203099-c4ca-4154-bbad-49e8dd7bccb4", "AQAAAAEAACcQAAAAENHNxtR8OhwwPZwBnOwatiahKfw2p7XyBC8hv8vSWqyou9rdkE1cJle+hskYt4hc2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b72d0a5-f8ae-40ca-a991-002a96e965a1", "AQAAAAEAACcQAAAAEJ5bwZFHc57SMVOn3Eqd+7jLM3KUxM8hsSMH2IILoRa5NXlVMDPs27hNOHtMAOEuDA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45b7d6b0-0e1c-4a13-8c5c-4e91c4962bfe", "AQAAAAEAACcQAAAAEMzy+SN9YBbPAJCekkX8kFOK8hAcXH9m2n74k8ercXBzwetIT7R/pz4KFRg0Mvm8fA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48787569-f841-4832-8528-1f503a8427cf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab9e8513-a75e-46dd-969d-7eac62c0f91b", "AQAAAAEAACcQAAAAEP1WCRQeKT8g9p48tsuL+PkfRyPXuP/VFCibVwahJqMJqno4coCIuM3UEVXG5+cjJg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "896e025c-edfc-4d88-ab50-90e413d0cd42", "AQAAAAEAACcQAAAAEP640Eh5veUnz+zZ3q+zoCnhsqudi7yL2Kc34R7rXfUVPGEAVHXCIUYyivu+rpdxvA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "38932551-bf97-4127-8442-ca26034a6da3", "AQAAAAEAACcQAAAAELYGOo3uD2fesOGhxbGu/IOcjK4qJOUVqmiwoHc69W/VbVn8hJVh4nRTkT9PjUR28g==" });
        }
    }
}

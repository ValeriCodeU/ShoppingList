using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApp.Infrastructure.Migrations
{
    public partial class AddedSecurityStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48787569-f841-4832-8528-1f503a8427cf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8182c592-588a-4a9b-87bb-1b077f72d702", "AQAAAAEAACcQAAAAEDThWBYQje498kGrMOaCY+8IvMBagsSE9JudOCjv4y3T2eOnVdK8HR+SKMhLm5K28g==", "dec4810f-efa0-456f-8282-4d4a1761d311" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbca2dc7-50a9-4757-bf6b-04719a808296", "AQAAAAEAACcQAAAAEC3XCSWL1zBXRpogpgh1pJKDHPKZY29AjBwUAx+br88GVHjJbpJvLaa77IuQ8hAfCg==", "357cf48e-34c9-41b0-9f54-7a089dd283de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1033a3ec-72cd-49e7-8561-3c52afc31017", "AQAAAAEAACcQAAAAECJXrCtENvm8tlRQggyOMvyxfeYdgZmM6PNWrPepr96ALrUnGTVaOM/Zahm9mn5Pbw==", "9ba78f2d-1557-4032-a8c9-5f5d209a08b1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48787569-f841-4832-8528-1f503a8427cf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81203099-c4ca-4154-bbad-49e8dd7bccb4", "AQAAAAEAACcQAAAAENHNxtR8OhwwPZwBnOwatiahKfw2p7XyBC8hv8vSWqyou9rdkE1cJle+hskYt4hc2Q==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b72d0a5-f8ae-40ca-a991-002a96e965a1", "AQAAAAEAACcQAAAAEJ5bwZFHc57SMVOn3Eqd+7jLM3KUxM8hsSMH2IILoRa5NXlVMDPs27hNOHtMAOEuDA==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45b7d6b0-0e1c-4a13-8c5c-4e91c4962bfe", "AQAAAAEAACcQAAAAEMzy+SN9YBbPAJCekkX8kFOK8hAcXH9m2n74k8ercXBzwetIT7R/pz4KFRg0Mvm8fA==", null });
        }
    }
}

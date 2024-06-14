using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class HashedPasswordFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "QBkQeyB04cQZqrtgaBp0Eg==;jC0L3k0ARjqxDrC6wLECGKuXyUyQAF14PCZd3cHfse0=", "QBkQeyB04cQZqrtgaBp0Eg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "sAYmYZCFMMaN25ElHFD9Ig==;Zc5f8cQN2KIgaEp+oUp3juAFYdtkfKtSfUrDqZ+5scg=", "sAYmYZCFMMaN25ElHFD9Ig==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "OfaibSThELgFdJFX0aSexw==;pgLrdc+R7oyhXOsLMsVpUphB2E18hwjKDjs4Ma408iA=", "OfaibSThELgFdJFX0aSexw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "i1ZqWU2NUMJpoG0pq3odBw==;gMinZia879x5TxE7qARbgftxLEfLsllxqcUu9wgMsiY=", "pppp" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "hLxhu7EKlfq098pZNa9bRg==;EQrOJyyIFIwhI169AOpbPa/MPYr5T+szfapRWmfMK2o=", "aaaa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "2iCAh6hWPCM5JOs2teLalQ==;fOf0Kz4TBTjJMpMKyDrO0A8rqoNXkY+mGqsF3fur1DY=", "tttt" });
        }
    }
}

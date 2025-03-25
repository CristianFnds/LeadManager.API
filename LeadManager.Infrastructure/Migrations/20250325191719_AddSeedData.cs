using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeadManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "created_at", "email", "first_name", "last_name", "phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3651), "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3654), "jane.smith@example.com", "Jane", "Smith", "987-654-3210" },
                    { 3, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3655), "alice.johnson@example.com", "Alice", "Johnson", "555-123-4567" },
                    { 4, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3656), "bob.brown@example.com", "Bob", "Brown", "444-987-6543" },
                    { 5, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3657), "charlie.davis@example.com", "Charlie", "Davis", "333-222-1111" }
                });

            migrationBuilder.InsertData(
                table: "Leads",
                columns: new[] { "Id", "Category", "contact_id", "created_at", "Description", "IsAccepted", "Price", "Suburb" },
                values: new object[,]
                {
                    { 1, "Real Estate", 1, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3802), "Spacious apartment with a great view", null, 300000.00m, "Downtown" },
                    { 2, "Automobile", 2, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3804), "Brand new car with excellent mileage", null, 20000.00m, "Suburbs" },
                    { 3, "Technology", 3, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3805), "Latest laptop with high-end specs", null, 1500.00m, "Uptown" },
                    { 4, "Real Estate", 4, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3806), "Beachfront house with a large yard", null, 500000.00m, "Beachfront" },
                    { 5, "Furniture", 5, new DateTime(2025, 3, 25, 19, 17, 19, 587, DateTimeKind.Utc).AddTicks(3807), "Modern sofa set, brand new", null, 800.00m, "City Center" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

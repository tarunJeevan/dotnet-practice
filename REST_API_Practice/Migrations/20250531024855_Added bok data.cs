using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST_API_Practice.Migrations
{
    /// <inheritdoc />
    public partial class Addedbokdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, "Jared Diamond", "9780143117001", "Collapse: How Societies Choose to Fail or Succeed", 2011 },
                    { 2, "Lauren Miller", "9780062199805", "Free to Fall", 2014 },
                    { 3, "Jared Diamond", "9780099302780", "Guns, Germs, and Steel: A short history of everybody for the last 13,000 years", 1998 },
                    { 4, "Gregory Kerr", "9780359434121", "Philosophical Phridays: Volume 1", 2019 },
                    { 5, "Kautilya", "9788184750119", "The Arthashastra", 2000 },
                    { 6, "Scott Reintgen", "9780399556821", "Nyxia", 2017 },
                    { 7, "Claudia Gray", "9780316394031", "Defy the Stars", 2017 },
                    { 8, "Gina Damico", "9780547822563", "Croak", 2012 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}

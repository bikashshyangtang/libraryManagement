using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace libraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class CustomersData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "bikash@student.fdu.edu", "Bikash", "Shyangtang", null, "6045550101" },
                    { 2, "alice.t@email.com", "Alice", "Thompson", null, "6045550102" },
                    { 3, "bob.h@yahoo.com", "Bob", "Henderson", null, "7785550103" },
                    { 4, "cvance@outlook.com", "Chloe", "Vance", null, "6045550104" },
                    { 5, "d.park@gmail.com", "Daniel", "Park", null, "7785550105" },
                    { 6, "elena.rod@provider.net", "Elena", "Rodriguez", null, "6045550106" },
                    { 7, "fwright@techmail.com", "Felix", "Wright", null, "6045550107" },
                    { 8, "g.kim@vancouver.ca", "Grace", "Kim", null, "7785550108" },
                    { 9, "hmiller@business.com", "Henry", "Miller", null, "6045550109" },
                    { 10, "izzy.chen@gmail.com", "Isabella", "Chen", null, "6045550110" },
                    { 11, "jack.p@outlook.com", "Jack", "Peterson", null, "7785550111" },
                    { 12, "k.ross@web.com", "Katherine", "Ross", null, "6045550112" },
                    { 13, "liam.m@email.org", "Liam", "Murray", null, "6045550113" },
                    { 14, "foster.mia@gmail.com", "Mia", "Foster", null, "7785550114" },
                    { 15, "n.brooks@provider.com", "Noah", "Brooks", null, "6045550115" },
                    { 16, "o.grant@service.net", "Olivia", "Grant", null, "6045550116" },
                    { 17, "p.walsh@icloud.com", "Peter", "Walsh", null, "7785550117" },
                    { 18, "q.taylor@gmail.com", "Quinn", "Taylor", null, "6045550118" },
                    { 19, "ryan.s@vpl.ca", "Ryan", "Singh", null, "6045550119" },
                    { 20, "s.bennett@mail.com", "Sophie", "Bennett", null, "7785550120" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 20);
        }
    }
}

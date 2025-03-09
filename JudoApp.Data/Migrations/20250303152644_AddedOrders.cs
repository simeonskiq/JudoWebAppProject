using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JudoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("47b3d8be-4ed8-4f3e-a8aa-6eebeaea8680"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("df1ad88f-cb91-41cd-80c3-01276449111c"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("9b865df1-a40c-4d2f-b182-597ccc1501b1"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("edae0424-c65c-4805-9fe8-647d1e0dadde"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("d8a1c926-166d-4c27-9f1a-cd7d86854a65"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("df052109-94e4-4b62-8f14-c054b9e8e2e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96840083-e467-4f29-b150-821701401f6e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e47e669e-7abf-4c1f-90bf-b992bf667f55"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShippingMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    OrderStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "DateUploaded", "Description", "Tittle" },
                values: new object[,]
                {
                    { new Guid("1992be80-ba30-44e7-b471-dae60b30e1b6"), new DateTime(2025, 3, 3, 15, 26, 43, 412, DateTimeKind.Utc).AddTicks(393), "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability.", "Sustainable Living: Simple Changes for a Greener Future" },
                    { new Guid("5ae1880a-0d9a-4471-9ca8-c9c317db14a4"), new DateTime(2025, 3, 3, 15, 26, 43, 412, DateTimeKind.Utc).AddTicks(389), "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology.", "The Rise of AI in Everyday Life: Transforming How We Live and Work" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("4c1e05d2-ba16-4724-ac22-8618d3c524d2"), "bul. „Prof. Cvetan Lazarov“ №14", "Sofia", null, "SK CSKA Sofia", "0898 702 088" },
                    { new Guid("98957aa0-71a8-4694-b4db-cb704b0c35d1"), "Zala. „Dunav“, ul. „Chiprovci“ 40", "Ruse", null, "Loko Ruse", "+359 8 7662 3232" }
                });

            migrationBuilder.InsertData(
                table: "Judges",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("d297b009-4351-4761-8fcd-deb2de29ac63"), "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva", false, "Plamen Velikov" },
                    { new Guid("d6217f27-4b26-4e03-a70b-a034875e9d09"), "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva.", false, "Rumen Minchev" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("48716f47-89cb-4bd8-91d0-f9eb09ca4f7a"), "The Gainward GeForce RTX 4090 Phantom 24GB is a powerhouse graphics card designed for ultimate gaming and content creation performance. Featuring NVIDIA's cutting-edge Ada Lovelace architecture, it delivers groundbreaking AI-powered graphics, real-time ray tracing, and exceptional efficiency.", "https://desktop.bg/system/images/491136/normal/gainward_geforce_rtx_4090_phantom_24gb.png", "Gainward GeForce RTX 4090 Phantom 24GB", "4759" },
                    { new Guid("bdfba64a-1d25-4266-aa04-98c9148f6f90"), "The Logitech G102 LIGHTSYNC White is a high-performance gaming mouse designed for precision, speed, and style. Featuring a 6,000 DPI sensor, it delivers accurate tracking and responsiveness, making it perfect for both casual and competitive gaming. The LIGHTSYNC RGB technology offers customizable lighting", "https://desktop.bg/system/images/249327/normal/910005824.jpg", "Logitech G102 LIGHTSYNC White", "45" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Orders_OrderId",
                table: "CartItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Orders_OrderId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1992be80-ba30-44e7-b471-dae60b30e1b6"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5ae1880a-0d9a-4471-9ca8-c9c317db14a4"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("4c1e05d2-ba16-4724-ac22-8618d3c524d2"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("98957aa0-71a8-4694-b4db-cb704b0c35d1"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("d297b009-4351-4761-8fcd-deb2de29ac63"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("d6217f27-4b26-4e03-a70b-a034875e9d09"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48716f47-89cb-4bd8-91d0-f9eb09ca4f7a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bdfba64a-1d25-4266-aa04-98c9148f6f90"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CartItems");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "DateUploaded", "Description", "Tittle" },
                values: new object[,]
                {
                    { new Guid("47b3d8be-4ed8-4f3e-a8aa-6eebeaea8680"), new DateTime(2025, 2, 3, 0, 59, 24, 541, DateTimeKind.Utc).AddTicks(2703), "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability.", "Sustainable Living: Simple Changes for a Greener Future" },
                    { new Guid("df1ad88f-cb91-41cd-80c3-01276449111c"), new DateTime(2025, 2, 3, 0, 59, 24, 541, DateTimeKind.Utc).AddTicks(2697), "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology.", "The Rise of AI in Everyday Life: Transforming How We Live and Work" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("9b865df1-a40c-4d2f-b182-597ccc1501b1"), "bul. „Prof. Cvetan Lazarov“ №14", "Sofia", null, "SK CSKA Sofia", "0898 702 088" },
                    { new Guid("edae0424-c65c-4805-9fe8-647d1e0dadde"), "Zala. „Dunav“, ul. „Chiprovci“ 40", "Ruse", null, "Loko Ruse", "+359 8 7662 3232" }
                });

            migrationBuilder.InsertData(
                table: "Judges",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("d8a1c926-166d-4c27-9f1a-cd7d86854a65"), "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva.", false, "Rumen Minchev" },
                    { new Guid("df052109-94e4-4b62-8f14-c054b9e8e2e4"), "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva", false, "Plamen Velikov" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("96840083-e467-4f29-b150-821701401f6e"), "The Gainward GeForce RTX 4090 Phantom 24GB is a powerhouse graphics card designed for ultimate gaming and content creation performance. Featuring NVIDIA's cutting-edge Ada Lovelace architecture, it delivers groundbreaking AI-powered graphics, real-time ray tracing, and exceptional efficiency.", "https://desktop.bg/system/images/491136/normal/gainward_geforce_rtx_4090_phantom_24gb.png", "Gainward GeForce RTX 4090 Phantom 24GB", "4759лв." },
                    { new Guid("e47e669e-7abf-4c1f-90bf-b992bf667f55"), "The Logitech G102 LIGHTSYNC White is a high-performance gaming mouse designed for precision, speed, and style. Featuring a 6,000 DPI sensor, it delivers accurate tracking and responsiveness, making it perfect for both casual and competitive gaming. The LIGHTSYNC RGB technology offers customizable lighting", "https://desktop.bg/system/images/249327/normal/910005824.jpg", "Logitech G102 LIGHTSYNC White", "45лв." }
                });
        }
    }
}

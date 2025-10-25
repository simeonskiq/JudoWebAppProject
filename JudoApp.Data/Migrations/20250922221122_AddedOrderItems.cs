using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JudoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Orders_OrderId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2026162e-f493-43c6-a1f1-c6e57eb9a3d1"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8849c180-d93b-4095-9410-e1cbc62ec5db"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("d50919f4-09ed-435b-9e02-ce4a6e9cac85"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("e9a55ebc-2cdc-490e-ae74-8647e131376b"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("542e1829-4ce2-4d07-918b-b2fd3647e2a7"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("f9ed148f-ca78-401b-badd-80f9ec5870bd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("624ca06b-60b7-426a-bce0-526cc1815b00"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b8036b74-9b8d-40be-ae9d-300ca05337cd"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CartItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(2083)", unicode: false, maxLength: 2083, nullable: true),
                    CartItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_CartItems_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "CartItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "DateUploaded", "Description", "Tittle" },
                values: new object[,]
                {
                    { new Guid("05a793ee-af08-4b2d-8a2f-b0fd1e5306ac"), new DateTime(2025, 9, 22, 22, 11, 21, 849, DateTimeKind.Utc).AddTicks(3779), "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability.", "Sustainable Living: Simple Changes for a Greener Future" },
                    { new Guid("e2848517-0242-4a58-abd9-4d4482c33bbd"), new DateTime(2025, 9, 22, 22, 11, 21, 849, DateTimeKind.Utc).AddTicks(3774), "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology.", "The Rise of AI in Everyday Life: Transforming How We Live and Work" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("76e9ef3d-b8a6-4561-a9fa-ae68836a0457"), "Zala. „Dunav“, ul. „Chiprovci“ 40", "Ruse", null, "Loko Ruse", "+359 8 7662 3232" },
                    { new Guid("efdffcb0-c789-4864-997c-fbee67ea4298"), "bul. „Prof. Cvetan Lazarov“ №14", "Sofia", null, "SK CSKA Sofia", "0898 702 088" }
                });

            migrationBuilder.InsertData(
                table: "Judges",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("218cdeda-1c2d-4f53-97d7-7f9f4413f04f"), "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva", false, "Plamen Velikov" },
                    { new Guid("967620c3-beef-4baf-b981-e9bfe3ae9a7e"), "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva.", false, "Rumen Minchev" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("716848a4-412b-455f-98ac-649f136909a6"), "The Gainward GeForce RTX 4090 Phantom 24GB is a powerhouse graphics card designed for ultimate gaming and content creation performance. Featuring NVIDIA's cutting-edge Ada Lovelace architecture, it delivers groundbreaking AI-powered graphics, real-time ray tracing, and exceptional efficiency.", "https://desktop.bg/system/images/491136/normal/gainward_geforce_rtx_4090_phantom_24gb.png", "Gainward GeForce RTX 4090 Phantom 24GB", "4759" },
                    { new Guid("7a1fcd25-2639-468f-a987-895572f207dd"), "The Logitech G102 LIGHTSYNC White is a high-performance gaming mouse designed for precision, speed, and style. Featuring a 6,000 DPI sensor, it delivers accurate tracking and responsiveness, making it perfect for both casual and competitive gaming. The LIGHTSYNC RGB technology offers customizable lighting", "https://desktop.bg/system/images/249327/normal/910005824.jpg", "Logitech G102 LIGHTSYNC White", "45" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CartItemId",
                table: "OrderItem",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("05a793ee-af08-4b2d-8a2f-b0fd1e5306ac"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e2848517-0242-4a58-abd9-4d4482c33bbd"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("76e9ef3d-b8a6-4561-a9fa-ae68836a0457"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("efdffcb0-c789-4864-997c-fbee67ea4298"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("218cdeda-1c2d-4f53-97d7-7f9f4413f04f"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("967620c3-beef-4baf-b981-e9bfe3ae9a7e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("716848a4-412b-455f-98ac-649f136909a6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7a1fcd25-2639-468f-a987-895572f207dd"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "TotalAmount",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "DateUploaded", "Description", "Tittle" },
                values: new object[,]
                {
                    { new Guid("2026162e-f493-43c6-a1f1-c6e57eb9a3d1"), new DateTime(2025, 9, 22, 17, 19, 26, 61, DateTimeKind.Utc).AddTicks(8277), "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability.", "Sustainable Living: Simple Changes for a Greener Future" },
                    { new Guid("8849c180-d93b-4095-9410-e1cbc62ec5db"), new DateTime(2025, 9, 22, 17, 19, 26, 61, DateTimeKind.Utc).AddTicks(8271), "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology.", "The Rise of AI in Everyday Life: Transforming How We Live and Work" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("d50919f4-09ed-435b-9e02-ce4a6e9cac85"), "bul. „Prof. Cvetan Lazarov“ №14", "Sofia", null, "SK CSKA Sofia", "0898 702 088" },
                    { new Guid("e9a55ebc-2cdc-490e-ae74-8647e131376b"), "Zala. „Dunav“, ul. „Chiprovci“ 40", "Ruse", null, "Loko Ruse", "+359 8 7662 3232" }
                });

            migrationBuilder.InsertData(
                table: "Judges",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("542e1829-4ce2-4d07-918b-b2fd3647e2a7"), "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva.", false, "Rumen Minchev" },
                    { new Guid("f9ed148f-ca78-401b-badd-80f9ec5870bd"), "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva", false, "Plamen Velikov" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("624ca06b-60b7-426a-bce0-526cc1815b00"), "The Logitech G102 LIGHTSYNC White is a high-performance gaming mouse designed for precision, speed, and style. Featuring a 6,000 DPI sensor, it delivers accurate tracking and responsiveness, making it perfect for both casual and competitive gaming. The LIGHTSYNC RGB technology offers customizable lighting", "https://desktop.bg/system/images/249327/normal/910005824.jpg", "Logitech G102 LIGHTSYNC White", "45" },
                    { new Guid("b8036b74-9b8d-40be-ae9d-300ca05337cd"), "The Gainward GeForce RTX 4090 Phantom 24GB is a powerhouse graphics card designed for ultimate gaming and content creation performance. Featuring NVIDIA's cutting-edge Ada Lovelace architecture, it delivers groundbreaking AI-powered graphics, real-time ray tracing, and exceptional efficiency.", "https://desktop.bg/system/images/491136/normal/gainward_geforce_rtx_4090_phantom_24gb.png", "Gainward GeForce RTX 4090 Phantom 24GB", "4759" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Orders_OrderId",
                table: "CartItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}

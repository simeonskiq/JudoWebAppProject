using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JudoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

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

            migrationBuilder.AlterColumn<string>(
                name: "TotalAmount",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Preparing",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderNotes",
                table: "Orders",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

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
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNotes",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Preparing");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

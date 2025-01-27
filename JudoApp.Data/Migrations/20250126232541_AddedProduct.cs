using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JudoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("820f94b5-c53f-4435-8865-c0393c7b3ada"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("df8779c3-4637-4209-9aad-99a61a339813"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("20398f77-95c7-401c-88c0-09c2981a96b3"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c7a02059-00aa-49f6-9458-e0dd8f68dfa3"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("6780aea0-60b6-4e3b-8d5b-335b165f910c"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("989fb6c4-c002-439a-868b-7583a65edcfe"));

            migrationBuilder.AlterColumn<string>(
                name: "Tittle",
                table: "Articles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUploaded",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "DateUploaded", "Description", "Tittle" },
                values: new object[,]
                {
                    { new Guid("70590f4b-1876-4112-8f6b-501193a0dbc6"), new DateTime(2025, 1, 26, 23, 25, 41, 4, DateTimeKind.Utc).AddTicks(5155), "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability.", "Sustainable Living: Simple Changes for a Greener Future" },
                    { new Guid("f84d265e-75b6-4dae-8e00-0eea96653126"), new DateTime(2025, 1, 26, 23, 25, 41, 4, DateTimeKind.Utc).AddTicks(5140), "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology.", "The Rise of AI in Everyday Life: Transforming How We Live and Work" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("52c732d8-1b78-49a7-ad2a-8016fccdcf0f"), "bul. „Prof. Cvetan Lazarov“ №14", "Sofia", null, "SK CSKA Sofia", "0898 702 088" },
                    { new Guid("634a7e2f-f63f-49c5-a4fc-591cc71e6b24"), "Zala. „Dunav“, ul. „Chiprovci“ 40", "Ruse", null, "Loko Ruse", "+359 8 7662 3232" }
                });

            migrationBuilder.InsertData(
                table: "Judges",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("716e76df-e40d-4ca9-ad0f-831f33497b7b"), "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva", false, "Plamen Velikov" },
                    { new Guid("fbc2a214-e377-4dd3-8155-e5f6b62f7bb5"), "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva.", false, "Rumen Minchev" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("5e5843c7-7478-4e60-b755-1bb273d93a5d"), "The Gainward GeForce RTX 4090 Phantom 24GB is a powerhouse graphics card designed for ultimate gaming and content creation performance. Featuring NVIDIA's cutting-edge Ada Lovelace architecture, it delivers groundbreaking AI-powered graphics, real-time ray tracing, and exceptional efficiency.", "https://desktop.bg/system/images/491136/normal/gainward_geforce_rtx_4090_phantom_24gb.png", "Gainward GeForce RTX 4090 Phantom 24GB", "4759лв." },
                    { new Guid("cd3d6efc-7583-4ecf-a8f3-39793e283417"), "The Logitech G102 LIGHTSYNC White is a high-performance gaming mouse designed for precision, speed, and style. Featuring a 6,000 DPI sensor, it delivers accurate tracking and responsiveness, making it perfect for both casual and competitive gaming. The LIGHTSYNC RGB technology offers customizable lighting", "https://desktop.bg/system/images/249327/normal/910005824.jpg", "Logitech G102 LIGHTSYNC White", "45лв." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("70590f4b-1876-4112-8f6b-501193a0dbc6"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f84d265e-75b6-4dae-8e00-0eea96653126"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("52c732d8-1b78-49a7-ad2a-8016fccdcf0f"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("634a7e2f-f63f-49c5-a4fc-591cc71e6b24"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("716e76df-e40d-4ca9-ad0f-831f33497b7b"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("fbc2a214-e377-4dd3-8155-e5f6b62f7bb5"));

            migrationBuilder.DropColumn(
                name: "DateUploaded",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Tittle",
                table: "Articles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "Tittle" },
                values: new object[,]
                {
                    { new Guid("820f94b5-c53f-4435-8865-c0393c7b3ada"), "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology.", "The Rise of AI in Everyday Life: Transforming How We Live and Work" },
                    { new Guid("df8779c3-4637-4209-9aad-99a61a339813"), "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability.", "Sustainable Living: Simple Changes for a Greener Future" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("20398f77-95c7-401c-88c0-09c2981a96b3"), "Zala. „Dunav“, ul. „Chiprovci“ 40", "Ruse", null, "Loko Ruse", "+359 8 7662 3232" },
                    { new Guid("c7a02059-00aa-49f6-9458-e0dd8f68dfa3"), "bul. „Prof. Cvetan Lazarov“ №14", "Sofia", null, "SK CSKA Sofia", "0898 702 088" }
                });

            migrationBuilder.InsertData(
                table: "Judges",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("6780aea0-60b6-4e3b-8d5b-335b165f910c"), "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva.", false, "Rumen Minchev" },
                    { new Guid("989fb6c4-c002-439a-868b-7583a65edcfe"), "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva", false, "Plamen Velikov" }
                });
        }
    }
}

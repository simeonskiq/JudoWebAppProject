using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JudoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8775085a-a3fd-4917-9ecb-c9d2fd21674e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ef8c99cb-69a5-4d53-b38f-f9f46af75160"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("3f807732-c29e-4e17-87be-e76cd89638bf"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("8272165e-e55e-421b-beb2-77e0e88e7ca5"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("7e6a99c7-1e8f-4d9e-8ea9-df2618824305"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("9aa0e349-3130-4fdf-a0c2-121d8f446674"));

            migrationBuilder.CreateTable(
                name: "ManagerRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerRequests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "Tittle" },
                values: new object[,]
                {
                    { new Guid("d09076b3-7934-4c6f-9619-6412fb5d9790"), "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology.", "The Rise of AI in Everyday Life: Transforming How We Live and Work" },
                    { new Guid("d72e98a3-bf1c-49b8-8ac7-4ae5575131b0"), "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability.", "Sustainable Living: Simple Changes for a Greener Future" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("11bb514c-4fc4-4dda-bc99-575ed0d7ed05"), "Zala. „Dunav“, ul. „Chiprovci“ 40", "Ruse", null, "Loko Ruse", "+359 8 7662 3232" },
                    { new Guid("bec7c306-25be-4b27-8dd7-0579864f6219"), "bul. „Prof. Cvetan Lazarov“ №14", "Sofia", null, "SK CSKA Sofia", "0898 702 088" }
                });

            migrationBuilder.InsertData(
                table: "Judges",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("61193fac-ac09-431b-8199-7ab9f7550994"), "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva.", false, "Rumen Minchev" },
                    { new Guid("bf0df06b-8807-4272-9f73-735751b3d788"), "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva", false, "Plamen Velikov" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerRequests");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d09076b3-7934-4c6f-9619-6412fb5d9790"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d72e98a3-bf1c-49b8-8ac7-4ae5575131b0"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("11bb514c-4fc4-4dda-bc99-575ed0d7ed05"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("bec7c306-25be-4b27-8dd7-0579864f6219"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("61193fac-ac09-431b-8199-7ab9f7550994"));

            migrationBuilder.DeleteData(
                table: "Judges",
                keyColumn: "Id",
                keyValue: new Guid("bf0df06b-8807-4272-9f73-735751b3d788"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "Tittle" },
                values: new object[,]
                {
                    { new Guid("8775085a-a3fd-4917-9ecb-c9d2fd21674e"), "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability.", "Sustainable Living: Simple Changes for a Greener Future" },
                    { new Guid("ef8c99cb-69a5-4d53-b38f-f9f46af75160"), "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology.", "The Rise of AI in Everyday Life: Transforming How We Live and Work" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("3f807732-c29e-4e17-87be-e76cd89638bf"), "Zala. „Dunav“, ul. „Chiprovci“ 40", "Ruse", null, "Loko Ruse", "+359 8 7662 3232" },
                    { new Guid("8272165e-e55e-421b-beb2-77e0e88e7ca5"), "bul. „Prof. Cvetan Lazarov“ №14", "Sofia", null, "SK CSKA Sofia", "0898 702 088" }
                });

            migrationBuilder.InsertData(
                table: "Judges",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("7e6a99c7-1e8f-4d9e-8ea9-df2618824305"), "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva.", false, "Rumen Minchev" },
                    { new Guid("9aa0e349-3130-4fdf-a0c2-121d8f446674"), "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva", false, "Plamen Velikov" }
                });
        }
    }
}

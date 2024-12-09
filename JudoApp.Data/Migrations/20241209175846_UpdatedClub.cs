using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JudoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Clubs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PhoneNumber",
                table: "Clubs",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

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
    }
}

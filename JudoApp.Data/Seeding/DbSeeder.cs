namespace JudoApp.Data.Seeding
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    using JudoApp.Data.Seeding.DataTransferObjects;
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    using JudoApp.Web.Data;

    public static class DbSeeder
    {
        public static async Task SeedClubsAsync(IServiceProvider services, string jsonPath)
        {
            await using JudoDbContext dbContext = services
                .GetRequiredService<JudoDbContext>();

            ICollection<Club> allClubs = await dbContext
                .Clubs
                .ToArrayAsync();
            try
            {
                string jsonInput = await File
                    .ReadAllTextAsync(jsonPath, Encoding.ASCII, CancellationToken.None);

                ImportClubDto[] clubDtos =
                    JsonConvert.DeserializeObject<ImportClubDto[]>(jsonInput);
                foreach (ImportClubDto clubDto in clubDtos)
                {
                    if (!IsValid(clubDto))
                    {
                        continue;
                    }

                    Guid clubGuid = Guid.Empty;
                    if (!IsGuidValid(clubDto.Id, ref clubGuid))
                    {
                        continue;
                    }

                    if (allClubs.Any(
                            m => m.Id.ToString().ToLowerInvariant() == clubGuid.ToString().ToLowerInvariant()))
                    {
                        continue;
                    }

                    Club club = AutoMapperConfig.MapperInstance.Map<Club>(clubDto);

                    await dbContext.Clubs.AddAsync(club);
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred while seeding the clubs in the database!");
            }
        }

        private static bool IsValid(object obj)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();

            var context = new ValidationContext(obj);
            var isValid = Validator.TryValidateObject(obj, context, validationResults);

            return isValid;
        }

        private static bool IsGuidValid(string id, ref Guid parsedGuid)
        {
            // Non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
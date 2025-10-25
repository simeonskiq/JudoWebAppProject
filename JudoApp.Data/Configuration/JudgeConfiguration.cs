namespace JudoApp.Data.Configuration
{

    using JudoApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Common.EntityValidationConstants.Judge;
    using static Common.ApplicationConstants;

    public class JudgeConfiguration : IEntityTypeConfiguration<Judge>
    {
        public void Configure(EntityTypeBuilder<Judge> builder)
        {
            builder.HasKey(j => j.Id);

            builder
                .Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(j => j.Description)
                .IsRequired(false)
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(j => j.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength)
                .HasDefaultValue(NoImageUrl);

            builder.HasData(this.SeedJudges());
        }

        private List<Judge> SeedJudges()
        {
            List<Judge> judges = new List<Judge>()
            {
                new Judge()
                {
                    Name = "Plamen Velikov",
                    Description = "Pritejava licenz 'A' koito mu dava pravo da sudiistva na svetovni purvenstva"
                },
                new Judge()
                {
                    Name = "Rumen Minchev",
                    Description = "Pritejava licenz 'B' s pravo da sudiistva na kontinentalni purvenstva."
                }
            };

            return judges;
        }
    }
}
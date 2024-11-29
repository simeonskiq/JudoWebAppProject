namespace JudoApp.Data.Configuration
{

    using JudoApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Common.EntityValidationConstants.Article;
    using static Common.ApplicationConstants;
    using System;

    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .Property(a => a.Tittle)
                .IsRequired()
                .HasMaxLength(TittleMaxLenght);

            builder
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLenght);

            builder
                .Property(a => a.ImageUrl)
                .IsRequired(false)
                .HasDefaultValue(NoImageUrl)
                .HasMaxLength(ImageUrlMaxLength);

            builder
                .Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasData(this.GenerateArticles());
        }

        private IEnumerable<Article> GenerateArticles()
        {
            IEnumerable<Article> articles = new List<Article>()
            {
                new Article()
                {
                    Tittle = "The Rise of AI in Everyday Life: Transforming How We Live and Work",
                    Description = "Artificial intelligence is no longer a concept confined to science fiction. From personal assistants like Siri and Alexa to advanced data analytics in healthcare, AI is revolutionizing industries and enhancing daily life. This article explores the current applications of AI, its impact on various sectors, and what the future may hold for this transformative technology."
                },
                new Article()
                {
                    Tittle = "Sustainable Living: Simple Changes for a Greener Future",
                    Description = "As environmental concerns grow, many are looking for ways to reduce their carbon footprint and live more sustainably. This article provides practical tips for adopting eco-friendly habits, from reducing plastic use to embracing renewable energy. Discover how small changes in daily routines can contribute to a healthier planet and promote long-term sustainability."
                }
            };

            return articles;
        }
    }
}

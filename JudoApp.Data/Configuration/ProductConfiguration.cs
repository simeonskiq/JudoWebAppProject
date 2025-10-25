namespace JudoApp.Data.Configuration
{
    using JudoApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static JudoApp.Common.EntityValidationConstants.Product;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasMaxLength(PriceMaxLength);

            builder
                .Property(p => p.ImageUrl)
                .IsRequired()
                .HasMaxLength(ImageUrlMaxLength);

            builder
                .Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasData(this.SeedProducts());
        }

        private List<Product> SeedProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Gainward GeForce RTX 4090 Phantom 24GB",
                    Description = "The Gainward GeForce RTX 4090 Phantom 24GB is a powerhouse graphics card designed for ultimate gaming and content creation performance. Featuring NVIDIA's cutting-edge Ada Lovelace architecture, it delivers groundbreaking AI-powered graphics, real-time ray tracing, and exceptional efficiency.",
                    Price = "4759",
                    ImageUrl = "https://desktop.bg/system/images/491136/normal/gainward_geforce_rtx_4090_phantom_24gb.png"
                },
                new Product()
                {
                    Name = "Logitech G102 LIGHTSYNC White",
                    Description = "The Logitech G102 LIGHTSYNC White is a high-performance gaming mouse designed for precision, speed, and style. Featuring a 6,000 DPI sensor, it delivers accurate tracking and responsiveness, making it perfect for both casual and competitive gaming. The LIGHTSYNC RGB technology offers customizable lighting",
                    Price = "45",
                    ImageUrl = "https://desktop.bg/system/images/249327/normal/910005824.jpg"
                }
            };

            return products;
        }
    }
}
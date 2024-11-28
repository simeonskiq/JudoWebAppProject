namespace JudoApp.Data.Configuration
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static Common.EntityValidationConstants.Club;
    using static Common.ApplicationConstants;

    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLenght);

            builder
                .Property(c => c.City)
                .IsRequired()
                .HasMaxLength(CityMaxLenght);

            builder
                .Property(c => c.PhoneNumber)
                .HasMaxLength(PhoneMaxLenght);

            builder
                .Property(c => c.Email)
                .HasMaxLength(EmailMaxLenght);

            builder
                .Property(c => c.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength)
                .HasDefaultValue(NoImageUrl);

            builder
                .Property(c => c.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasData(this.GenerateClubs());
        }

        private IEnumerable<Club> GenerateClubs()
        {
            IEnumerable<Club> clubs = new List<Club>()
            {
                new Club()
                {
                    Name = "Loko Ruse",
                    Address = "Zala. „Dunav“, ul. „Chiprovci“ 40",
                    City = "Ruse",
                    PhoneNumber = "+359 8 7662 3232",
                },
                new Club()
                {
                    Name = "SK CSKA Sofia",
                    Address = "bul. „Prof. Cvetan Lazarov“ №14",
                    City = "Sofia",
                    PhoneNumber = "0898 702 088",
                }
            };

            return clubs;
        }
    }
}

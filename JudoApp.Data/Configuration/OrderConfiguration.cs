namespace JudoApp.Data.Configuration
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using JudoApp.Data.Models;

    using static JudoApp.Common.EntityValidationConstants.Order;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderNumber)
                .IsRequired();

            builder.Property(o => o.FirstName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(o => o.LastName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(o => o.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLength);

            builder.Property(o => o.City)
                .IsRequired()
                .HasMaxLength(CityMaxLength);

            builder.Property(o => o.PostalCode)
                .IsRequired()
                .HasMaxLength(PostalCodeMaxLength);

            builder.Property(o => o.Country)
                .IsRequired()
                .HasMaxLength(CountryMaxLength);

            builder.Property(o => o.ShippingMethod)
                .IsRequired()
                .HasMaxLength(ShippingMethodMaxLength);

            builder.Property(o => o.PaymentMethod)
                .IsRequired()
                .HasMaxLength(PaymentMethodMaxLength);

            builder.Property(o => o.TotalAmount)
                .IsRequired();

            builder.Property(o => o.Email)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(o => o.OrderStatus)
                .IsRequired()
                .HasMaxLength(StatusMaxLength);

            builder.Property(o => o.PhoneNumber)
                .IsRequired()
                .HasMaxLength(PhoneMaxLenght);

            builder.Property(o => o.OrderNotes)
                .HasMaxLength(OrderNotesMaxLength);

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(o => o.OrderNumber)
                .IsUnique();

            builder
                .Property(c => c.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
   
            builder.HasIndex(o => o.UserId);
        }
    }
}

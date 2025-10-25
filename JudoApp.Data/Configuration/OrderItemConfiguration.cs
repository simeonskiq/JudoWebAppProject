namespace JudoApp.Data.Configuration
{
    using JudoApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Common.EntityValidationConstants.Club;

    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder
                 .Property(oi => oi.Id)
                 .ValueGeneratedOnAdd();


            builder
                .Property(oi => oi.ProductName)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(oi => oi.Quantity)
                .IsRequired();

            builder
                .Property(oi => oi.Total)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(oi => oi.ImageUrl)
                .HasMaxLength(ImageUrlMaxLength)
                .IsUnicode(false)
                .IsRequired(false);

            builder
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasIndex(oi => oi.OrderId);
            builder.HasIndex(oi => oi.ProductId);
        }
    }
}

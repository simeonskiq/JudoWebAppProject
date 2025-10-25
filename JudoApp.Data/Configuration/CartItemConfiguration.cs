using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JudoApp.Data.Models;

namespace JudoApp.Data.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Quantity)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Ignore(c => c.Total);

            builder.HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(c => c.ProductId);

        }
    }
}
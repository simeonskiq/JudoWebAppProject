namespace JudoApp.Data.Models
{
    public class CartItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Total => (Price * this.Quantity).ToString("F2");

        public string? ImageUrl { get; set; }

        public Product Product { get; set; } = null!;
    }
}

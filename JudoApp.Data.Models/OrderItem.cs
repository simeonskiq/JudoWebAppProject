namespace JudoApp.Data.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }

        public Order Order { get; set; } = null!;

        public Product? Product { get; set; }

        public Guid? ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }      
        
        public int Quantity { get; set; }

        public decimal Total { get; set; }        

        public string? ImageUrl { get; set; }

        public virtual CartItem? CartItem { get; set; }
    }
}

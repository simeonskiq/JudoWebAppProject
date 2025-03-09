namespace JudoApp.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string OrderNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string ShippingMethod { get; set; } = null!;

        public string PaymentMethod { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;
        
        public ICollection<CartItem> OrderItems { get; set; } = new List<CartItem>();

        public bool IsDeleted { get; set; }
    }
}

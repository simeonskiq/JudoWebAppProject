using System.ComponentModel.DataAnnotations.Schema;

namespace JudoApp.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string City { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string ShippingMethod { get; set; } = null!;

        public string PaymentMethod { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = null!;

        public string OrderNotes { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public bool IsDeleted { get; set; }
    }
}

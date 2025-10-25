namespace JudoApp.Web.ViewModels.Order
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    public class OrderIndexViewModel : IMapFrom<Order>
    {
        public string Id { get; set; } = null!;

        public string OrderNumber { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string DeliveryMethod { get; set; } = null!;

        public string PaymentMethod { get; set; } = null!;

        public string TotalAmount { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = null!;

        public ICollection<CartItem> OrderItems { get; set; } = new List<CartItem>();
    }
}

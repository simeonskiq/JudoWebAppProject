namespace JudoApp.Web.ViewModels.Order
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    public class DeleteOrderViewModel : IMapFrom<Order>
    {
        public string Id { get; set; } = null!;

        public string? FirstName { get; set; } 

        public string? LastName { get; set; } 

        public string? PhoneNumber { get; set; } 

        public string? Email { get; set; } 

        public string? Country { get; set; } 

        public string? City { get; set; } 

        public string? PostalCode { get; set; } 

        public string? DeliveryMethod { get; set; } 

        public string? PaymentMethod { get; set; } 
    }
}

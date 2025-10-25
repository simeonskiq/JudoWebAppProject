namespace JudoApp.Web.ViewModels.Order
{
    using JudoApp.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static JudoApp.Common.EntityValidationConstants.Order;

    public class OrderDetailsViewModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(OrderNumberMaxLength)]
        [MinLength(OrderNumberMinLength)]
        public string OrderNumber { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string FirstName { get; set; } = null!;
        
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Phone]
        [MinLength(PhoneMinLength)]
        [MaxLength(PhoneMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(CountryMinLength)]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;

        [Required]
        [MinLength(CityMinLength)]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [MinLength(AddressMinLength)]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MinLength(PostalCodeMinLength)]
        [MaxLength(PostalCodeMaxLength)]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public string ShippingMethod { get; set; } = null!;

        [Required]
        public string PaymentMethod { get; set; } = null!;

        [Required]
        public string TotalAmount { get; set; } = null!;

        public string OrderNotes { get; set; } = null!;

        [Required]
        public string CustomerId { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; }
    }
}